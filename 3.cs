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
     * Complete the 'biggerIsGreater' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING w as parameter.
     */

    public static string biggerIsGreater(string w)
    {
        char[] chars = w.ToCharArray();

        for (int i = 1; i < w.Length; i++)
        {
            int pivot = w.Length - 1 - i;

            if (chars[pivot] < chars[pivot + 1])
            {
                int j = w.Length - 1;

                while (chars[j] <= chars[pivot])
                {
                    j--;
                }

                char temp = chars[pivot];
                chars[pivot] = chars[j];
                chars[j] = temp;

                Array.Reverse(chars, pivot + 1, w.Length - pivot - 1);

                return new string(chars);
            }
        }

        return "no answer";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int T = Convert.ToInt32(Console.ReadLine().Trim());

        for (int TItr = 0; TItr < T; TItr++)
        {
            string w = Console.ReadLine();

            string result = Result.biggerIsGreater(w);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}