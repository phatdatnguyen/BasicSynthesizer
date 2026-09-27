using Accord.Audio;
using Accord.Math.Transforms;
using System.Buffers.Binary;
using System.Numerics;
using System.Text;

namespace BasicSynthesizer
{
    public static class Utils
    {
        public static List<(double, double[])> FastFourierTransform(List<(double, double)> timeDomainData, int samplingRate)
        {
            ArgumentNullException.ThrowIfNull(timeDomainData);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(samplingRate);
            List<(double, double[])> frequencyDomainData = new();
            int numberOfSamples = timeDomainData.Count;
            if (numberOfSamples == 0)
                return frequencyDomainData;

            Complex[] spectrum = new Complex[numberOfSamples];
            for (int i = 0; i < numberOfSamples; i++)
            {
                if (!double.IsFinite(timeDomainData[i].Item2))
                    throw new ArgumentException("Audio samples must be finite.", nameof(timeDomainData));
                spectrum[i] = new Complex(timeDomainData[i].Item2, 0);
            }
            FourierTransform2.FFT(spectrum, Accord.Math.FourierTransform.Direction.Forward);

            for (int i = 0; i <= numberOfSamples / 2; i++)
            {
                double frequency = (double)i * samplingRate / numberOfSamples;
                if (frequency > 4000)
                    break;

                // Single-sided amplitude: DC and Nyquist have no negative-frequency partner.
                double scale = i == 0 || (numberOfSamples % 2 == 0 && i == numberOfSamples / 2)
                    ? 1.0 / numberOfSamples : 2.0 / numberOfSamples;
                Complex value = spectrum[i] * scale;
                frequencyDomainData.Add((frequency, new[] { value.Magnitude, value.Real, value.Imaginary }));
            }

            return frequencyDomainData;
        }

        public static Signal LoadWavFile(string fileName)
        {
            using FileStream stream = File.OpenRead(fileName);
            using BinaryReader reader = new(stream, Encoding.ASCII);
            try
            {
                if (ReadFourCc(reader) != "RIFF")
                    throw new InvalidDataException("The file is not a RIFF WAV file.");
                long riffEnd = 8L + reader.ReadUInt32();
                if (ReadFourCc(reader) != "WAVE" || riffEnd < 12 || riffEnd > stream.Length)
                    throw new InvalidDataException("The WAV header is invalid or truncated.");

                ushort formatTag = 0, channels = 0, blockAlign = 0, bitDepth = 0;
                int sampleRate = 0;
                bool hasFormat = false;
                long dataOffset = -1;
                int dataLength = 0;
                while (stream.Position < riffEnd)
                {
                    if (riffEnd - stream.Position < 8)
                        throw new InvalidDataException("The WAV chunk header is truncated.");
                    string chunkId = ReadFourCc(reader);
                    uint chunkSize = reader.ReadUInt32();
                    long nextChunk = stream.Position + chunkSize + (chunkSize & 1);
                    if (nextChunk > riffEnd)
                        throw new InvalidDataException("The WAV chunk extends beyond the file.");

                    if (chunkId == "fmt ")
                    {
                        if (hasFormat || chunkSize < 16)
                            throw new InvalidDataException("The WAV format chunk is invalid.");
                        formatTag = reader.ReadUInt16();
                        channels = reader.ReadUInt16();
                        uint rate = reader.ReadUInt32();
                        uint byteRate = reader.ReadUInt32();
                        blockAlign = reader.ReadUInt16();
                        bitDepth = reader.ReadUInt16();
                        if (channels == 0 || rate == 0 || rate > int.MaxValue)
                            throw new InvalidDataException("The WAV channel count or sample rate is invalid.");
                        sampleRate = (int)rate;

                        if (formatTag == 0xfffe) // WAVE_FORMAT_EXTENSIBLE
                        {
                            if (chunkSize < 40)
                                throw new InvalidDataException("The extended WAV format is truncated.");
                            ushort extraSize = reader.ReadUInt16();
                            ushort validBits = reader.ReadUInt16();
                            reader.ReadUInt32(); // Speaker positions; sample order is preserved.
                            Guid subFormat = new(reader.ReadBytes(16));
                            if (extraSize < 22 || extraSize > chunkSize - 18 || validBits == 0 || validBits > bitDepth)
                                throw new InvalidDataException("The extended WAV format is invalid.");
                            if (subFormat == new Guid("00000001-0000-0010-8000-00aa00389b71"))
                                formatTag = 1;
                            else if (subFormat == new Guid("00000003-0000-0010-8000-00aa00389b71"))
                                formatTag = 3;
                            else
                                throw new NotSupportedException("The WAV encoding is not supported. Use PCM or IEEE floating-point audio.");
                        }

                        bool supported = formatTag == 1 && bitDepth is 8 or 16 or 24 or 32
                            || formatTag == 3 && bitDepth is 32 or 64;
                        if (!supported)
                            throw new NotSupportedException("Use 8, 16, 24 or 32-bit PCM, or 32 or 64-bit IEEE floating-point WAV audio.");
                        if (blockAlign != channels * (bitDepth / 8) || byteRate != (long)sampleRate * blockAlign)
                            throw new InvalidDataException("The WAV block alignment or byte rate is invalid.");
                        hasFormat = true;
                    }
                    else if (chunkId == "data")
                    {
                        if (dataOffset >= 0 || chunkSize > int.MaxValue)
                            throw new InvalidDataException("The WAV data chunk is duplicated or too large.");
                        dataOffset = stream.Position;
                        dataLength = (int)chunkSize;
                    }

                    // RIFF metadata may occur anywhere, and odd chunk sizes have one padding byte.
                    stream.Position = nextChunk;
                }

                if (!hasFormat || dataOffset < 0 || dataLength == 0 || dataLength % blockAlign != 0)
                    throw new InvalidDataException("The WAV file must contain a format and complete audio frames.");

                stream.Position = dataOffset;
                byte[] data = reader.ReadBytes(dataLength);
                if (data.Length != dataLength)
                    throw new InvalidDataException("The WAV audio data is truncated.");

                SampleFormat sampleFormat;
                if (formatTag == 3)
                {
                    sampleFormat = bitDepth == 32 ? SampleFormat.Format32BitIeeeFloat : SampleFormat.Format64BitIeeeFloat;
                }
                else if (bitDepth == 24)
                {
                    // Accord has no 24-bit format. Left-align PCM in a signed 32-bit container.
                    byte[] expanded = new byte[checked(dataLength / 3 * 4)];
                    for (int source = 0, target = 0; source < data.Length; source += 3, target += 4)
                    {
                        expanded[target + 1] = data[source];
                        expanded[target + 2] = data[source + 1];
                        expanded[target + 3] = data[source + 2];
                    }
                    data = expanded;
                    sampleFormat = SampleFormat.Format32Bit;
                }
                else
                {
                    sampleFormat = bitDepth switch
                    {
                        8 => SampleFormat.Format8BitUnsigned,
                        16 => SampleFormat.Format16Bit,
                        _ => SampleFormat.Format32Bit
                    };
                }

                return new Signal(data, channels, dataLength / blockAlign, sampleRate, sampleFormat);
            }
            catch (EndOfStreamException ex)
            {
                throw new InvalidDataException("The WAV file is truncated.", ex);
            }
        }

        public static Signal GenerateWaveSignal(double[] waveIntensity, int samplingRate, double duration, byte bitDepth)
        {
            ArgumentNullException.ThrowIfNull(waveIntensity);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(samplingRate);
            if (!double.IsFinite(duration) || duration <= 0)
                throw new ArgumentOutOfRangeException(nameof(duration));
            if (bitDepth is not (8 or 16 or 32))
                throw new ArgumentOutOfRangeException(nameof(bitDepth), "Use 8, 16 or 32-bit PCM.");

            // The actual frames are authoritative; a rounded duration must not truncate data.
            byte[] data = new byte[checked(waveIntensity.Length * (bitDepth / 8))];
            for (int i = 0; i < waveIntensity.Length; i++)
            {
                if (!double.IsFinite(waveIntensity[i]))
                    throw new ArgumentException("Audio samples must be finite.", nameof(waveIntensity));
                double value = Math.Clamp(waveIntensity[i], -1.0, 1.0);
                switch (bitDepth)
                {
                    case 8:
                        data[i] = (byte)Math.Clamp(Math.Round(value * 128) + 128, 0, 255);
                        break;
                    case 16:
                        short sample16 = (short)Math.Clamp(Math.Round(value * 32768), short.MinValue, short.MaxValue);
                        BinaryPrimitives.WriteInt16LittleEndian(data.AsSpan(i * 2, 2), sample16);
                        break;
                    case 32:
                        int sample32 = (int)Math.Clamp(Math.Round(value * 2147483648.0), int.MinValue, int.MaxValue);
                        BinaryPrimitives.WriteInt32LittleEndian(data.AsSpan(i * 4, 4), sample32);
                        break;
                }
            }

            SampleFormat format = bitDepth switch
            {
                8 => SampleFormat.Format8BitUnsigned,
                16 => SampleFormat.Format16Bit,
                _ => SampleFormat.Format32Bit
            };
            return new Signal(data, 1, waveIntensity.Length, samplingRate, format);
        }

        public static List<(double, double)> GenerateWaveData(Signal signal, string channel)
        {
            ArgumentNullException.ThrowIfNull(signal);
            int channelIndex = channel switch
            {
                "Mono" when signal.NumberOfChannels == 1 => 0,
                "Left" when signal.NumberOfChannels >= 2 => 0,
                "Right" when signal.NumberOfChannels >= 2 => 1,
                _ => throw new ArgumentException("Select Mono for mono audio, or Left/Right for stereo audio.", nameof(channel))
            };
            byte[] data = GetSignalBytes(signal);
            List<(double, double)> waveDataPoints = new(signal.NumberOfFrames);
            for (int frame = 0; frame < signal.NumberOfFrames; frame++)
            {
                int offset = (frame * signal.NumberOfChannels + channelIndex) * signal.SampleSize;
                ReadOnlySpan<byte> sample = data.AsSpan(offset, signal.SampleSize);
                double value = signal.SampleFormat switch
                {
                    SampleFormat.Format8BitUnsigned => (sample[0] - 128) / 128.0,
                    SampleFormat.Format8Bit => unchecked((sbyte)sample[0]) / 128.0,
                    SampleFormat.Format16Bit => BinaryPrimitives.ReadInt16LittleEndian(sample) / 32768.0,
                    SampleFormat.Format32Bit => BinaryPrimitives.ReadInt32LittleEndian(sample) / 2147483648.0,
                    SampleFormat.Format32BitIeeeFloat => BinaryPrimitives.ReadSingleLittleEndian(sample),
                    SampleFormat.Format64BitIeeeFloat => BinaryPrimitives.ReadDoubleLittleEndian(sample),
                    _ => throw new NotSupportedException("The audio sample format is not supported.")
                };
                if (!double.IsFinite(value))
                    throw new InvalidDataException("The audio contains non-finite samples.");
                waveDataPoints.Add(((double)frame / signal.SampleRate, value));
            }

            return waveDataPoints;
        }

        public static void ExportWavFile(Signal signal, string fileName)
        {
            ArgumentNullException.ThrowIfNull(signal);
            if (signal.NumberOfChannels is < 1 or > 2 || signal.SampleRate <= 0)
                throw new NotSupportedException("WAV export requires mono or stereo audio with a positive sample rate.");

            (ushort formatTag, ushort bitDepth) = signal.SampleFormat switch
            {
                SampleFormat.Format8Bit or SampleFormat.Format8BitUnsigned => ((ushort)1, (ushort)8),
                SampleFormat.Format16Bit => ((ushort)1, (ushort)16),
                SampleFormat.Format32Bit => ((ushort)1, (ushort)32),
                SampleFormat.Format32BitIeeeFloat => ((ushort)3, (ushort)32),
                SampleFormat.Format64BitIeeeFloat => ((ushort)3, (ushort)64),
                _ => throw new NotSupportedException("The audio sample format cannot be exported as WAV.")
            };
            byte[] data = GetSignalBytes(signal);
            if (signal.SampleFormat == SampleFormat.Format8Bit)
                for (int i = 0; i < data.Length; i++)
                    data[i] ^= 0x80; // WAV stores 8-bit PCM unsigned, with silence at 128.

            ushort blockAlign = checked((ushort)(signal.NumberOfChannels * bitDepth / 8));
            uint byteRate = checked((uint)((long)signal.SampleRate * blockAlign));
            bool floatingPoint = formatTag == 3;
            int formatSize = floatingPoint ? 18 : 16;
            int padding = data.Length & 1;
            uint riffSize = checked((uint)(4L + 8 + formatSize + (floatingPoint ? 12 : 0) + 8 + data.Length + padding));
            using FileStream stream = new(fileName, FileMode.Create, FileAccess.Write);
            using BinaryWriter writer = new(stream, Encoding.ASCII);
            WriteFourCc(writer, "RIFF");
            writer.Write(riffSize);
            WriteFourCc(writer, "WAVE");
            WriteFourCc(writer, "fmt ");
            writer.Write(formatSize);
            writer.Write(formatTag);
            writer.Write((ushort)signal.NumberOfChannels);
            writer.Write(signal.SampleRate);
            writer.Write(byteRate);
            writer.Write(blockAlign);
            writer.Write(bitDepth);
            if (floatingPoint)
            {
                writer.Write((ushort)0); // WAVEFORMATEX extension size.
                WriteFourCc(writer, "fact");
                writer.Write(4);
                writer.Write(signal.NumberOfFrames);
            }
            WriteFourCc(writer, "data");
            writer.Write(data.Length);
            writer.Write(data);
            if (padding != 0)
                writer.Write((byte)0);
        }

        private static byte[] GetSignalBytes(Signal signal)
        {
            byte[] data = new byte[signal.NumberOfBytes];
            Buffer.BlockCopy(signal.InnerData, 0, data, 0, data.Length);
            return data;
        }

        private static string ReadFourCc(BinaryReader reader)
        {
            byte[] bytes = reader.ReadBytes(4);
            if (bytes.Length != 4)
                throw new EndOfStreamException();
            return Encoding.ASCII.GetString(bytes);
        }

        private static void WriteFourCc(BinaryWriter writer, string value) => writer.Write(Encoding.ASCII.GetBytes(value));
    }
}
