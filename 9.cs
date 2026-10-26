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
     * Complete the 'maximumSum' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. LONG_INTEGER_ARRAY a
     *  2. LONG_INTEGER m
     */

    public static long maximumSum(List<long> a, long m)
    {
        long maxSum = 0;
        long prefix = 0;

        SortedSet<long> prefixes = new SortedSet<long>();
        prefixes.Add(0);

        foreach (long num in a)
        {
            prefix = (prefix + num % m) % m;

            maxSum = Math.Max(maxSum, prefix);

            // Find the smallest previous prefix
            // that is greater than the current prefix
            if (prefix < m - 1)
            {
                var greater = prefixes.GetViewBetween(
                    prefix + 1, m - 1
                );

                foreach (long next in greater)
                {
                    long current = (prefix - next + m) % m;
                    maxSum = Math.Max(maxSum, current);
                    break;
                }
            }

            prefixes.Add(prefix);

            if (maxSum == m - 1)
                break;
        }

        return maxSum;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            long m = Convert.ToInt64(firstMultipleInput[1]);

            List<long> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt64(aTemp)).ToList();

            long result = Result.maximumSum(a, m);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}