using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace Tasks.Algorithms.Medium.ClimbingTheLeaderboard
{
    class Result
    {
        /*
         * Complete the 'climbingLeaderboard' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. INTEGER_ARRAY ranked
         *  2. INTEGER_ARRAY player
         */

        public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
        {
            var rankedS = new SortedList<int, int>(ranked.Distinct().ToDictionary(x => x));
            var userPositions = new List<int> { };
            foreach (var value in player)
            {
                if (rankedS.IndexOfKey(value) == -1)
                {
                    rankedS.Add(value, value);
                }

                userPositions.Add(rankedS.Count - rankedS.IndexOfKey(value));
            }

            return userPositions;
        }
    }

    class Solution
    {
        public static void Main2(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList()
                .Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

            int playerCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList()
                .Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

            List<int> result = Result.climbingLeaderboard(ranked, player);

            textWriter.WriteLine(String.Join("\n", result));

            textWriter.Flush();
            textWriter.Close();
        }
    }
}