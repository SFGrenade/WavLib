using System;
using System.IO;

namespace WavLib;

/// <summary>
///     The `fmt ` sub chunk of WAVE RIFF data
/// </summary>
public class FmtChunk : Chunk
{
    private Format _audioFormat = Format.Unknown;

    private ushort _bitsPerSample;

    private byte[] _extraParams = new byte[0];

    private ushort _extraParamSize;

    private ushort _numChannels;

    private uint _sampleRate;

    /// <summary>
    ///     Constructor of the fmt chunk
    /// </summary>
    public FmtChunk() : base("fmt ")
    {
    }

    /// <summary>
    ///     The format of the audio data
    /// </summary>
    public Format AudioFormat
    {
        get => _audioFormat;
        set
        {
            _audioFormat = value;
            Size = sizeof(ushort) // AudioFormat
                   + sizeof(ushort) // NumChannels
                   + sizeof(uint) // SampleRate
                   + sizeof(uint) // ByteRate
                   + sizeof(ushort) // BlockAlign
                   + sizeof(ushort); // BitsPerSample
            if (_audioFormat == Format.Uncompressed) return;
            // from what i know, only uncompressed pcm means no extra params, so when not pcm, we have to adjust for the extra params
            Size += (uint)sizeof(ushort) // ExtraParamSize
                    + _extraParamSize; // ExtraParams
        }
    }

    /// <summary>
    ///     The amount of channels the audio data covers
    /// </summary>
    public ushort NumChannels
    {
        get => _numChannels;
        set
        {
            _numChannels = value;
            ByteRate = (uint)(_numChannels * _sampleRate * (_bitsPerSample / 8));
            BlockAlign = (ushort)(_numChannels * (_bitsPerSample / 8));
        }
    }

    /// <summary>
    ///     The sample rate of the audio data
    /// </summary>
    public uint SampleRate
    {
        get => _sampleRate;
        set
        {
            _sampleRate = value;
            ByteRate = (uint)(_numChannels * _sampleRate * (_bitsPerSample / 8));
        }
    }

    /// <summary>
    ///     `SampleRate * NumChannels * (BitsPerSample / 8)`
    /// </summary>
    public uint ByteRate { get; private set; }

    /// <summary>
    ///     `NumChannels * (BitsPerSample / 8)`
    /// </summary>
    public ushort BlockAlign { get; private set; }

    /// <summary>
    ///     The bit depth each sample has
    /// </summary>
    public ushort BitsPerSample
    {
        get => _bitsPerSample;
        set
        {
            _bitsPerSample = value;
            ByteRate = (uint)(_numChannels * _sampleRate * (_bitsPerSample / 8));
            BlockAlign = (ushort)(_numChannels * (_bitsPerSample / 8));
        }
    }

    /// <summary>
    ///     Contains the amount of extra parameters.
    ///     Not present when uncompressed format
    /// </summary>
    public ushort ExtraParamSize
    {
        get => _extraParamSize;
        set
        {
            _extraParamSize = value;
            var tmp = _extraParams;
            _extraParams = new byte[_extraParamSize];
            Array.Copy(tmp, _extraParams, tmp.Length);
            for (var i = tmp.Length; i < _extraParamSize; i++) _extraParams[i] = default;
            Size = sizeof(ushort) // AudioFormat
                   + sizeof(ushort) // NumChannels
                   + sizeof(uint) // SampleRate
                   + sizeof(uint) // ByteRate
                   + sizeof(ushort) // BlockAlign
                   + sizeof(ushort) // BitsPerSample
                   + sizeof(ushort) // ExtraParamSize
                   + (uint)_extraParamSize; // ExtraParams
        }
    }

    /// <summary>
    ///     Contains the extra parameters.
    ///     Not present when uncompressed format
    /// </summary>
    public byte[] ExtraParams
    {
        get => _extraParams;
        set
        {
            _extraParams = value;
            _extraParamSize = (ushort)_extraParams.Length;
            Size = sizeof(ushort) // AudioFormat
                   + sizeof(ushort) // NumChannels
                   + sizeof(uint) // SampleRate
                   + sizeof(uint) // ByteRate
                   + sizeof(ushort) // BlockAlign
                   + sizeof(ushort) // BitsPerSample
                   + sizeof(ushort) // ExtraParamSize
                   + (uint)_extraParamSize; // ExtraParams
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
        _audioFormat = (Format)stream.ReadUInt16();
        _numChannels = stream.ReadUInt16();
        _sampleRate = stream.ReadUInt32();
        ByteRate = stream.ReadUInt32();
        BlockAlign = stream.ReadUInt16();
        _bitsPerSample = stream.ReadUInt16();
        if (AudioFormat == Format.Uncompressed && Size <= 16) return true;
        _extraParamSize = stream.ReadUInt16();
        _extraParams = stream.ReadBytes(_extraParamSize);
        return true;
    }
}
