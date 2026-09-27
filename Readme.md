# Basic Synthesizer

A simple GUI software with basic components of a synthesizer.
- Oscillators
- Filter
- Low-frequency oscillator
- Envelope

![Main window](/Images/MainInterface.png)

## Build and run

Use Windows and the .NET 10 SDK:

```powershell
dotnet restore BasicSynthesizer.csproj
dotnet build BasicSynthesizer.csproj -c Release
dotnet run --project BasicSynthesizer.csproj
```

The project uses SDK-style `PackageReference` dependencies. The old
`packages.config` and .NET Framework `App.config` are legacy files, not the
dependency or runtime configuration for this build.

## Audio behavior

- Oscillators are mixed by their relative weights. All-zero weights produce silence.
- Effects run in order: filter, LFO, ADSR, followed by clipping to the audio range.
  The waveform, spectrum, playback and WAV export use the same processed samples
  (export additionally quantizes to its PCM bit depth).
- LFO amplitude controls modulation depth: zero leaves the signal unchanged.
- Spectrum modes display normalized single-sided magnitude, real and imaginary
  components up to 4 kHz or Nyquist, whichever is lower.
- WAV import accepts mono or stereo PCM and floating-point audio, including
  metadata chunks. Stereo import lets you choose a channel. Canceling import
  preserves the current sound. Imported frame counts determine duration exactly.
- Imported sample rates such as 48 kHz are retained. WAV export is mono PCM:
  8/16-bit PCM input retains its depth; higher-precision input exports as 32-bit PCM.

## Regression checks

```powershell
dotnet run --project Tests/BasicSynthesizer.RegressionTests.csproj -c Release
```

This console regression suite runs without an audio device and checks DSP edge
cases, WAV encoding/decoding, FFT values and WinForms control state.

For an audible smoke test, add an oscillator, apply each effect, play, replay,
clear during playback, and close during playback. Export a sound and reimport it;
also try canceling stereo-channel selection while another sound is loaded.

## Remaining limitations

Processing and plotting still run on the UI thread and keep the full sound in
memory. Large WAV files can take time and memory to process. Square, triangle and
sawtooth oscillators are sampled directly and can alias at high frequencies.
Background rendering, streaming long files and band-limited oscillators would be
useful follow-up improvements. The existing Accord/DirectSound audio backend is
retained; hardware playback needs a listening test on the target PC.
