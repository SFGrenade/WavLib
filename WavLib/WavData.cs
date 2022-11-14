using System.IO;

namespace WavLib;

/// <summary>
/// The entire RIFF WAVE data
/// </summary>
public class WavData
{
    /// <summary>
    /// The main riff chunk
    /// </summary>
    public RiffChunk MainChunk { get; private set; } = new();

    /// <summary>
    /// The format chunk
    /// </summary>
    public FmtChunk FormatChunk { get; private set; } = new();

    /// <summary>
    /// The sound data chunk
    /// </summary>
    public DataChunk SoundDataChunk { get; private set; } = new();

    /// <summary>
    /// Parses the byte data of a wav file into this class structure
    /// </summary>
    /// <param name="stream">The data stream</param>
    public bool Parse(Stream stream)
    {
        BinaryReader br = new BinaryReader(stream);
        if (!MainChunk.Parse(br))
        {
            return false;
        }
        while (!FormatChunk.Parse(br))
        {
        }
        while (!SoundDataChunk.Parse(br))
        {
        }
        return true;
    }

    /// <summary>
    /// Returns the samples of the wav normalized between -1.0 and 1.0
    /// </summary>
    /// <returns>The samples</returns>
    public float[] GetSamples()
    {
        int bytesPerSample = FormatChunk.BitsPerSample / 8;
        byte[] rawSamples = SoundDataChunk.Samples;
        float[] ret = new float[rawSamples.Length / bytesPerSample];
        int offset = 0;
        for (int i = 0; i < ret.Length; i++)
        {
            if (FormatChunk.AudioFormat == Format.Uncompressed)
            {
                ret[i] = SampleConverters.UncompressedConverter.ConvertSample(ref rawSamples, offset, bytesPerSample);
            }
            offset += bytesPerSample;
        }
        return ret;
    }
}
