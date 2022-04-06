using Accord.Audio;
using Accord.Math.Transforms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BasicSynthesizer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        internal static MainForm mainForm;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new MainForm();
            Application.Run(mainForm);
        }

        public static List<DataPoint> FastFourierTransform(List<DataPoint> timeDomainData, int samplingRate)
        {
            List<DataPoint> frequencyDomainData = new List<DataPoint>();

            int numberOfSamples = timeDomainData.Count;
            Complex[] complices = new Complex[numberOfSamples];
            for (int i = 0; i < numberOfSamples; i++)
                complices[i] = new Complex(timeDomainData[i].YValues[0], 0);
            FourierTransform2.FFT(complices, Accord.Math.FourierTransform.Direction.Forward);

            double[] frequencyVector = FourierTransform2.GetFrequencyVector(numberOfSamples, samplingRate);
            double maxFrequency = Math.Min(frequencyVector.Max(), 4000);
            for (int i = 0; i < maxFrequency; i++)
                frequencyDomainData.Add(new DataPoint(frequencyVector[i], new double[] { complices[i].Real, complices[i].Imaginary, complices[i].Magnitude }));

            return frequencyDomainData;
        }

        public static Signal LoadWavFile(string fileName)
        {
            FileStream fileStream = File.Open(fileName, FileMode.Open);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            int chunkID = binaryReader.ReadInt32();
            int fileSize = binaryReader.ReadInt32();
            int riffType = binaryReader.ReadInt32();
            int fmtID = binaryReader.ReadInt32();
            int fmtSize = binaryReader.ReadInt32();
            int fmtCode = binaryReader.ReadInt16();
            int channels = binaryReader.ReadInt16();
            int sampleRate = binaryReader.ReadInt32();
            int byteRate = binaryReader.ReadInt32();
            int fmtBlockAlign = binaryReader.ReadInt16();
            int bitDepth = binaryReader.ReadInt16();
            if (fmtSize == 18)
            {
                int fmtExtraSize = binaryReader.ReadInt16();
                binaryReader.ReadBytes(fmtExtraSize);
            }
            int dataID = binaryReader.ReadInt32();
            int bytes = binaryReader.ReadInt32();
            byte[] byteArray = binaryReader.ReadBytes(bytes);
            int bytesPerSample = bitDepth / 8;
            int numberOfSamples = bytes / bytesPerSample;

            SampleFormat sampleFormat = SampleFormat.Format16Bit;
            switch (bitDepth)
            {
                case 8:
                    sampleFormat = SampleFormat.Format8Bit;
                    break;
                case 16:
                    sampleFormat = SampleFormat.Format16Bit;
                    break;
                case 32:
                    sampleFormat = SampleFormat.Format32Bit;
                    break;
                default:
                    break;
            }

            return new Signal(byteArray.ToArray(), channels, numberOfSamples / channels, sampleRate, sampleFormat);
        }

        public static Signal GenerateWaveSignal(float[] waveIntensity, int samplingRate, float duration, byte bitDepth)
        {
            int numberOfSamples = Convert.ToInt32(Math.Floor(duration * samplingRate));

            switch (bitDepth)
            {
                case 8:
                    sbyte[] quantizedSignalData8bit = Quantize8bitSignal(waveIntensity);
                    byte[] binaryData = new byte[numberOfSamples * sizeof(sbyte)];
                    Buffer.BlockCopy(quantizedSignalData8bit, 0, binaryData, 0, quantizedSignalData8bit.Length * sizeof(sbyte));
                    return new Signal(binaryData, 1, numberOfSamples, samplingRate, SampleFormat.Format8Bit);
                case 16:
                    short[] quantizedSignalData16bit = Quantize16bitSignal(waveIntensity);
                    binaryData = new byte[numberOfSamples * sizeof(short)];
                    Buffer.BlockCopy(quantizedSignalData16bit, 0, binaryData, 0, quantizedSignalData16bit.Length * sizeof(short));
                    return new Signal(binaryData, 1, numberOfSamples, samplingRate, SampleFormat.Format16Bit);
                case 32:
                    int[] quantizedSignalData32bit = Quantize32bitSignal(waveIntensity);
                    binaryData = new byte[numberOfSamples * sizeof(int)];
                    Buffer.BlockCopy(quantizedSignalData32bit, 0, binaryData, 0, quantizedSignalData32bit.Length * sizeof(int));
                    return new Signal(binaryData, 1, numberOfSamples, samplingRate, SampleFormat.Format32Bit);
                default:
                    return null;
            }
        }

        private static sbyte[] Quantize8bitSignal(float[] signalData)
        {
            sbyte[] intensityList = new sbyte[signalData.Length];
            for (int i = 0; i < signalData.Length; i++)
                intensityList[i] = Convert.ToSByte(sbyte.MaxValue * signalData[i]);

            return intensityList;
        }

        private static short[] Quantize16bitSignal(float[] signalData)
        {
            short[] intensityList = new short[signalData.Length];
            for (int i = 0; i < signalData.Length; i++)
                intensityList[i] = Convert.ToInt16(short.MaxValue * signalData[i]);

            return intensityList;
        }

        private static int[] Quantize32bitSignal(float[] signalData)
        {
            int[] intensityList = new int[signalData.Length];

            for (int i = 0; i < signalData.Length; i++)
                intensityList[i] = Convert.ToInt32(int.MaxValue * signalData[i]);

            return intensityList;
        }

        public static List<DataPoint> GenerateWaveData(Signal signal, string channel)
        {
            float[] intensity = null;
            float interval = 1f / signal.SampleRate;
            List<DataPoint> waveDataPoints = new List<DataPoint>();

            switch (signal.SampleFormat)
            {
                case SampleFormat.Format8Bit:
                    sbyte[] intensity8bit = new sbyte[signal.NumberOfSamples];
                    Buffer.BlockCopy((byte[])signal.InnerData, 0, intensity8bit, 0, signal.NumberOfSamples * sizeof(sbyte));
                    intensity = Array.ConvertAll(intensity8bit, e => e / (float)sbyte.MaxValue);
                    break;
                case SampleFormat.Format16Bit:
                    short[] intensity16bit = new short[signal.NumberOfSamples];
                    Buffer.BlockCopy((byte[])signal.InnerData, 0, intensity16bit, 0, signal.NumberOfSamples * sizeof(short));
                    intensity = Array.ConvertAll(intensity16bit, e => e / (float)short.MaxValue);
                    break;
                case SampleFormat.Format32Bit:
                    int[] intensity32bit = new int[signal.NumberOfSamples];
                    Buffer.BlockCopy((byte[])signal.InnerData, 0, intensity32bit, 0, signal.NumberOfSamples * sizeof(int));
                    intensity = Array.ConvertAll(intensity32bit, e => e / (float)int.MaxValue);
                    break;
                default:
                    break;
            }

            if (channel == "Mono")
            {
                for (int i = 0; i < intensity.Length; i++)
                    waveDataPoints.Add(new DataPoint(interval * i, intensity[i]));

                return waveDataPoints;
            }

            float[] leftChannel = new float[signal.NumberOfFrames];
            float[] rightChannel = new float[signal.NumberOfFrames];
            for (int s = 0, v = 0; s < signal.NumberOfFrames; s++)
            {
                leftChannel[s] = intensity[v++];
                rightChannel[s] = intensity[v++];
            }
            for (int i = 0; i < signal.NumberOfFrames; i++)
            {
                if (channel == "Left")
                    waveDataPoints.Add(new DataPoint(interval * i, leftChannel[i]));
                else if (channel == "Right")
                    waveDataPoints.Add(new DataPoint(interval * i, rightChannel[i]));
            }

            return waveDataPoints;
        }

        public static void ExportWavFile(Signal signal, string fileName)
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
            short bitDepth = 16;
            switch (signal.SampleFormat)
            {
                case SampleFormat.Format8Bit:
                    bitDepth = 8;
                    break;
                case SampleFormat.Format16Bit:
                    bitDepth = 16;
                    break;
                case SampleFormat.Format32Bit:
                    bitDepth = 32;
                    break;
                default:
                    break;
            }
            short blockAlign = (short)(bitDepth / 8);
            int subChunk2Size = (int)(signal.SampleRate * signal.Duration.TotalSeconds * blockAlign);
            binaryWriter.Write(new char[] { 'R', 'I', 'F', 'F' });
            binaryWriter.Write(36 + subChunk2Size);
            binaryWriter.Write(new char[] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' });
            binaryWriter.Write(16);
            binaryWriter.Write((short)1);
            binaryWriter.Write((short)1);
            binaryWriter.Write(signal.SampleRate);
            binaryWriter.Write(signal.SampleRate * blockAlign);
            binaryWriter.Write(blockAlign);
            binaryWriter.Write(bitDepth);
            binaryWriter.Write(new[] { 'd', 'a', 't', 'a' });
            binaryWriter.Write(subChunk2Size);
            binaryWriter.Write((byte[])signal.InnerData);
            memoryStream.Position = 0;

            FileStream fileStream = new FileStream(fileName, FileMode.Create);
            memoryStream.WriteTo(fileStream);
            fileStream.Close();
            memoryStream.Close();
        }
    }
}
