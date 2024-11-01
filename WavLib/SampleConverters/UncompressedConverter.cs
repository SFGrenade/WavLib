using System.Collections.Generic;
using System.IO;

namespace WavLib.SampleConverters;

/// <summary>
/// A converter for uncompressed pcm audio data
/// </summary>
public class UncompressedConverter : IConverter
{
    /// <summary>
    /// Converts the binary samples into a float array
    /// </summary>
    /// <param name="stream">The binary samples</param>
    /// <param name="bytesPerSample">How many bytes each sample has</param>
    /// <returns>An array of floats between -1.0 and 1.0</returns>
    public float[] ConvertSamples(BinaryReader stream, int bytesPerSample)
    {
        List<float> ret = new List<float>();
        while (stream.BaseStream.Position < stream.BaseStream.Length)
        {
            ret.Add(ConvertSample(stream, bytesPerSample));
        }
        return ret.ToArray();
    }
    
    private static float ConvertSample(BinaryReader stream, int bytesPerSample)
    {
        float value = 0f;
        float maxValue = 1f;
        if (1 == bytesPerSample)
        {
            value = stream.ReadByte() - (byte.MaxValue / 2f);
            maxValue = byte.MaxValue / 2f;
        }
        if (2 == bytesPerSample)
        {
            value = stream.ReadInt16();
            maxValue = short.MaxValue;
        }
        if (3 == bytesPerSample)
        {
            value = stream.ReadByte() << 8;
            value = (int) value | (stream.ReadByte() << 16);
            value = (int) value | (stream.ReadByte() << 24);
            maxValue = int.MaxValue;
        }
        if (4 == bytesPerSample)
        {
            value = stream.ReadInt32();
            maxValue = int.MaxValue;
        }
        return value / maxValue;
    }
}
