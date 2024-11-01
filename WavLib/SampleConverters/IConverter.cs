using System.IO;

namespace WavLib.SampleConverters;

/// <summary>
///     A converter interface
/// </summary>
public interface IConverter
{
    /// <summary>
    ///     Converts the binary samples into a float array
    /// </summary>
    /// <param name="stream">The binary samples</param>
    /// <param name="bytesPerSample">How many bytes each sample has</param>
    /// <returns>An array of floats between -1.0 and 1.0</returns>
    public float[] ConvertSamples(BinaryReader stream, int bytesPerSample);
}
