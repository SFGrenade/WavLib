using System;
using System.IO;
using WavLib;

namespace TestApplication;

internal static class Program
{
    public static void Main()
    {
        var wavStream = File.OpenRead("""E:\Downloads\dash.wav""");
        var wavData = new WavData();
        var result = wavData.Parse(wavStream, Console.WriteLine);
        Console.WriteLine($"Parsing \"{wavStream.Name}\" resulted in: {result}");
        if (!result) return;
        Console.WriteLine("Wav file information:");
        Console.WriteLine($"\tAudioFormat: {wavData.FormatChunk.AudioFormat}");
        Console.WriteLine($"\tNumChannels: {wavData.FormatChunk.NumChannels}");
        Console.WriteLine($"\tSampleRate: {wavData.FormatChunk.SampleRate}");
        Console.WriteLine($"\tByteRate: {wavData.FormatChunk.ByteRate}");
        Console.WriteLine($"\tBlockAlign: {wavData.FormatChunk.BlockAlign}");
        Console.WriteLine($"\tBitsPerSample: {wavData.FormatChunk.BitsPerSample}");
        Console.WriteLine($"\tExtraParamSize: {wavData.FormatChunk.ExtraParamSize}");
        var wavSound = wavData.GetSamples();
        Console.WriteLine($"\tSample Count: {wavSound.Length}");
        Console.Write("\tSamples: ");
        foreach (var sample in wavSound)
        {
            if (sample < 0.99f) continue;
            Console.Write(sample.ToString("F3") + ", ");
        }

        Console.WriteLine();
    }
}
