using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace Tasks.Algorithms.Easy.SaveThePrisoner
{
    class Result
    {
        /*
         * Complete the 'saveThePrisoner' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. INTEGER m
         *  3. INTEGER s
         */

        public static int saveThePrisoner(int n, int m, int s)
        {
            var x = m % n;
            if (x == 0)
            {
                return s;
            }
 
            var num = x + s;
            var xx = num > s ? num - s - 1 : num + 1;
            return xx;
        }
    }

    class Solution
    {
        public static void Main2(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int t = Convert.ToInt32(Console.ReadLine().Trim());

            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

                int n = Convert.ToInt32(firstMultipleInput[0]);

                int m = Convert.ToInt32(firstMultipleInput[1]);

                int s = Convert.ToInt32(firstMultipleInput[2]);

                int result = Result.saveThePrisoner(n, m, s);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}