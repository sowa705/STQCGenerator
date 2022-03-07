using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STQCGenerator
{
    class SineWaveProvider : WaveProvider32
{
        int sample;
        public string sequence;
        int[] frequencies = new int[] { 980, 1197, 1446, 1795, 2105 };
        double time;

        public SineWaveProvider()
        {
            Volume = 0.25f; // let's not hurt our ears
        }
        public float TotalLength()
        {
            float t=0;
            for (int i = 0; i < sequence.Length; i++)
            {
                int f;
                if (int.TryParse(sequence[i].ToString(), out f))
                {
                    t += 0.1f;
                }
                else
                {
                    t += 0.2f;
                }
            }
            return t;
        }
        public float Volume { get; set; }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            int sampleRate = WaveFormat.SampleRate;

            for (int n = 0; n < sampleCount; n++)
            {
                time += 1 / (double)sampleRate;
                float frequency = 2;
                int index = 0;
                float t = 0;
                for (int i = 0; i < sequence.Length; i++)
                {
                    int f;
                    if (int.TryParse(sequence[i].ToString(), out f))
                    {
                        t += 0.1f;
                    }
                    else
                    {
                        t += 0.2f;
                    }
                    if (t > time)
                    {
                        index = i;
                        break;
                    }
                }

                int freqid;
                if (int.TryParse(sequence[index].ToString(), out freqid))
                {
                    frequency = frequencies[freqid];
                    Volume = 0.25f;
                }
                else
                {
                    Volume = 0;
                }

                buffer[n + offset] = (float)(Volume * Math.Sin((2 * Math.PI * sample * frequency) / sampleRate));
                sample++;
                if (sample >= sampleRate) sample = 0;
            }
            return sampleCount;
        }
    }
}
