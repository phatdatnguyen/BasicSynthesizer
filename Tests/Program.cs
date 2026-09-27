using System.Reflection;
using System.Text;
using Accord.Audio;
using BasicSynthesizer;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

internal static class Program
{
    [STAThread]
    private static int Main()
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        (string Name, Action Run)[] tests =
        [
            ("Oscillator amplitude, phase and zero frequency", TestOscillators),
            ("Silent and weighted oscillator mixing", TestMixing),
            ("LFO depth and rounded input duration", TestLfo),
            ("Envelope zero stages and early note-off", TestEnvelope),
            ("Filter empty input, resonance and overload parity", TestFilter),
            ("Invalid DSP parameters fail explicitly", TestDspValidation),
            ("FFT known sine, DC, Nyquist and empty input", TestFft),
            ("PCM mono and stereo WAV round trips", TestPcmRoundTrips),
            ("8-bit WAV silence, RIFF size and odd padding", TestUnsignedPcm),
            ("WAV optional chunks, 24-bit PCM and float", TestAdditionalWavFormats),
            ("Malformed and truncated WAV rejection", TestMalformedWav),
            ("Playback buffer boundaries and final partial block", TestPlaybackBuffer),
            ("Oscillator dialog notes and cancelled edits", TestOscillatorForm),
            ("Main form effects, spectrum selection and reset", TestMainForm)
        ];

        int failures = 0;
        foreach ((string name, Action run) in tests)
        {
            try
            {
                run();
                Console.WriteLine($"PASS {name}");
            }
            catch (Exception error)
            {
                failures++;
                Console.Error.WriteLine($"FAIL {name}: {error}");
            }
        }

        Console.WriteLine($"{tests.Length - failures}/{tests.Length} regression groups passed.");
        return failures == 0 ? 0 : 1;
    }

    private static void TestOscillators()
    {
        var triangle = new Oscillator(Oscillator.OscillatorWaveform.Triangle, 1, 0.25, 0, 1);
        double[] samples = triangle.GenerateWaveDataPoints(8, 1);
        Near(samples.Min(), -0.25);
        Near(samples.Max(), 0.25);
        Near(samples.Average(), 0);
        triangle.Amplitude = 0;
        Check(triangle.GenerateWaveDataPoints(8, 1).All(value => value == 0), "Zero-amplitude triangle must be silent.");

        var sine = new Oscillator(Oscillator.OscillatorWaveform.Sine, 0, 0.75, -90, 1);
        Near(sine.Phase, 270);
        Check(sine.GenerateWaveDataPoints(8, 1).All(value => Math.Abs(value + 0.75) < 1e-12), "Zero frequency must produce a finite phase-fixed signal.");
        sine.Phase = 450;
        Near(sine.Phase, 90);
        Near(sine.GenerateWaveDataPoints(8, 1)[0], 0.75);
        Check(sine.GenerateWaveDataPoints(8, 0).Length == 0, "Zero-duration signal must be empty.");
    }

    private static void TestMixing()
    {
        Check(Oscillator.MixOscillators([], 8, 1).All(point => point.Item2 == 0), "Empty mixer must be silent.");
        var first = new Oscillator(Oscillator.OscillatorWaveform.Sine, 0, 1, 90, 0);
        Check(Oscillator.MixOscillators([first], 8, 1).All(point => point.Item2 == 0), "Muted mixer must not produce NaN.");
        first.Ratio = double.MaxValue;
        var second = new Oscillator(Oscillator.OscillatorWaveform.Sine, 0, 0.5, 90, double.MaxValue);
        var mixed = Oscillator.MixOscillators([first, second], 8, 1);
        Check(mixed.All(point => Math.Abs(point.Item2 - 0.75) < 1e-12), "Large finite weights must not overflow.");
        Near(mixed[7].Item1, 7.0 / 8);
    }

    private static void TestLfo()
    {
        double[] input = Enumerable.Repeat(1.0, 100).ToArray();
        var lfo = new LowFrequencyOscillator(Oscillator.OscillatorWaveform.Sine, 1, 0, 0);
        Compare(input, lfo.Apply(input, 100, 0.01));
        lfo.Amplitude = 0.25;
        double[] result = lfo.Apply(input, 100, 0.01);
        Near(result.Min(), 0.75);
        Near(result.Max(), 1);
        CompareOverloads(input, result, lfo.Apply(Points(input, 100, 5), 100, 0.01));
    }

    private static void TestEnvelope()
    {
        double[] input = Enumerable.Repeat(1.0, 11).ToArray();
        var immediate = new Envelope(0, 0, 100, 0);
        double[] output = immediate.Apply(input, 10, 1);
        Check(output.Take(10).All(value => value == 1), "Zero-length attack, decay and release must stay finite.");
        Near(output[10], 0);
        CompareOverloads(input, output, immediate.Apply(Points(input, 10, 5), 10, 1));

        var shortNote = new Envelope(0.8, 0, 50, 0.5);
        output = shortNote.Apply(input, 10, 1);
        Near(output[4], 0.5);
        Near(output[5], 0.625);
        Near(output[6], 0.5);
        Near(output[10], 0);
        Check(immediate.Apply(Array.Empty<double>(), 10, 0).Length == 0, "Empty envelope input must be supported.");
    }

    private static void TestFilter()
    {
        double[] input = Enumerable.Range(0, 4096).Select(i => 2.0 * Math.Sin(2 * Math.PI * 500 * i / 8000)).ToArray();
        foreach (Filter.FilterMode mode in Enum.GetValues<Filter.FilterMode>())
        {
            var filter = new Filter(mode, 500, 100);
            Check(filter.Apply(Array.Empty<double>(), 8000).Length == 0, "Empty filter input must be supported.");
            Check(filter.Apply(new List<(double, double)>(), 8000).Count == 0, "Empty tuple filter input must be supported.");
            double[] output = filter.Apply(input, 8000);
            Check(output.All(double.IsFinite), "Maximum resonance must stay finite.");
            CompareOverloads(input, output, filter.Apply(Points(input, 8000, 5), 8000));
        }

        double[] dc = Enumerable.Repeat(1.0, 4096).ToArray();
        Near(new Filter(Filter.FilterMode.LowPass, 500, 0).Apply(dc, 8000)[^1], 1, 1e-9);
        Near(new Filter(Filter.FilterMode.HighPass, 500, 0).Apply(dc, 8000)[^1], 0, 1e-9);
        Near(new Filter(Filter.FilterMode.BandPass, 500, 0).Apply(dc, 8000)[^1], 0, 1e-9);
    }

    private static void TestDspValidation()
    {
        var oscillator = new Oscillator(Oscillator.OscillatorWaveform.Sine, 440, 1, 0, 1);
        Throws<ArgumentOutOfRangeException>(() => oscillator.GenerateWaveDataPoints(0, 1));
        Throws<ArgumentOutOfRangeException>(() => oscillator.GenerateWaveDataPoints(8000, double.NaN));
        oscillator.Frequency = double.PositiveInfinity;
        Throws<ArgumentOutOfRangeException>(() => oscillator.GenerateWaveDataPoints(8000, 1));
        Throws<ArgumentOutOfRangeException>(() => new Envelope(-1, 0, 100, 0).Apply([1.0], 8000, 1));
        Throws<ArgumentOutOfRangeException>(() => new Filter(Filter.FilterMode.LowPass, 500, 101).Apply([1.0], 8000));
        Throws<ArgumentOutOfRangeException>(() => new LowFrequencyOscillator(Oscillator.OscillatorWaveform.Sine, 1, 2, 0).Apply([1.0], 8000, 1));
    }

    private static void TestFft()
    {
        const int sampleRate = 8192;
        const int count = 1024;
        double[] sine = Enumerable.Range(0, count).Select(i => Math.Sin(2 * Math.PI * 512 * i / sampleRate)).ToArray();
        var spectrum = Utils.FastFourierTransform(Points(sine, sampleRate), sampleRate);
        var peak = spectrum.MaxBy(point => point.Item2[0]);
        Near(peak.Item1, 512);
        Near(peak.Item2[0], 1, 1e-9);
        Near(peak.Item2[1], 0, 1e-9);
        Near(Math.Abs(peak.Item2[2]), 1, 1e-9);
        Check(spectrum.All(point => point.Item1 <= 4000), "Spectrum must respect its display limit.");

        var dc = Utils.FastFourierTransform(Points(Enumerable.Repeat(0.5, count).ToArray(), sampleRate), sampleRate);
        Near(dc[0].Item2[0], 0.5);
        Near(dc[0].Item2[1], 0.5);
        Near(dc[0].Item2[2], 0);
        var nyquist = Utils.FastFourierTransform(Points(Enumerable.Range(0, count).Select(i => i % 2 == 0 ? 1.0 : -1.0).ToArray(), 8000), 8000);
        Near(nyquist[^1].Item1, 4000);
        Near(nyquist[^1].Item2[0], 1, 1e-9);
        Check(Utils.FastFourierTransform([], sampleRate).Count == 0, "Empty FFT must be supported.");
        Check(Utils.FastFourierTransform(Points(sine.Take(777).ToArray(), sampleRate), sampleRate).All(point => point.Item2.All(double.IsFinite)), "Non-power-of-two FFT must stay finite.");
    }

    private static void TestPcmRoundTrips()
    {
        double[] mono = [-1, -0.5, 0, 0.5, 1];
        double[] interleaved = [-1, 0.75, -0.5, 0.5, 0, 0.25, 0.5, 0, 1, -1];
        foreach (byte bitDepth in new byte[] { 8, 16, 32 })
        {
            double tolerance = 1.0 / Math.Pow(2, bitDepth - 1) + 1e-12;
            using Signal monoSignal = Utils.GenerateWaveSignal(mono, 8000, 1, bitDepth);
            Check(monoSignal.NumberOfFrames == mono.Length, "Signal length must follow input samples despite rounded duration.");
            WithTemporaryFile(path =>
            {
                Utils.ExportWavFile(monoSignal, path);
                using Signal loaded = Utils.LoadWavFile(path);
                Check(loaded.NumberOfChannels == 1 && loaded.NumberOfFrames == mono.Length, "Mono WAV metadata must round-trip.");
                Compare(mono, Utils.GenerateWaveData(loaded, "Mono").Select(point => point.Item2).ToArray(), tolerance);
            });

            using Signal packed = Utils.GenerateWaveSignal(interleaved, 8000, 1, bitDepth);
            using Signal stereo = new((byte[])((byte[])packed.InnerData).Clone(), 2, interleaved.Length / 2, 8000, packed.SampleFormat);
            WithTemporaryFile(path =>
            {
                Utils.ExportWavFile(stereo, path);
                using Signal loaded = Utils.LoadWavFile(path);
                Check(loaded.NumberOfChannels == 2 && loaded.NumberOfFrames == 5, "Stereo WAV metadata must round-trip.");
                var left = Utils.GenerateWaveData(loaded, "Left");
                var right = Utils.GenerateWaveData(loaded, "Right");
                Compare(mono, left.Select(point => point.Item2).ToArray(), tolerance);
                Compare([0.75, 0.5, 0.25, 0, -1], right.Select(point => point.Item2).ToArray(), tolerance);
                Near(left[^1].Item1, 4.0 / 8000);
            });
        }
    }

    private static void TestUnsignedPcm()
    {
        using Signal signal = Utils.GenerateWaveSignal([-1, 0, 1], 8000, 1, 8);
        Check(((byte[])signal.InnerData).SequenceEqual(new byte[] { 0, 128, 255 }), "8-bit WAV uses unsigned PCM with silence at 128.");
        WithTemporaryFile(path =>
        {
            Utils.ExportWavFile(signal, path);
            byte[] bytes = File.ReadAllBytes(path);
            Check(bytes.Length % 2 == 0, "Odd sample bytes must have RIFF padding.");
            Check(BitConverter.ToInt32(bytes, 4) == bytes.Length - 8, "RIFF size must include the padding byte.");
            using Signal loaded = Utils.LoadWavFile(path);
            Near(Utils.GenerateWaveData(loaded, "Mono")[1].Item2, 0);
            Check(loaded.NumberOfFrames == 3, "Padding must not create an extra frame.");
        });
    }

    private static void TestAdditionalWavFormats()
    {
        byte[] pcm24 = [0, 0, 0x80, 0, 0, 0, 0xFF, 0xFF, 0x7F];
        WithTemporaryFile(path =>
        {
            File.WriteAllBytes(path, BuildWav(1, 24, 1, pcm24, true));
            using Signal loaded = Utils.LoadWavFile(path);
            Compare([-1, 0, 1 - 1.0 / 8388608], Utils.GenerateWaveData(loaded, "Mono").Select(point => point.Item2).ToArray());
        });

        foreach (short bits in new short[] { 32, 64 })
        {
            double[] values = [-1.25, 0, 0.5, 1.25];
            byte[] bytes = values.SelectMany(value => bits == 32 ? BitConverter.GetBytes((float)value) : BitConverter.GetBytes(value)).ToArray();
            WithTemporaryFile(path =>
            {
                File.WriteAllBytes(path, BuildWav(3, bits, 1, bytes));
                using Signal loaded = Utils.LoadWavFile(path);
                Compare(values, Utils.GenerateWaveData(loaded, "Mono").Select(point => point.Item2).ToArray());
                Utils.ExportWavFile(loaded, path);
                using Signal reloaded = Utils.LoadWavFile(path);
                Compare(values, Utils.GenerateWaveData(reloaded, "Mono").Select(point => point.Item2).ToArray());
            });
        }
    }

    private static void TestMalformedWav()
    {
        byte[] valid = BuildWav(1, 16, 1, [0, 0, 0xFF, 0x7F]);
        byte[] wrongSignature = (byte[])valid.Clone();
        wrongSignature[0] = (byte)'X';
        foreach (byte[] invalid in new[] { new byte[] { 1, 2, 3 }, wrongSignature, valid[..^1], BuildWav(1, 16, 1, [0]) })
        {
            WithTemporaryFile(path =>
            {
                File.WriteAllBytes(path, invalid);
                Throws<InvalidDataException>(() => { using Signal unused = Utils.LoadWavFile(path); });
            });
        }
    }

    private static void TestOscillatorForm()
    {
        var oscillator = new Oscillator(Oscillator.OscillatorWaveform.Sine, 16.35, 0.75, 0, 1);
        using var form = new OscillatorForm(oscillator);
        var notes = Field<ComboBox>(form, "notesComboBox");
        var frequency = Field<NumericUpDown>(form, "frequencyNumericUpDown");
        Check((string?)notes.SelectedItem == "C0", "Editing C0 must select its note without float comparison errors.");
        frequency.Value = 277.18m;
        Check((string?)notes.SelectedItem == "C#4/Db4", "Manual note frequency must update note selection.");
        frequency.Value = 300m;
        Check((string?)notes.SelectedItem == "(none)", "Custom frequency must clear the note preset.");
        notes.SelectedItem = "C0";
        Check(frequency.Value == 16.35m, "Selecting C0 must apply its frequency.");
        frequency.Value = 300m;
        form.DialogResult = DialogResult.Cancel;
        Invoke(form, "OscillatorForm_FormClosed", form, new FormClosedEventArgs(CloseReason.UserClosing));
        Near(oscillator.Frequency, 16.35);
    }

    private static void TestPlaybackBuffer()
    {
        Type playback = typeof(MainForm).Assembly.GetType("BasicSynthesizer.AudioPlayback", throwOnError: true)!;
        MethodInfo fill = playback.GetMethod("FillBuffer", BindingFlags.Static | BindingFlags.NonPublic)!;
        float[] samples = Enumerable.Range(1, 10).Select(value => (float)value).ToArray();
        var request = new NewFrameRequestedEventArgs(8);
        object[] arguments = [samples, 0, request];
        fill.Invoke(null, arguments);
        Check(request.Buffer.SequenceEqual(samples.Take(8)) && !request.Stop, "First playback block must include its exact samples.");
        request.Frames = 4;
        fill.Invoke(null, arguments);
        Check(request.Buffer.Take(4).SequenceEqual(new float[] { 9, 10, 0, 0 }) && !request.Stop, "Final partial block must play before stopping and must clear its tail.");
        fill.Invoke(null, arguments);
        Check(request.Buffer.All(value => value == 0) && request.Stop && (int)arguments[1] == 10, "Exhausted playback must stop with a cleared buffer.");

        request = new NewFrameRequestedEventArgs(8);
        arguments = [new float[] { 0.25f, -0.25f }, 0, request];
        fill.Invoke(null, arguments);
        Check(request.Buffer.Take(2).SequenceEqual(new float[] { 0.25f, -0.25f }) && request.Buffer.Skip(2).All(value => value == 0) && !request.Stop,
            "Clips shorter than one device buffer must retain their audio.");
    }

    private static void TestMainForm()
    {
        using var form = new MainForm();
        Invoke(form, "MainForm_Load", form, EventArgs.Empty);
        Check(Field<NumericUpDown>(form, "durationNumericUpDown").Minimum > 0, "Synthesized duration must not permit zero samples.");
        Check(!Field<ToolStripMenuItem>(form, "exportToolStripMenuItem").Enabled, "Export must be disabled before a sound exists.");
        SetField(form, "workingWithOscillators", true);
        var oscillator = new Oscillator(Oscillator.OscillatorWaveform.Sine, 440, 0.5, 0, 1);
        Invoke(form, "OnSoundWaveCreated", form, new SoundWaveCreatedEventArgs([oscillator]));
        Check(Field<bool>(form, "hasWaveData"), "Creating a sound must establish active state.");

        SetField(form, "envelope", new Envelope(0, 0, 25, 0));
        Invoke(form, "OnSoundWaveModified", form, EventArgs.Empty);
        var processed = Field<List<(double, double)>>(form, "modifiedTimeDomainData");
        Check(processed.Max(point => Math.Abs(point.Item2)) <= 0.125 + 1e-12, "Effect must reach the cached playback/export data.");
        var expectedSpectrum = Utils.FastFourierTransform(processed, Field<int>(form, "samplingRate"));
        var combo = Field<ComboBox>(form, "plotComboBox");
        var view = Field<PlotView>(form, "frequencyDomainPlotView");
        for (int component = 0; component < 3; component++)
        {
            combo.SelectedIndex = component;
            var line = (LineSeries)view.Model.Series[0];
            Check(line.Points.Count == expectedSpectrum.Count, "Spectrum selection must retain the processed sound.");
            for (int i = 0; i < line.Points.Count; i++)
                Near(line.Points[i].Y, expectedSpectrum[i].Item2[component], 1e-9);
        }

        Invoke(form, "OnSoundWaveCleared", form, EventArgs.Empty);
        Check(Field<object?>(form, "timeDomainData") == null && Field<object?>(form, "modifiedTimeDomainData") == null && Field<object?>(form, "frequencyDomainData") == null, "Clear must discard source, processed samples and spectrum.");
        Check(!Field<ToolStripMenuItem>(form, "exportToolStripMenuItem").Enabled && !Field<Button>(form, "playButton").Enabled, "Clear must disable playback and export.");
    }

    private static byte[] BuildWav(short encoding, short bits, short channels, byte[] data, bool oddMetadata = false)
    {
        using var stream = new MemoryStream();
        using var writer = new BinaryWriter(stream, Encoding.ASCII, leaveOpen: true);
        writer.Write(Encoding.ASCII.GetBytes("RIFF"));
        writer.Write(0);
        writer.Write(Encoding.ASCII.GetBytes("WAVE"));
        if (oddMetadata)
            WriteChunk(writer, "JUNK", [1, 2, 3]);
        using var formatStream = new MemoryStream();
        using (var format = new BinaryWriter(formatStream, Encoding.ASCII, leaveOpen: true))
        {
            format.Write(encoding);
            format.Write(channels);
            format.Write(8000);
            format.Write(8000 * channels * bits / 8);
            format.Write((short)(channels * bits / 8));
            format.Write(bits);
        }
        WriteChunk(writer, "fmt ", formatStream.ToArray());
        if (oddMetadata)
            WriteChunk(writer, "LIST", [4, 5, 6]);
        WriteChunk(writer, "data", data);
        stream.Position = 4;
        writer.Write((int)stream.Length - 8);
        return stream.ToArray();
    }

    private static void WriteChunk(BinaryWriter writer, string name, byte[] bytes)
    {
        writer.Write(Encoding.ASCII.GetBytes(name));
        writer.Write(bytes.Length);
        writer.Write(bytes);
        if (bytes.Length % 2 != 0)
            writer.Write((byte)0);
    }

    private static void WithTemporaryFile(Action<string> action)
    {
        string path = Path.Combine(Path.GetTempPath(), $"BasicSynthesizer-regression-{Guid.NewGuid():N}.wav");
        try { action(path); }
        finally { if (File.Exists(path)) File.Delete(path); }
    }

    private static List<(double, double)> Points(double[] samples, int sampleRate, double offset = 0) =>
        samples.Select((value, index) => (offset + (double)index / sampleRate, value)).ToList();

    private static void CompareOverloads(double[] input, double[] expected, List<(double, double)> actual)
    {
        Check(actual.Count == input.Length, "Effect must retain the input sample count.");
        Near(actual[0].Item1, 5);
        Compare(expected, actual.Select(point => point.Item2).ToArray());
    }

    private static void Compare(double[] expected, double[] actual, double tolerance = 1e-12)
    {
        Check(expected.Length == actual.Length, $"Expected {expected.Length} samples, got {actual.Length}.");
        for (int i = 0; i < expected.Length; i++)
            Near(actual[i], expected[i], tolerance);
    }

    private static void Near(double actual, double expected, double tolerance = 1e-12)
    {
        Check(double.IsFinite(actual) && Math.Abs(actual - expected) <= tolerance, $"Expected {expected:R}, got {actual:R} (tolerance {tolerance:R}).");
    }

    private static void Check(bool condition, string message)
    {
        if (!condition)
            throw new InvalidOperationException(message);
    }

    private static void Throws<TException>(Action action) where TException : Exception
    {
        try { action(); }
        catch (TException) { return; }
        throw new InvalidOperationException($"Expected {typeof(TException).Name}.");
    }

    private static T Field<T>(object instance, string name) =>
        (T)instance.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(instance)!;

    private static void SetField(object instance, string name, object? value) =>
        instance.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(instance, value);

    private static void Invoke(object instance, string name, params object[] arguments) =>
        instance.GetType().GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic)!.Invoke(instance, arguments);
}
