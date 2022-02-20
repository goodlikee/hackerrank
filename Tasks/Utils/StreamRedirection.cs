using System;
using System.IO;

namespace Tasks.Utils
{
    public class StreamRedirection: IDisposable 
    {
        public Stream Stream { get; init; }
        public StreamReader StreamReader { get; init; }

        public void Dispose()
        {
            Stream.Dispose();
            StreamReader.Dispose();
        }
    }
}