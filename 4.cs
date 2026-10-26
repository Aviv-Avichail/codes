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
     * Complete the 'lilysHomework' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int CountSwaps(List<int> arr, List<int> sorted)
    {
        List<int> a = new List<int>(arr);
        Dictionary<int, int> positions = new Dictionary<int, int>();

        for (int i = 0; i < a.Count; i++)
        {
            positions[a[i]] = i;
        }

        int count = 0;

        for (int i = 0; i < a.Count; i++)
        {
            if (a[i] == sorted[i])
                continue;

            int j = positions[sorted[i]];

            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;

            positions[a[j]] = j;
            positions[a[i]] = i;

            count++;
        }

        return count;
    }

    public static int lilysHomework(List<int> arr)
    {
        List<int> sorted = arr.OrderBy(x => x).ToList();

        int ascending = CountSwaps(arr, sorted);

        sorted.Reverse();

        int descending = CountSwaps(arr, sorted);

        return Math.Min(ascending, descending);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.lilysHomework(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}