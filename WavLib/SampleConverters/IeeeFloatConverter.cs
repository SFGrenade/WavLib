using System.Collections.Generic;
using System.IO;

namespace WavLib.SampleConverters;

public class IeeeFloatConverter : IConverter
{
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
        if (4 == bytesPerSample)
        {
            return stream.ReadSingle();
        }
        if (8 == bytesPerSample)
        {
            return (float) stream.ReadDouble();
        }
        return 0.0f;
    }
}
