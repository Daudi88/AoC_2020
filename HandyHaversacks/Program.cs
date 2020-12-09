using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace HandyHaversacks
{
    class Bag
    {
        private string name;
        private int _value;
        private List<int> contain = new List<int>();
        private List<string> bags = new List<string>();
        public string Name { get => name; set => name = value; }
        public int Value { get => _value; set => _value = value; }
        public List<int> Contain { get => contain; set => contain = value; }
        public List<string> Bags { get => bags; set => bags = value; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Code\AdventOfCode\AoC_2020\HandyHaversacks\input.txt";
            string[] input = File.ReadAllLines(path);
            //Console.WriteLine($"{PartOne(input)} bag colors contain at least one shiny gold bag");
            Console.WriteLine($"{PartTwo(input)} individual bags are required inside my single shiny gold bag");

            Console.ReadLine();
        }

        static int PartOne(string[] input)
        {
            List<string> bags = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                string bag = input[i].Substring(0, input[i].IndexOf("bags")).Trim();
                if (input[i].Contains("shiny gold") && bag != "shiny gold")
                    bags.Add(bag);
            }

            int ctr;
            do
            {
                ctr = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    string bag = input[i].Substring(0, input[i].IndexOf("bags")).Trim();
                    for (int j = 0; j < bags.Count; j++)
                    {
                        if (input[i].Contains(bags[j]) && !bags.Contains(bag))
                        {
                            bags.Add(bag);
                            ctr++;
                            break;
                        }

                    }
                }

            } while (ctr > 0);

            foreach (var item in bags)
                Console.WriteLine(item);

            return bags.Count;
        }

        static int PartTwo(string[] input)
        {
            List<Bag> bags = new List<Bag>();
            int ctr;
            for (int i = 0; i < input.Length; i++)
            {
                string[] line = input[i].Split(' ');
                Bag bag = new Bag();
                bag.Name = line[0] + " " + line[1];
                bag.Value = 1;
                if (line[4] != "no")
                {
                    ctr = 3;
                    do
                    {
                        ctr++;
                        bag.Contain.Add(int.Parse(line[ctr++]));
                        bag.Bags.Add(line[ctr++] + " " + line[ctr++]);

                    } while (!line[ctr].EndsWith('.'));
                }
                bags.Add(bag);
            }

            List<Bag> finishedBags = bags.Where(bag => bag.Contain.Count == 0).ToList();
            bags = bags.Where(bag => bag.Contain.Count > 0).ToList();

            do
            {
                ctr = 0;
                for (int i = 0; i < finishedBags.Count; i++)
                {
                    for (int j = 0; j < bags.Count; j++)
                    {
                        if (bags[j].Bags.Contains(finishedBags[i].Name))
                        {
                            int index = bags[j].Bags.IndexOf(finishedBags[i].Name);
                            bags[j].Value += bags[j].Contain[index] * finishedBags[i].Value;
                            bags[j].Bags.RemoveAt(index);
                            bags[j].Contain.RemoveAt(index);
                            if (bags[j].Bags.Count == 0)
                            {
                                finishedBags.Add(bags[j]);
                                bags.RemoveAt(j);
                                ctr++;
                            }
                        }
                    }
                } 
            } while (ctr > 0);
            var myBag = finishedBags.Where(bag => bag.Name == "shiny gold").FirstOrDefault();
            return myBag.Value - 1;
        }
    }
}
