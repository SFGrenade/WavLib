using System;
using System.IO;
using System.Text;

namespace WavLib;

/// <summary>
/// The main chunk of the RIFF file format
/// </summary>
public class RiffChunk : Chunk
{
    /// <summary>
    /// The RIFF format
    /// </summary>
    public static string Format => "WAVE";

    /// <summary>
    /// Constructor of the data chunk
    /// </summary>
    public RiffChunk() : base("RIFF")
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
        return BitConverter.ToUInt32(Encoding.ASCII.GetBytes(Format), 0) == stream.ReadUInt32();
    }
}
