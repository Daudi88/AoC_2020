using System;
using System.IO;
using System.Collections.Generic;

namespace BinaryBoarding
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Code\AdventOfCode\AoC_2020\BinaryBoarding\input.txt";
            string[] input = File.ReadAllLines(path);
            Console.WriteLine($"Highest ID is: {PartOne(input)}");
            Console.WriteLine($"Your seat has ID {PartTwo(input)}");
            Console.ReadLine();
        }

        static double PartOne(string[] input)
        {
            List<double> seatIDs = new List<double>();
            for (int i = 0; i < input.Length; i++)
            {
                string boardingPass = input[i];
                string firstSeven = boardingPass.Substring(0, 7);
                string lastThree = boardingPass.Substring(7);
                double min = 0;
                double max = 127;
                for (int j = 0; j < 7; j++)
                {
                    if (firstSeven[j] == 'F')
                        max -= Math.Ceiling((max - min) / 2);
                    else
                        min += Math.Ceiling((max - min) / 2);
                }
                double row = min;
                min = 0;
                max = 7;
                for (int j = 0; j < 3; j++)
                {
                    if (lastThree[j] == 'L')
                        max -= Math.Ceiling((max - min) / 2);
                    else
                        min += Math.Ceiling((max - min) / 2);
                }
                double column = min;
                double id = row * 8 + column;
                seatIDs.Add(id);
            }
            seatIDs.Sort();
            return seatIDs[^1];
        }

        static double PartTwo(string[] input)
        {
            List<double> seatIDs = new List<double>();
            for (int i = 0; i < input.Length; i++)
            {
                string boardingPass = input[i];
                string firstSeven = boardingPass.Substring(0, 7);
                string lastThree = boardingPass.Substring(7);
                double min = 0;
                double max = 127;
                for (int j = 0; j < 7; j++)
                {
                    if (firstSeven[j] == 'F')
                        max -= Math.Ceiling((max - min) / 2);
                    else
                        min += Math.Ceiling((max - min) / 2);
                }
                double row = min;
                min = 0;
                max = 7;
                for (int j = 0; j < 3; j++)
                {
                    if (lastThree[j] == 'L')
                        max -= Math.Ceiling((max - min) / 2);
                    else
                        min += Math.Ceiling((max - min) / 2);
                }
                double column = min;
                double id = row * 8 + column;
                seatIDs.Add(id);
            }
            seatIDs.Sort();
            double yourId = 0;
            for (int i = 2; i < seatIDs.Count; i++)
            {
                if (seatIDs[i] - 2 == seatIDs[i - 1])
                    yourId = seatIDs[i] - 1;
            }
            return yourId;
        }

        static void PartTwo()
        {

        }
    }
}
