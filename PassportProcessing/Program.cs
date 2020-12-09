using System;
using System.IO;
using System.Collections.Generic;

namespace PassportProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Code\AdventOfCode\AoC_2020\PassportProcessing\input.txt";
            string[] input = File.ReadAllLines(path);
            List<string> passports = GetPassports(input);
            Console.WriteLine($"There are {PartOne(passports)} valid passports.");
            Console.WriteLine($"There are {PartTwo(passports)} valid passports.");
            Console.ReadLine();


        }

        static List<string> GetPassports(string[] input)
        {
            List<string> passports = new List<string>();
            string passport = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != "")
                {
                    passport += input[i];
                    passport += " ";
                }
                else
                {
                    passports.Add(passport.TrimEnd());
                    passport = "";
                }
            }
            passports.Add(passport);
            return passports;
        }

        static int PartOne(List<string> passports)
        {
            int valid = 0;
            for (int i = 0; i < passports.Count; i++)
            {
                bool byr = false;
                bool iyr = false;
                bool eyr = false;
                bool hgt = false;
                bool hcl = false;
                bool ecl = false;
                bool pid = false;

                string[] fields = passports[i].Split(' ');
                for (int j = 0; j < fields.Length; j++)
                {
                    if (fields[j] != "")
                    {
                        string key = fields[j].Substring(0, fields[j].IndexOf(':'));
                        switch (key)
                        {
                            case "byr":
                                byr = true;
                                break;
                            case "iyr":
                                iyr = true;
                                break;
                            case "eyr":
                                eyr = true;
                                break;
                            case "hgt":
                                hgt = true;
                                break;
                            case "hcl":
                                hcl = true;
                                break;
                            case "ecl":
                                ecl = true;
                                break;
                            case "pid":
                                pid = true;
                                break;
                            default:
                                break;
                        }
                    }
                }
                if (byr && iyr && eyr && hgt && hcl && ecl && pid)
                    valid++;
            }
            return valid;
        }

        static int PartTwo(List<string> passports)
        {
            int valid = 0;
            for (int i = 0; i < passports.Count; i++)
            {
                bool byr = false;
                bool iyr = false;
                bool eyr = false;
                bool hgt = false;
                bool hcl = false;
                bool ecl = false;
                bool pid = false;

                string[] fields = passports[i].Split(' ');
                for (int j = 0; j < fields.Length; j++)
                {
                    if (fields[j] != "")
                    {
                        var key = fields[j].Substring(0, fields[j].IndexOf(':'));
                        var value = fields[j].Substring(fields[j].IndexOf(':') + 1);
                        switch (key)
                        {
                            case "byr":
                                int.TryParse(value, out int num);
                                if (num >= 1920 && num <= 2002)
                                    byr = true;
                                break;
                            case "iyr":
                                int.TryParse(value, out num);
                                if (num >= 2010 && num <= 2020)
                                    iyr = true;
                                break;
                            case "eyr":
                                int.TryParse(value, out num);
                                if (num >= 2020 && num <= 2030)
                                    eyr = true;
                                break;
                            case "hgt":
                                if (value.EndsWith("cm"))
                                {
                                    value = value[0..^2];
                                    int.TryParse(value, out num);
                                    if (num >= 150 && num <= 193)
                                        hgt = true;
                                }
                                else if (value.EndsWith("in"))
                                {
                                    value = value[0..^2];
                                    int.TryParse(value, out num);
                                    if (num >= 59 && num <= 76)
                                        hgt = true;
                                }
                                break;
                            case "hcl":
                                int ctr = 0;
                                if (value[0] == '#')
                                {
                                    for (int k = 1; k < value.Length; k++)
                                    {
                                        if (char.IsDigit(value[k]) || value[k] >= 'a' && value[k] <= 'f')
                                            ctr++;
                                    }
                                }
                                if (ctr == 6)
                                    hcl = true;
                                break;
                            case "ecl":
                                switch (value)
                                {
                                    case "amb":
                                    case "blu":
                                    case "brn":
                                    case "gry":
                                    case "grn":
                                    case "hzl":
                                    case "oth":
                                        ecl = true;
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "pid":
                                ctr = 0;
                                for (int k = 0; k < value.Length; k++)
                                {
                                    if (char.IsDigit(value[k]))
                                        ctr++;
                                }
                                if (ctr == 9)
                                    pid = true;
                                break;
                            default:
                                break;
                        }
                    }
                }
                if (byr && iyr && eyr && hgt && hcl && ecl && pid)
                    valid++;
            }

            return valid;
        }
    }
}
