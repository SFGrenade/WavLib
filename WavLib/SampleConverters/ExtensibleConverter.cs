using System;
using System.Collections.Generic;
using System.IO;

namespace WavLib.SampleConverters;

/// <summary>
///     A converter for uncompressed pcm audio data
/// </summary>
public class ExtensibleConverter : BaseConverter
{
    private uint _channelMask;
    private ArraySegment<byte> _guidInlcDataFormat;
    private ushort _validBitsPerSample;

    public ExtensibleConverter(WavData wavData = null) : base(wavData)
    {
        if (wavData.FormatChunk.ExtraParams.Length != 0)
        {
            _validBitsPerSample = BitConverter.ToUInt16(wavData.FormatChunk.ExtraParams, 0);
            _channelMask = BitConverter.ToUInt32(wavData.FormatChunk.ExtraParams, 2);
            _guidInlcDataFormat = new ArraySegment<byte>(wavData.FormatChunk.ExtraParams, 6, 16);
        }
    }

    /// <summary>
    ///     Converts the binary samples into a float array
    /// </summary>
    /// <param name="stream">The binary samples</param>
    /// <param name="bytesPerSample">How many bytes each sample has</param>
    /// <returns>An array of floats between -1.0 and 1.0</returns>
    public override float[] ConvertSamples(BinaryReader stream, int bytesPerSample)
    {
        var ret = new List<float>();
        while (stream.BaseStream.Position < stream.BaseStream.Length)
        {
            stream.ReadByte();
            ret.Add(ConvertSample(stream, bytesPerSample));
        }

        return ret.ToArray();
    }

    private static float ConvertSample(BinaryReader stream, int bytesPerSample)
    {
        var value = 0f;
        var maxValue = 1f;
        if (1 == bytesPerSample)
        {
            value = stream.ReadByte() - byte.MaxValue / 2f;
            maxValue = byte.MaxValue / 2f;
        }

        if (2 == bytesPerSample)
        {
            value = stream.ReadInt16();
            maxValue = short.MaxValue;
        }

        if (3 == bytesPerSample)
        {
            value = stream.ReadByte() << 8;
            value = (int) value | (stream.ReadByte() << 16);
            value = (int) value | (stream.ReadByte() << 24);
            maxValue = int.MaxValue;
        }

        if (4 == bytesPerSample)
        {
            value = stream.ReadInt32();
            maxValue = int.MaxValue;
        }

        return value / maxValue;
    }
}
