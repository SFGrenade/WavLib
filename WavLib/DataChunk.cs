using System.IO;

namespace WavLib;

/// <summary>
/// The `data` sub chunk of WAVE RIFF data
/// </summary>
public class DataChunk : Chunk
{
    /// <summary>
    /// The samples of the data, between -1.0 and 1.0
    /// </summary>
    public byte[] Samples { get; protected set; } = new byte[0];

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
        Samples = stream.ReadBytes((int) Size);
        return true;
    }
}
