using System.IO;

namespace WavLib.SampleConverters;

public static class UncompressedConverter
{
    public static float ConvertSample(BinaryReader stream, int bytesPerSample)
    {
        float value = 0.0f;
        float maxValue = 1.0f;
        if (1 == bytesPerSample)
        {
            value = stream.ReadByte() - (byte.MaxValue / 2f);
            maxValue = byte.MaxValue / 2f;
        }
        if (2 == bytesPerSample)
        {
            value = stream.ReadInt16();
            maxValue = short.MaxValue;
        }
        if (3 == bytesPerSample)
        {
            value = stream.ReadInt16() << 8;
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
