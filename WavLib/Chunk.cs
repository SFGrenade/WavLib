using System;
using System.IO;
using System.Text;

namespace WavLib;

/// <summary>
/// General information for every RIFF chunk
/// </summary>
public class Chunk
{
    /// <summary>
    /// The 4 character identifier
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// The size of the chunk
    /// </summary>
    public uint Size { get; protected set; } = 0;

    /// <summary>
    /// Constructor of a chunk
    /// </summary>
    /// <param name="id">The 4 character identifier</param>
    public Chunk(string id)
    {
        if (id.Length != 4) throw new ArgumentException("ID has to have 4 characters!");
        Id = id;
    }

    /// <summary>
    /// Parses information out of the chunkData
    /// </summary>
    /// <param name="stream">The data stream</param>
    /// <returns>Indication whether or not the parsing was successful</returns>
    public virtual bool Parse(BinaryReader stream)
    {
        bool ret = BitConverter.ToUInt32(Encoding.ASCII.GetBytes(Id), 0) == stream.ReadUInt32();
        Size = stream.ReadUInt32();
        return ret;
    }
}
