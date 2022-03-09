using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace Tasks.Algorithms.Easy.CountingValleys
{
    class Result
    {
        private const char DOWN = 'D';
        /*
         * Complete the 'countingValleys' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER steps
         *  2. STRING path
         */

        public static int countingValleys(int steps, string path)
        {
            var currentSeaLevel = 0;
            var downhillCount = 0;
            var isStartDownhill = true;
            foreach (var _char in path.ToCharArray())
            {
                currentSeaLevel += _char == DOWN ? -1 : 1;
                if (isStartDownhill && currentSeaLevel == -1)
                {
                    downhillCount++;
                }
                else
                {
                    isStartDownhill = currentSeaLevel == 0;
                }
            }

            return downhillCount;
        }
    }

    class Solution
    {
        public static void Main2(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int steps = Convert.ToInt32(Console.ReadLine().Trim());

            string path = Console.ReadLine();

            int result = Result.countingValleys(steps, path);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}