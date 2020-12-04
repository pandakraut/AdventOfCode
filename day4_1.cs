using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day4_1
    {
        static void Main(string[] args)
        {
            int validPassports = 0;

            HashSet<string> requiredFields = new HashSet<string>()
            {
                "byr",
                "iyr",
                "eyr",
                "hgt",
                "hcl",
                "ecl",
                "pid"
            };

            int matches = 0;
            foreach (string line in File.ReadLines("../../../InputDay4.txt"))
            {
                if (line.Length == 0)
                {
                    if (matches >= requiredFields.Count)
                    {
                        validPassports++;                        
                    }
                    matches = 0;
                }
                else
                {                    
                    matches = processString(requiredFields, line, matches);
                }
            }

            //Account for no return at end of file
            if (matches >= requiredFields.Count)
            {
                validPassports++;
            }

            Console.WriteLine("output: " + validPassports);                        
        }

        public static int processString(HashSet<string> requiredFields, string line, int matches)
        {
            if (requiredFields.Contains(line.Substring(0, line.IndexOf(':'))))
            {
                matches++;
            }

            int nextIndex = line.IndexOf(' ');
            if (nextIndex > 0)
            {
                matches = processString(requiredFields, line.Remove(0, nextIndex + 1), matches);
            }            
            return matches;
        }        
    }
}
