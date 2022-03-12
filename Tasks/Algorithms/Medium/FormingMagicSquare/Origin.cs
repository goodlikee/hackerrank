using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace Tasks.Algorithms.Medium.FormingMagicSquare
{
    class Result
    {
        /*
         * Complete the 'formingMagicSquare' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY s as parameter.
         */

        public static int formingMagicSquare(List<List<int>> s)
        {
            List<List<int>> magicSquares = new List<List<int>>()
            {
                new List<int>() {8, 1, 6, 3, 5, 7, 4, 9, 2},
                new List<int>() {6, 1, 8, 7, 5, 3, 2, 9, 4},
                new List<int>() {4, 9, 2, 3, 5, 7, 8, 1, 6},
                new List<int>() {2, 9, 4, 7, 5, 3, 6, 1, 8},
                new List<int>() {8, 3, 4, 1, 5, 9, 6, 7, 2},
                new List<int>() {4, 3, 8, 9, 5, 1, 2, 7, 6},
                new List<int>() {6, 7, 2, 1, 5, 9, 8, 3, 4},
                new List<int>() {2, 7, 6, 9, 5, 1, 4, 3, 8},
            };
            var list = new List<int>();
            s.ForEach(x => list.AddRange(x));

            var costs = new List<int>();
            foreach (var magicSquare in magicSquares)
            {
                var cost = 0;
                for (var i = 0; i < 9; i++)
                {
                    cost += Math.Abs(magicSquare[i] - list[i]);
                }

                costs.Add(cost);
            }

            return costs.Min();
        }
    }

    class Solution
    {
        public static void Main2(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            List<List<int>> s = new List<List<int>>();

            for (int i = 0; i < 3; i++)
            {
                s.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp))
                    .ToList());
            }

            int result = Result.formingMagicSquare(s);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}