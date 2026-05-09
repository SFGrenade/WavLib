using System;
using System.IO;
using WavLib;

namespace TestApplication;

internal static class Program
{
    private static int CheckAudioFile(string filename, Format format, ushort channels, uint sampleRate, uint byteRate, ushort blockAlign, ushort bitsPerSample, ushort extraParamSize, float firstSample, float secondSample)
    {
        var wavStream = File.OpenRead($"./Wave-Files/{filename}.wav");
        var wavData = new WavData();
        var result = wavData.Parse(wavStream);
        if (!result) return -1;
        if (wavData.FormatChunk.AudioFormat != format) return -2;
        if (wavData.FormatChunk.NumChannels != channels) return -3;
        if (wavData.FormatChunk.SampleRate != sampleRate) return -4;
        if (wavData.FormatChunk.ByteRate != byteRate) return -5;
        if (wavData.FormatChunk.BlockAlign != blockAlign) return -6;
        if (wavData.FormatChunk.BitsPerSample != bitsPerSample) return -7;
        if (wavData.FormatChunk.ExtraParamSize != extraParamSize) return -8;
        var wavSound = wavData.GetSamples();
        // Console.WriteLine($"File: {wavSound[0]} <=> Reference: {firstSample}");
        if ((wavSound[0] != firstSample) || ((float.IsNaN(wavSound[0]) != float.IsNaN(firstSample)) || (float.IsPositiveInfinity(wavSound[0]) != float.IsPositiveInfinity(firstSample)) || (float.IsNegativeInfinity(wavSound[0]) != float.IsNegativeInfinity(firstSample)))) return -9;
        // Console.WriteLine($"File: {wavSound[1]} <=> Reference: {secondSample}");
        if ((wavSound[1] != secondSample) || ((float.IsNaN(wavSound[1]) != float.IsNaN(secondSample)) || (float.IsPositiveInfinity(wavSound[1]) != float.IsPositiveInfinity(secondSample)) || (float.IsNegativeInfinity(wavSound[1]) != float.IsNegativeInfinity(secondSample)))) return -10;
        return 0;
    }

    public static void Main()
    {
        Console.WriteLine("Test 1: {0}: {1}", "pcm-1ch-1000hz-1bit", CheckAudioFile("pcm-1ch-1000hz-1bit", Format.Uncompressed, 1, 1000, 1000, 1, 1, 0, -1f, (float)((2.0 * (128.0 / 255.0)) - 1.0)).GetHashCode());
        Console.WriteLine("Test 2: {0}: {1}", "pcm-1ch-1000hz-9bit", CheckAudioFile("pcm-1ch-1000hz-9bit", Format.Uncompressed, 1, 1000, 2000, 2, 9, 0, -1f, (float)(((double)0b0111_1111_1000_0000) / (Math.Pow(256.0, 2.0) / 2.0))).GetHashCode());
        Console.WriteLine("Test 3: {0}: {1}", "pcm-highest", CheckAudioFile("pcm-highest", Format.Uncompressed, 0xFFFF, 0xFFFFFFFF, (uint)(0xFFFF * (double)0xFFFFFFFF * Math.Ceiling(0xFFFF / 8.0)), (ushort)(0xFFFF * Math.Ceiling(0xFFFF / 8.0)), 0xFFFF, 0, (float)(0.0 / (Math.Pow(256.0, Math.Ceiling(0xFFFF / 8.0)) / 2.0)), (float)(0.0 / (Math.Pow(256.0, Math.Ceiling(0xFFFF / 8.0)) / 2.0))).GetHashCode());
        Console.WriteLine("Test 4: {0}: {1}", "hk_silksong_ui_titlecard_pt_1", CheckAudioFile("hk_silksong_ui_titlecard_pt_1", Format.Uncompressed, 2, 44100, 176400, 4, 16, 0, (float)(0), (float)(-11.0 / (Math.Pow(256.0, Math.Ceiling(16.0 / 8.0)) / 2.0))).GetHashCode());
    }
}
