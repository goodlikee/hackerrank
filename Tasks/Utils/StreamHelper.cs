using System;
using System.IO;

namespace Tasks.Utils
{
    public class StreamHelper
    {
        public static StreamRedirection Make(Stream stream)
        {
            var reader = new StreamReader(stream);
            return new StreamRedirection
            {
                Stream = stream,
                StreamReader = reader
            };
        }
    }
}