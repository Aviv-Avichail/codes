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
    static string ToWords(int n, string[] numbers)
    {
        if (n < 20)
            return numbers[n];

        if (n == 20)
            return "twenty";

        return "twenty " + numbers[n - 20];
    }

    public static string timeInWords(int h, int m)
    {
        /*
     * Complete the 'timeInWords' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER h
     *  2. INTEGER m
     */
        string[] numbers = {
            "zero", "one", "two", "three", "four",
            "five", "six", "seven", "eight", "nine",
            "ten", "eleven", "twelve", "thirteen",
            "fourteen", "fifteen", "sixteen",
            "seventeen", "eighteen", "nineteen"
        };

        StringBuilder s = new StringBuilder();

        if (m == 0)
        {
            s.Append(numbers[h]);
            s.Append(" o' clock");
            return s.ToString();
        }

        bool past = m <= 30;
        int minutes = past ? m : 60 - m;
        int hour = past ? h : h % 12 + 1;

        if (minutes == 15)
            s.Append("quarter");
        else if (minutes == 30)
            s.Append("half");
        else
        {
            s.Append(ToWords(minutes, numbers));

            if (minutes == 1)
                s.Append(" minute");
            else
                s.Append(" minutes");
        }

        if (past)
            s.Append(" past ");
        else
            s.Append(" to ");

        s.Append(numbers[hour]);

        return s.ToString();
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int h = Convert.ToInt32(Console.ReadLine().Trim());

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.timeInWords(h, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
