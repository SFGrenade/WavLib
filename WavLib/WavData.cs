using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using WavLib.SampleConverters;

namespace WavLib;

/// <summary>
/// The entire RIFF WAVE data
/// </summary>
public class WavData
{
    /// <summary>
    /// The main riff chunk
    /// </summary>
    public RiffChunk MainChunk { get; } = new();

    /// <summary>
    /// The fact chunk
    /// </summary>
    public FactChunk FactChunk { get; } = new();

    /// <summary>
    /// The format chunk
    /// </summary>
    public FmtChunk FormatChunk { get; } = new();

    /// <summary>
    /// The sound data chunk
    /// </summary>
    public DataChunk SoundDataChunk { get; } = new();

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

        bool gotFormat = false;
        bool gotFact = false;
        bool gotData = false;
        Action<Chunk> checkChunks = (nextChunk) =>
        {
            if (nextChunk.Id == FormatChunk.Id)
            {
                gotFormat = true;
                loggingCallback?.Invoke("Reading format chunk");
                FormatChunk.Parse(br);
            }
            else if (nextChunk.Id == FactChunk.Id)
            {
                gotFact = true;
                loggingCallback?.Invoke("Reading fact chunk");
                FactChunk.Parse(br);
            }
            else if (nextChunk.Id == SoundDataChunk.Id)
            {
                gotData = true;
                loggingCallback?.Invoke("Reading data chunk");
                SoundDataChunk.Parse(br);
            }
            else
            {
                loggingCallback?.Invoke($"Skipping chunk \"{nextChunk.Id}\" of size {nextChunk.Size}");
                br.ReadBytes(8 + (int) nextChunk.Size);
            }
        };
        Chunk nextChunk = Chunk.PeekInfo(br);
        while (br.BaseStream.Position != br.BaseStream.Length)
        {
            checkChunks(nextChunk);
            nextChunk = Chunk.PeekInfo(br);
        }
        return gotFormat && gotData;
    }

    /// <summary>
    /// Returns the samples of the wav normalized between -1.0 and 1.0
    /// </summary>
    /// <returns>The samples</returns>
    public float[] GetSamples()
    {
        int bytesPerSample = FormatChunk.BitsPerSample / 8;
        byte[] rawSamples = SoundDataChunk.Samples;
        MemoryStream ms = new MemoryStream(rawSamples, 0, rawSamples.Length, false);
        BinaryReader br = new BinaryReader(ms);
        float[] ret = new float[0];

        Dictionary<Format, IConverter> converters = new Dictionary<Format, IConverter>
        {
            { Format.Uncompressed, new UncompressedConverter(this) },
            { Format.IeeeFloat, new IeeeFloatConverter(this) },
            { Format.Alaw, new AlawConverter(this) },
            { Format.Mulaw, new MulawConverter(this) },
            { Format.Extensible, new ExtensibleConverter(this) },
        };

        if (converters.ContainsKey(FormatChunk.AudioFormat))
        {
            ret = converters[FormatChunk.AudioFormat].ConvertSamples(br, bytesPerSample);
        }
        else
        {
            throw new DataException($"Format \"{FormatChunk.AudioFormat}\" is currently not supported!");
        }
        br.Close();
        ms.Close();
        return ret;
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

        while (br.BaseStream.Position < br.BaseStream.Length)
        {
            Chunk nextChunk = Chunk.PeekInfo(br);
            loggingCallback?.Invoke($"Chunk \"{nextChunk.Id}\" with size {nextChunk.Size}");
            if (nextChunk.Size < 0xFFF)
            {
                byte[] bytes = br.ReadBytes(8 + (int) nextChunk.Size);
                loggingCallback?.Invoke("\tChunk data: " + string.Join(", ", bytes.Select(x => x.ToString("x2")).ToArray()));
            }
            else
            {
                br.ReadBytes(8 + (int) nextChunk.Size);
            }
        }
        br.BaseStream.Seek(0, SeekOrigin.Begin);
    }
}
