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
     * Complete the 'matrixRotation' function below.
     *
     * The function accepts following parameters:
     *  1. 2D_INTEGER_ARRAY matrix
     *  2. INTEGER r
     */

    public static void matrixRotation(List<List<int>> matrix, int r)
    {
        int m = matrix.Count;
        int n = matrix[0].Count;

        int layers = Math.Min(m, n) / 2;

        for (int layer = 0; layer < layers; layer++)
        {
            int top = layer;
            int bottom = m - layer - 1;
            int left = layer;
            int right = n - layer - 1;

            List<(int row, int col)> positions =
                new List<(int row, int col)>();

            // Top edge
            for (int j = left; j <= right; j++)
                positions.Add((top, j));

            // Right edge
            for (int i = top + 1; i <= bottom; i++)
                positions.Add((i, right));

            // Bottom edge
            for (int j = right - 1; j >= left; j--)
                positions.Add((bottom, j));

            // Left edge
            for (int i = bottom - 1; i > top; i--)
                positions.Add((i, left));

            // Extract values
            List<int> values = new List<int>();

            foreach (var pos in positions)
                values.Add(matrix[pos.row][pos.col]);

            // Rotate anticlockwise
            int len = values.Count;
            int shift = r % len;

            for (int i = 0; i < len; i++)
            {
                var pos = positions[i];

                matrix[pos.row][pos.col] =
                    values[(i + shift) % len];
            }
        }

        // Print matrix
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int m = Convert.ToInt32(firstMultipleInput[0]);

        int n = Convert.ToInt32(firstMultipleInput[1]);

        int r = Convert.ToInt32(firstMultipleInput[2]);

        List<List<int>> matrix = new List<List<int>>();

        for (int i = 0; i < m; i++)
        {
            matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
        }

        Result.matrixRotation(matrix, r);
    }
}