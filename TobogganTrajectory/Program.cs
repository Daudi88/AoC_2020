using System;
using System.IO;

namespace TobogganTrajectory
{
    struct Coordinates
    {
        public int x;
        public int y;

        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Code\AdventOfCode\AoC_2020\TobogganTrajectory\input.txt";
            string[] input = File.ReadAllLines(path);
            Console.WriteLine($"The trees encountered are: {PartOne(input)}");
            Console.WriteLine($"The trees encountered on each of the listed " +
                $"slopes multiplied are: {PartTwo(input)}");
            Console.ReadLine();

        }

        static int PartOne(string[] input)
        {
            
            Coordinates toboggan = new Coordinates(0, 0);
            toboggan.x = 0;
            toboggan.y = 0;
            int trees = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                toboggan.x += 3;
                toboggan.y += 1;
                if (input[toboggan.y][toboggan.x] == '#')
                    trees++;
                if (toboggan.x + 3 >= input[i].Length)
                    toboggan.x -= input[i].Length;
            }
            return trees;
        }

        static long PartTwo(string[] input)
        {
            int[] x = new int[] { 1, 3, 5, 7, 1 };
            int[] y = new int[] { 1, 1, 1, 1, 2 };
            int[] slopes = new int[5];

            for (int i = 0; i < 5; i++)
            {
                Coordinates toboggan = new Coordinates(0, 0);
                int trees = 0;
                for (int j = 0; j < input.Length - 1; j++)
                {
                    toboggan.x += x[i];
                    toboggan.y += y[i];
                    if (toboggan.y < input.Length)
                    {
                        if (input[toboggan.y][toboggan.x] == '#')
                            trees++;
                    }

                    if (toboggan.x + x[i] >= input[j].Length)
                        toboggan.x -= input[j].Length;
                }
                slopes[i] = trees;
            }
            long product = slopes[0];
            for (int i = 1; i < slopes.Length; i++)
            {
                product *= slopes[i];
            }
            return product;
        }
    }
}
