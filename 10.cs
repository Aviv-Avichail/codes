using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'legoBlocks' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER m
     */

    const long MOD = 1000000007;

    public static long Power(long a, int b)
    {
        long result = 1;

        while (b > 0)
        {
            if (b % 2 == 1)
                result = (result * a) % MOD;

            a = (a * a) % MOD;
            b /= 2;
        }

        return result;
    }

    public static int legoBlocks(int n, int m)
    {
        long[] row = new long[m + 1];
        long[] total = new long[m + 1];
        long[] solid = new long[m + 1];

        row[0] = 1;

        // Number of ways to build one row
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= 4; j++)
            {
                if (i - j >= 0)
                    row[i] = (row[i] + row[i - j]) % MOD;
            }
        }

        // Number of ways to build a wall
        // without considering vertical cracks
        for (int i = 1; i <= m; i++)
        {
            total[i] = Power(row[i], n);
        }

        // Remove walls with full vertical cracks
        for (int i = 1; i <= m; i++)
        {
            solid[i] = total[i];

            for (int j = 1; j < i; j++)
            {
                long invalid = (solid[j] * total[i - j]) % MOD;

                solid[i] = (solid[i] - invalid + MOD) % MOD;
            }
        }

        return (int)solid[m];
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            int result = Result.legoBlocks(n, m);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}