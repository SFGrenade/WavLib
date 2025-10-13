using System;
using System.Collections.Generic;
using System.IO;

namespace WavLib.SampleConverters;

/// <summary>
///     A converter for uncompressed pcm audio data
/// </summary>
public class UncompressedConverter : BaseConverter
{
    public UncompressedConverter(WavData wavData = null) : base(wavData)
    {
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
        while (stream.BaseStream.Position < stream.BaseStream.Length) ret.Add(ConvertSample(stream, bytesPerSample));
        return ret.ToArray();
    }

    private static float ConvertSample(BinaryReader stream, int bytesPerSample)
    {
        double value = 0.0;
        double maxValue = 1.0;
        if (1 == bytesPerSample)
        {
            value = (2.0 * ((double)stream.ReadByte() / (double)byte.MaxValue)) - 1.0;
            maxValue = 1.0;
        }
        else
        {
            // >1 bytes per sample means we have signed integers which have max/2 as the maximum possible values (which is the negative direction)
            maxValue = Math.Pow(256.0, bytesPerSample) / 2.0;
            bool isNegative = false;
            for (uint byteOfSample = 0; byteOfSample < bytesPerSample; byteOfSample++)
            {
                byte valueOfByteOfSample = stream.ReadByte();
                if ((byteOfSample == (bytesPerSample - 1)) && ((valueOfByteOfSample & 0x80) == 0x80))
                {
                    // negative number in signed mode detected
                    isNegative = true;
                }
            }
            stream.BaseStream.Seek(-bytesPerSample, SeekOrigin.Current);
            value = 0;
            for (uint byteOfSample = 0; byteOfSample < bytesPerSample; byteOfSample++)
            {
                byte valueOfByteOfSample = stream.ReadByte();
                if (isNegative)
                    valueOfByteOfSample = (byte)(~valueOfByteOfSample);
                value += Math.Abs(valueOfByteOfSample) * Math.Pow(256.0, byteOfSample);
            }
            if (isNegative)
            {
                value = -value - 1;
            }
        }

        return (float)(value / maxValue);
    }
}
