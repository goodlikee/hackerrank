using System;
using System.IO;

namespace Tasks.Utils
{
    public static class ConsoleHelpers
    {
        private const string InputFileName = "Input.txt";
        public static StreamRedirection RedirectInputFileToConsole(Type type)
        {
            var stream = type.Assembly.GetManifestResourceStream($"{type.Namespace}.{InputFileName}");
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