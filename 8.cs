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
     * Complete the 'bomberMan' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. STRING_ARRAY grid
     */

    public static List<string> Explode(List<string> grid)
    {
        int rows = grid.Count;
        int cols = grid[0].Length;

        char[][] result = new char[rows][];

        // Start with a grid full of bombs
        for (int i = 0; i < rows; i++)
        {
            result[i] = new string('O', cols).ToCharArray();
        }

        // Explode bombs from the previous grid
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i][j] == 'O')
                {
                    result[i][j] = '.';

                    if (i > 0)
                        result[i - 1][j] = '.';

                    if (i < rows - 1)
                        result[i + 1][j] = '.';

                    if (j > 0)
                        result[i][j - 1] = '.';

                    if (j < cols - 1)
                        result[i][j + 1] = '.';
                }
            }
        }

        List<string> output = new List<string>();

        for (int i = 0; i < rows; i++)
        {
            output.Add(new string(result[i]));
        }

        return output;
    }

    public static List<string> bomberMan(int n, List<string> grid)
    {
        int rows = grid.Count;
        int cols = grid[0].Length;

        // First second: original grid
        if (n == 1)
            return grid;

        // Every even second: all cells have bombs
        if (n % 2 == 0)
        {
            List<string> full = new List<string>();

            for (int i = 0; i < rows; i++)
            {
                full.Add(new string('O', cols));
            }

            return full;
        }

        // First explosion pattern
        List<string> first = Explode(grid);

        if (n % 4 == 3)
            return first;

        // Second explosion pattern
        return Explode(first);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int r = Convert.ToInt32(firstMultipleInput[0]);

        int c = Convert.ToInt32(firstMultipleInput[1]);

        int n = Convert.ToInt32(firstMultipleInput[2]);

        List<string> grid = new List<string>();

        for (int i = 0; i < r; i++)
        {
            string gridItem = Console.ReadLine();
            grid.Add(gridItem);
        }

        List<string> result = Result.bomberMan(n, grid);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}