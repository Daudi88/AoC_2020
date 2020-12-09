using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CustomCustoms
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Code\AdventOfCode\AoC_2020\CustomCustoms\input.txt";
            string[] input = File.ReadAllLines(path);
            Console.WriteLine($"The sum is {PartOne(input)}");
            Console.WriteLine($"The sum is {PartTwo(input)}");
            Console.ReadLine();
        }

        static int PartOne(string[] input)
        {
            List<string> groups = new List<string>();
            string group = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != "")
                    group += input[i];
                else
                {
                    groups.Add(group);
                    group = "";
                }
            }
            groups.Add(group);

            int sum = 0;
            for (int i = 0; i < groups.Count; i++)
            {
                char[] questions = groups[i].ToCharArray();
                questions = questions.Distinct().ToArray();
                sum += questions.Count();
            }
            return sum;
        }

        static int PartTwo(string[] input)
        {
            List<string> persons = new List<string>();
            List<List<string>> groups = new List<List<string>>();
            string person = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != "")
                {
                    person = input[i];
                    persons.Add(person);
                }
                else
                {
                    groups.Add(persons);
                    persons = new List<string>();
                }

            }
            groups.Add(persons);
            List<int> sums = new List<int>();
            
            // Går igenom varje grupp
            for (int i = 0; i < groups.Count; i++)
            {
                int sum = 0;
                // Går igenom varje varje bokstav i första personen
                for (int j = 0; j < groups[i][0].Length; j++)
                {
                    char letter = groups[i][0][j];
                    int ctr = 0;

                    // Går igenom varje person i gruppen
                    for (int k = 0; k < groups[i].Count; k++)
                    {
                        if (groups[i][k].Contains(letter))
                            ctr++;
                    }

                    if (ctr == groups[i].Count)
                        sum++;
                }
                sums.Add(sum);
            }
            return sums.Sum();
        }
    }
}
