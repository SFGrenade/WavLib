using System.IO;

namespace WavLib.SampleConverters;

public interface IConverter
{
    public float[] ConvertSamples(BinaryReader stream, int bytesPerSample);
}
