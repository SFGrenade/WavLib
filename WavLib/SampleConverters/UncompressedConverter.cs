namespace WavLib.SampleConverters;

public static class UncompressedConverter
{
    public static float ConvertSample(ref byte[] rawSamples, int offset, int bytesPerSample)
    {
        float value = 0.0f;
        float maxValue = 1.0f;
        if (1 == bytesPerSample)
        {
            value = (sbyte) rawSamples[offset + 0];
            maxValue = sbyte.MaxValue;
        }
        if (2 == bytesPerSample)
        {
            value = (short) (rawSamples[offset + 0] | (rawSamples[offset + 1] << 8));
            maxValue = short.MaxValue;
        }
        if (3 == bytesPerSample)
        {
            value = (int) ((rawSamples[offset + 0] << 8) | (rawSamples[offset + 1] << 16) | (rawSamples[offset + 2] << 24));
            maxValue = int.MaxValue;
        }
        if (4 == bytesPerSample)
        {
            value = (int) (rawSamples[offset + 0] | (rawSamples[offset + 1] << 8) | (rawSamples[offset + 2] << 16) | (rawSamples[offset + 3] << 24));
            maxValue = int.MaxValue;
        }
        return value / maxValue;
    }
}
