using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STQCGenerator
{
    public class WaveRecorder : IWaveProvider, IDisposable
    {
        private WaveFileWriter writer;
        private IWaveProvider source;
        public bool EnableWriter;

        /// <summary>
        /// Constructs a new WaveRecorder
        /// </summary>
        /// <param name="destination">The location to write the WAV file to</param>
        /// <param name="source">The source Wave Provider</param>
        public WaveRecorder(IWaveProvider source,bool enableWriter, string destination)
        {
            this.source = source;
            EnableWriter = enableWriter;
            if (EnableWriter)
            {
                this.writer = new WaveFileWriter(destination, source.WaveFormat);
            }
        }

        /// <summary>
        /// Read simply returns what the source returns, but writes to disk along the way
        /// </summary>
        public int Read(byte[] buffer, int offset, int count)
        {
            int bytesRead = source.Read(buffer, offset, count);
            if (EnableWriter)
                writer.Write(buffer, offset, bytesRead);
            return bytesRead;
        }

        /// <summary>
        /// The WaveFormat
        /// </summary>
        public WaveFormat WaveFormat
        {
            get { return source.WaveFormat; }
        }

        /// <summary>
        /// Closes the WAV file
        /// </summary>
        public void Dispose()
        {
            if (writer != null)
            {
                writer.Dispose();
                writer = null;
            }
        }
    }
}
