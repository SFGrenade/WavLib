using System.IO;

namespace WavLib;

/// <summary>
/// The `fmt ` sub chunk of WAVE RIFF data
/// </summary>
public class FmtChunk : Chunk
{
    /// <summary>
    /// The format of the audio data
    /// </summary>
    public Format AudioFormat { get; protected set; } = Format.Unknown;

    /// <summary>
    /// The amount of channels the audio data covers
    /// </summary>
    public ushort NumChannels { get; protected set; } = 0;

    /// <summary>
    /// The sample rate of the audio data
    /// </summary>
    public uint SampleRate { get; protected set; } = 0;

    /// <summary>
    /// `SampleRate * NumChannels * (BitsPerSample / 8)`
    /// </summary>
    public uint ByteRate { get; protected set; } = 0;

    /// <summary>
    /// `NumChannels * (BitsPerSample / 8)`
    /// </summary>
    public ushort BlockAlign { get; protected set; } = 0;

    /// <summary>
    /// The bit depth each sample has
    /// </summary>
    public ushort BitsPerSample { get; protected set; } = 0;

    /// <summary>
    /// Contains the amount of extra parameters.
    /// Not present when uncompressed format
    /// </summary>
    public ushort ExtraParamSize { get; protected set; } = 0;

    /// <summary>
    /// Contains the extra parameters.
    /// Not present when uncompressed format
    /// </summary>
    public byte[] ExtraParams { get; protected set; } = new byte[0];

    /// <summary>
    /// Constructor of the fmt chunk
    /// </summary>
    public FmtChunk() : base("fmt ")
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
        AudioFormat = (Format) stream.ReadUInt16();
        NumChannels = stream.ReadUInt16();
        SampleRate = stream.ReadUInt32();
        ByteRate = stream.ReadUInt32();
        BlockAlign = stream.ReadUInt16();
        BitsPerSample = stream.ReadUInt16();
        if ((AudioFormat != Format.Uncompressed) || (Size > 16))
        {
            ExtraParamSize = stream.ReadUInt16();
            ExtraParams = stream.ReadBytes(ExtraParamSize);
        }
        return true;
    }
}
