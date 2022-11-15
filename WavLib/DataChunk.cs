using System.IO;

namespace WavLib;

/// <summary>
/// The `data` sub chunk of WAVE RIFF data
/// </summary>
public class DataChunk : Chunk
{
    private byte[] _samples;
    /// <summary>
    /// The samples of the data, between -1.0 and 1.0
    /// </summary>
    public byte[] Samples {
        get => _samples;
        set
        {
            _samples = value;
            Size = (uint) _samples.Length;
        }
    }

    /// <summary>
    /// Constructor of the data chunk
    /// </summary>
    public DataChunk() : base("data")
    {
    }

    /// <summary>
    /// Parses information out of the chunkData
    /// </summary>
    /// <param name="stream">The data stream</param>
    /// <returns>Indication whether or not the parsing was successful</returns>
    public override bool Parse(BinaryReader stream)
    {
        if (!base.Parse(stream)) return false;
        _samples = stream.ReadBytes((int) Size);
        return true;
    }
}
