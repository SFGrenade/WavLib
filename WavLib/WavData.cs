﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
    /// <param name="loggingCallback">Optional callback for logging information</param>
    public bool Parse(Stream stream, Action<string> loggingCallback = null)
    {
        BinaryReader br = new BinaryReader(stream);
        if (!MainChunk.Parse(br))
        {
            return false;
        }

        Chunk nextChunk = FormatChunk.PeekInfo(br);
        while (nextChunk.Id != FormatChunk.Id)
        {
            if (loggingCallback != null) loggingCallback($"Skipping chunk \"{nextChunk.Id}\" of size {nextChunk.Size}");
            br.ReadBytes(8 + (int) nextChunk.Size);
            nextChunk = FormatChunk.PeekInfo(br);
        }
        if (loggingCallback != null) loggingCallback($"Reading format chunk");
        FormatChunk.Parse(br);

        nextChunk = SoundDataChunk.PeekInfo(br);
        while (nextChunk.Id != SoundDataChunk.Id)
        {
            if (loggingCallback != null) loggingCallback($"Skipping chunk \"{nextChunk.Id}\" of size {nextChunk.Size}");
            br.ReadBytes(8 + (int) nextChunk.Size);
            nextChunk = SoundDataChunk.PeekInfo(br);
        }
        if (loggingCallback != null) loggingCallback($"Reading data chunk");
        SoundDataChunk.Parse(br);
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
        List<float> ret = new List<float>(rawSamples.Length / bytesPerSample);
        MemoryStream ms = new MemoryStream(rawSamples, 0, rawSamples.Length, false);
        BinaryReader br = new BinaryReader(ms);
        while (ms.Position < ms.Length)
        {
            if (FormatChunk.AudioFormat == Format.Uncompressed)
            {
                ret.Add(SampleConverters.UncompressedConverter.ConvertSample(br, bytesPerSample));
            }
        }
        br.Close();
        ms.Close();
        return ret.ToArray();
    }

    /// <summary>
    /// Inspects a wav file
    /// </summary>
    /// <param name="stream">The data stream</param>
    /// <param name="loggingCallback">Callback for logging information</param>
    public static void Inspect(Stream stream, Action<string> loggingCallback)
    {
        BinaryReader br = new BinaryReader(stream);

        RiffChunk mainHeader = new RiffChunk();
        mainHeader.Parse(br);

        Chunk nextChunk;
        while (br.BaseStream.Position < br.BaseStream.Length)
        {
            nextChunk = mainHeader.PeekInfo(br);
            if (loggingCallback != null) loggingCallback($"Chunk \"{nextChunk.Id}\" with size {nextChunk.Size}");
            if (nextChunk.Size < 0xFFF)
            {
                var bytes = br.ReadBytes(8 + (int) nextChunk.Size);
                if (loggingCallback != null) loggingCallback($"\tChunk data: " + string.Join(", ", bytes.Select(x => x.ToString("x2")).ToArray()));
            }
            else
            {
                br.ReadBytes(8 + (int) nextChunk.Size);
            }
        }
        br.BaseStream.Seek(0, SeekOrigin.Begin);
    }
}
