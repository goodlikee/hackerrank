using System.IO;
using System;
using System.Collections.Generic;

class Result
{
    static HashSet<char> Numbers = new HashSet<char>("0123456789");
    static HashSet<char> LowerCase = new HashSet<char>("abcdefghijklmnopqrstuvwxyz");
    static HashSet<char> UpperCase = new HashSet<char>("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
    static HashSet<char> SpecialCharacters = new HashSet<char>("!@#$%^&*()-+");
    
    /*
     * Complete the 'minimumNumber' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. STRING password
     */

    public static int MinimumNumber(int n, string password)
    {
        byte hasNumber = 0;
        byte hasLowerCase = 0;
        byte hasUpperCase = 0;
        byte hasSpecial = 0;
        
        foreach (var character in password)
        {
            if (Numbers.Contains(character))
            {
                hasNumber = 1;
                continue;
            }

            if (LowerCase.Contains(character))
            {
                hasLowerCase = 1;
                continue;
            }
            
            if (UpperCase.Contains(character))
            {
                hasUpperCase = 1;
                continue;
            }
            
            if (SpecialCharacters.Contains(character))
            {
                hasSpecial = 1;
                continue;
            }
        }
        
        // Return the minimum number of characters to make the password strong
        var groupCharactersNeeded = 4 - hasNumber - hasLowerCase - hasUpperCase - hasSpecial;
        var sizeNeeded = 6 - n;
        return Math.Max(groupCharactersNeeded, sizeNeeded);
    }

}

class Solution
{
    public static void Main2(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());
        string password = Console.ReadLine();

        int answer = Result.MinimumNumber(n, password);

        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        textWriter.WriteLine(answer);

        textWriter.Flush();
        textWriter.Close();
    }
}