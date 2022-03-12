using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace Tasks.Algorithms.Easy.DesignerPDFViewer
{
    class Result
    {
        /*
         * Complete the 'designerPdfViewer' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER_ARRAY h
         *  2. STRING word
         */

        public static int designerPdfViewer(List<int> h, string word)
        {
            var list = new Dictionary<char, int>();
            var range = Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char) c).ToList();
            for (var i = 0; i < range.Count; i++)
            {
                list.Add(range[i], h[i]);
            }

            var str = word.ToCharArray();
            var wordList = list.Where(x => str.Contains(x.Key)).Select(x => x.Value).ToList();
            return wordList.Max() * str.Length;
        }
    }

    class Solution
    {
        public static void Main2(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            List<int> h = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(hTemp => Convert.ToInt32(hTemp))
                .ToList();

            string word = Console.ReadLine();

            int result = Result.designerPdfViewer(h, word);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}