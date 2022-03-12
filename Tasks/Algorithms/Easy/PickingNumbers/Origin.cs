using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace Tasks.Algorithms.Easy.PickingNumbers
{
    class Result
    {
        /*
         * Complete the 'pickingNumbers' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY a as parameter.
         */

        public static int pickingNumbers(List<int> a)
        {
            var lengths = new Dictionary<string, int>() { };
            foreach (var k in a.Select((value, i) => new {i, value}))
            {
                var upKey = $"u{k.i}";
                var downKey = $"d{k.i}";
                lengths[upKey] = 0;
                lengths[downKey] = 0;
                foreach (var j in a.Select((value, i) => new {i, value}))
                {
                    switch (k.value - j.value)
                    {
                        case 0:
                            lengths[upKey]++;
                            lengths[downKey]++;
                            break;
                        case 1:
                            lengths[upKey]++;
                            break;
                        case -1:
                            lengths[downKey]++;
                            break;
                    }
                }
            }

            return lengths.Values.Max();
        }
    }

    class Solution
    {
        public static void Main2(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp))
                .ToList();

            int result = Result.pickingNumbers(a);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}