using System;
using System.IO;
using System.Linq;
using WavLib;

namespace TestApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            FileStream wavStream = File.OpenRead("E:\\Music\\3. Eigenes\\PWAA - Cornered.wav");
            WavData wavData = new WavData();
            bool result = wavData.Parse(wavStream);
            Console.WriteLine($"Parsing \"{wavStream.Name}\" resulted in: {result}");
            if (result)
            {
                Console.WriteLine("Wav file information:");
                Console.WriteLine($"\tAudioFormat: {wavData.FormatChunk.AudioFormat}");
                Console.WriteLine($"\tNumChannels: {wavData.FormatChunk.NumChannels}");
                Console.WriteLine($"\tSampleRate: {wavData.FormatChunk.SampleRate}");
                Console.WriteLine($"\tByteRate: {wavData.FormatChunk.ByteRate}");
                Console.WriteLine($"\tBlockAlign: {wavData.FormatChunk.BlockAlign}");
                Console.WriteLine($"\tBitsPerSample: {wavData.FormatChunk.BitsPerSample}");
                Console.WriteLine($"\tExtraParamSize: {wavData.FormatChunk.ExtraParamSize}");
                float[] wavSound = wavData.GetSamples();
                Console.WriteLine($"\tSample Count: {wavSound.Length}");
                Console.Write("\tSamples: ");
                for (int i = 0; i < wavSound.Length; i++)
                {
                    if (wavSound[i] < 0.99f) continue;
                    Console.Write(wavSound[i].ToString("F3") + ", ");
                }
                Console.WriteLine();
            }
        }
    }
}
