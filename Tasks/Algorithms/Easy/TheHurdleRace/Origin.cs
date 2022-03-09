using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace Tasks.Algorithms.Easy.TheHurdleRace
{
    class Result
    {
        /*
         * Complete the 'hurdleRace' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER k
         *  2. INTEGER_ARRAY height
         */

        public static int hurdleRace(int k, List<int> height)
        {
            var max = height.Max();
            return max <= k ? 0 : max - k;
        }
    }

    class Solution
    {
        public static void Main2(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            List<int> height = Console.ReadLine().TrimEnd().Split(' ').ToList()
                .Select(heightTemp => Convert.ToInt32(heightTemp)).ToList();

            int result = Result.hurdleRace(k, height);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}