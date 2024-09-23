using System.Collections.Generic;
using System.IO;

namespace WavLib.SampleConverters;

/// <summary>
///     A converter for Ieee-float-encoded audio data
/// </summary>
public class IeeeFloatConverter : BaseConverter
{
    public IeeeFloatConverter(WavData wavData = null) : base(wavData)
    {
    }

    /// <summary>
    ///     Converts the binary samples into a float array
    /// </summary>
    /// <param name="stream">The binary samples</param>
    /// <param name="bytesPerSample">How many bytes each sample has</param>
    /// <returns>An array of floats between -1.0 and 1.0</returns>
    public override float[] ConvertSamples(BinaryReader stream, int bytesPerSample)
    {
        var ret = new List<float>();
        while (stream.BaseStream.Position < stream.BaseStream.Length) ret.Add(ConvertSample(stream, bytesPerSample));
        return ret.ToArray();
    }

    private static float ConvertSample(BinaryReader stream, int bytesPerSample)
    {
        if (4 == bytesPerSample) return stream.ReadSingle();
        if (8 == bytesPerSample) return (float)stream.ReadDouble();
        return 0.0f;
    }
}
