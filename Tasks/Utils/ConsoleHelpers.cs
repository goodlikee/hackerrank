using System;
using System.IO;

namespace Tasks.Utils
{
    public static class ConsoleHelpers
    {
        
        public static StreamRedirection RedirectInputFileToConsole(string path)
        {
            var stream = File.OpenRead(path);
            var reader = new StreamReader(stream);
            Console.SetIn(reader);

            return new StreamRedirection
            {
                Stream = stream,
                StreamReader = reader
            };
        }
    }
}