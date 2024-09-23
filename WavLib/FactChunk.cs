using System.IO;

namespace WavLib;

/// <summary>
///     The `fact` sub chunk of WAVE RIFF data
/// </summary>
public class FactChunk : Chunk
{
    private uint _amountTotalSamples;

    /// <summary>
    ///     Constructor of the fact chunk
    /// </summary>
    public FactChunk() : base("fact")
    {
    }

    /// <summary>
    ///     The total amount of samples per channel in the audio file
    /// </summary>
    public uint AmountTotalSamples
    {
        get => _amountTotalSamples;
        set
        {
            _amountTotalSamples = value;
            Size = sizeof(uint); // AmountTotalSamples
        }
    }

    /// <summary>
    ///     Parses information out of the chunkData
    /// </summary>
    /// <param name="stream">The data stream</param>
    /// <returns>Indication whether or not the parsing was successful</returns>
    public override bool Parse(BinaryReader stream)
    {
        if (!base.Parse(stream)) return false;
        _amountTotalSamples = stream.ReadUInt32();
        return true;
    }
}
