using System;
using System.Collections.Generic;
using System.IO;

namespace HandheldHalting
{
    class Program
    {
        class Instruction
        {
            public string Name { get; set; }
            public string Op { get; set; }
            public int Argument { get; set; }
            public bool IsVisited { get; set; }
        }

        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"C:\Code\AdventOfCode\AoC_2020\HandheldHalting\input.txt");
            //Console.WriteLine($"The value of the accumulator is {PartOne(input)}");
            Console.WriteLine($"The value of the accumulator is {PartTwo(input)}");
            Console.ReadLine();
        }

        static int PartOne(string[] input)
        {
            List<Instruction> instructions = GetInstructions(input);
            int accumulator = 0;
            int i = 0;
            while (i < instructions.Count)
            {
                if (!instructions[i].IsVisited)
                {
                    switch (instructions[i].Name)
                    {
                        case "acc":
                            instructions[i].IsVisited = true;
                            if (instructions[i].Op == "+")
                                accumulator += instructions[i].Argument;
                            else
                                accumulator -= instructions[i].Argument;
                            i++;
                            break;
                        case "jmp":
                            instructions[i].IsVisited = true;
                            if (instructions[i].Op == "+")
                                i += instructions[i].Argument;
                            else
                                i -= (instructions[i].Argument);
                            break;
                        case "nop":
                            instructions[i].IsVisited = true;
                            i++;
                            break;
                    }
                }
                else
                    break;
            }
            return accumulator;
        }

        static int PartTwo(string[] input)
        {
            List<Instruction> instructions = GetInstructions(input);
            int accumulator = 0;
            bool exit = false;
            int j = 0;
            do
            {
                for (int i = 0; i < instructions.Count; i++)
                {
                    accumulator = 0;
                    bool acc = false;
                    List<Instruction> tempList = GetInstructions(input);
                    switch (tempList[i].Name)
                    {
                        case "jmp":
                            tempList[i].Name = "nop";
                            break;
                        case "nop":
                            tempList[i].Name = "jmp";
                            break;
                        case "acc":
                            acc = true;
                            break;
                    }

                    j = 0;
                    while (j < tempList.Count && !acc)
                    {
                        if (!tempList[j].IsVisited)
                        {
                            switch (tempList[j].Name)
                            {
                                case "acc":
                                    tempList[j].IsVisited = true;
                                    if (tempList[j].Op == "+")
                                        accumulator += tempList[j].Argument;
                                    else
                                        accumulator -= tempList[j].Argument;
                                    j++;
                                    break;
                                case "jmp":
                                    tempList[j].IsVisited = true;
                                    if (tempList[j].Op == "+")
                                        j += tempList[j].Argument;
                                    else
                                        j -= tempList[j].Argument;
                                    break;
                                case "nop":
                                    tempList[j].IsVisited = true;
                                    j++;
                                    break;
                            }
                        }
                        else
                            break;
                    }
                    //Console.WriteLine(accumulator);
                    if (j == instructions.Count)
                    {
                        exit = true;
                        break;
                    }
                }
            } while (!exit);

            return accumulator;
        }

        static List<Instruction> GetInstructions(string[] input)
        {
            List<Instruction> instructions = new List<Instruction>();
            for (int i = 0; i < input.Length; i++)
            {
                Instruction instruction = new Instruction();
                instruction.Name = input[i].Substring(0, 3);
                instruction.Op = input[i].Substring(4, 1);
                instruction.Argument = Convert.ToInt32(input[i].Substring(5));
                instruction.IsVisited = false;
                instructions.Add(instruction);
            }
            return instructions;
        }
    }
}
