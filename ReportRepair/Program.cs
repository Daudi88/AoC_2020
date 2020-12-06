using System;
using System.IO;

namespace ReportRepair
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Code\AdventOfCode\AoC_2020\ReportRepair\input.txt";
            int[] input = Array.ConvertAll(File.ReadAllLines(path), int.Parse);

            Console.WriteLine(PartOne(input));
            Console.WriteLine(PartTwo(input));
            Console.ReadLine();
        }

        static int PartOne(int[] input)
        {
            int answer = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 1; j < input.Length; j++)
                {
                    if (input[i] + input[j] == 2020)
                        answer = input[i] * input[j];
                }
            }
            return answer;
        }

        static int PartTwo(int[] input)
        {
            int answer = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 1; j < input.Length; j++)
                {
                    for (int k = 2; k < input.Length; k++)
                    {
                        if (input[i] + input[j] + input[k] == 2020)
                            answer = input[i] * input[j] * input[k];
                    }
                }
            }
            return answer;
        }
    }
}
