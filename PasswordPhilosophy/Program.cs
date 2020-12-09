using System;
using System.IO;

namespace PasswordPhilosophy
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Code\AdventOfCode\AoC_2020\PasswordPhilosophy\input.txt";
            string[] input = File.ReadAllLines(path);
            Console.WriteLine(PartOne(input));
            Console.WriteLine(PartTwo(input));
            Console.ReadLine();

        }

        static int PartOne(string[] input)
        {
            string lowStr, highStr;
            int valid = 0;
            for (int i = 0; i < input.Length; i++)
            {
                lowStr = input[i].Substring(0, 2);
                if (lowStr.EndsWith('-'))
                    lowStr = lowStr[0..^1];
                int lowest = Convert.ToInt32(lowStr);

                if (lowest < 10)
                    highStr = input[i].Substring(2, 2).Trim();
                else
                    highStr = input[i].Substring(3, 2).Trim();
                
                int highest = Convert.ToInt32(highStr);
                string letter = input[i].Substring(input[i].IndexOf(':') - 1, 1);
                string password = input[i].Substring(input[i].IndexOf(':') + 2);
                int ctr = 0;

                for (int j = 0; j < password.Length; j++)
                {
                    if (password[j].ToString() == letter)
                        ctr++;
                }

                if (ctr >= lowest && ctr <= highest)
                    valid++;
            }
            return valid;
        }

        static int PartTwo(string[] input)
        {
            string firstPosString = "";
            string secondPosString = "";
            int valid = 0;
            for (int i = 0; i < input.Length; i++)
            {
                firstPosString = input[i].Substring(0, 2);
                if (firstPosString.EndsWith('-'))
                    firstPosString = firstPosString[0..^1];
                int firstPosition = Convert.ToInt32(firstPosString);

                if (firstPosition < 10)
                    secondPosString = input[i].Substring(2, 2).Trim();
                else
                    secondPosString = input[i].Substring(3, 2).Trim();
                int secondPosition = Convert.ToInt32(secondPosString);

                string letter = input[i].Substring(input[i].IndexOf(':') - 1, 1);
                string password = input[i].Substring(input[i].IndexOf(':') + 2);

                if (password[firstPosition - 1].ToString() == letter
                    && password[secondPosition - 1].ToString() != letter
                    || password[secondPosition - 1].ToString() == letter
                    && password[firstPosition - 1].ToString() != letter)
                    valid++;
            }
            return valid;
        }
    }
}
