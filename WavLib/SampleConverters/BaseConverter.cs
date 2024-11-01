using System.IO;

namespace WavLib.SampleConverters;

/// <summary>
///     A converter base class
/// </summary>
public abstract class BaseConverter : IConverter
{
    protected WavData _wavData;

    public BaseConverter(WavData wavData = null)
    {
        _wavData = wavData;
    }

    public abstract float[] ConvertSamples(BinaryReader stream, int bytesPerSample);
}
