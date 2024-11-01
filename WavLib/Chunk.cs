using System;
using System.IO;
using System.Text;

namespace WavLib;

/// <summary>
///     General information for every RIFF chunk
/// </summary>
public class Chunk
{
    /// <summary>
    ///     Constructor of a chunk
    /// </summary>
    /// <param name="id">The 4 character identifier</param>
    public Chunk(string id)
    {
        if (id.Length != 4) throw new ArgumentException("ID has to have 4 characters!");
        Id = id;
    }

    /// <summary>
    ///     The 4 character identifier
    /// </summary>
    public string Id { get; private set; }

    /// <summary>
    ///     The size of the chunk
    /// </summary>
    public uint Size { get; protected set; }

    /// <summary>
    ///     Parses information out of the chunkData
    /// </summary>
    /// <param name="stream">The data stream</param>
    /// <returns>Indication whether or not the parsing was successful</returns>
    public virtual bool Parse(BinaryReader stream)
    {
        var ret = BitConverter.ToUInt32(Encoding.ASCII.GetBytes(Id), 0) == stream.ReadUInt32();
        Size = stream.ReadUInt32();
        return ret;
    }

    /// <summary>
    ///     Peeks into what the next chunk will be
    /// </summary>
    /// <param name="stream">The data stream</param>
    /// <returns>A chunk object that will be the next</returns>
    public static Chunk PeekInfo(BinaryReader stream)
    {
        var ret = new Chunk("    ") { Id = Encoding.ASCII.GetString(stream.ReadBytes(4)), Size = stream.ReadUInt32() };
        stream.BaseStream.Seek(-8, SeekOrigin.Current);
        return ret;
    }
}
