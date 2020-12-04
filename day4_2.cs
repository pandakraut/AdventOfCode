using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day4_2
    {
        public static HashSet<string> eyeColors = new HashSet<string>()
        {
            "amb",
            "blu",
            "brn",
            "gry",
            "grn",
            "hzl",
            "oth"
        };

        public static HashSet<string> requiredFields = new HashSet<string>()
        {
            "byr",
            "iyr",
            "eyr",
            "hgt",
            "hcl",
            "ecl",
            "pid"
        };

        static void Main(string[] args)
        {
            int validPassports = 0;           

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
                    matches = processString(line, matches);
                }
            }

            //Account for no return at end of file
            if (matches >= requiredFields.Count)
            {
                validPassports++;
            }

            Console.WriteLine("output: " + validPassports);                        
        }

        public static int processString(string line, int matches)
        {
            string type = line.Substring(0, line.IndexOf(':'));
            int nextIndex = line.IndexOf(' ');
            if (nextIndex < 0)
            {
                nextIndex = line.Length -1;
            }
            if (requiredFields.Contains(type))
            {
                if (validData(type, line.Substring(type.Length +1, nextIndex - type.Length).Trim()))
                { 
                    matches++;
                }
                else
                {
                    //invalid data, stop processing
                    return 0;
                }
            }

            nextIndex = line.IndexOf(' ');
            if (nextIndex > 0)
            {
                matches = processString(line.Remove(0, nextIndex + 1), matches);
            }            
            return matches;
        }

        public static bool validData(string type, string data)
        {
            bool valid = false;

            if (type == "byr")
            {
                //byr(Birth Year) - four digits; at least 1920 and at most 2002.
                valid = validateNumber(Int32.Parse(data), 1920, 2002);
            }
            else if (type == "iyr")
            {
                //iyr(Issue Year) - four digits; at least 2010 and at most 2020.
                valid = validateNumber(Int32.Parse(data), 2010, 2020);
            }
            else if (type == "eyr")
            {
                //eyr(Expiration Year) - four digits; at least 2020 and at most 2030.
                valid = validateNumber(Int32.Parse(data), 2020, 2030);
            }
            else if (type == "hgt")
            {
                //hgt(Height) - a number followed by either cm or in:
                int preSuffix = data.Length - 2;
                string endsWith = data.Substring(preSuffix);
                if (endsWith == "cm")
                {
                    //If cm, the number must be at least 150 and at most 193.                    
                    valid = validateNumber(Int32.Parse(data.Substring(0, preSuffix)), 150, 193);
                }
                else if (endsWith == "in")
                {
                    //If in, the number must be at least 59 and at most 76.
                    valid = validateNumber(Int32.Parse(data.Substring(0, preSuffix)), 59, 76);
                }
            }
            else if (type == "hcl")
            {
                //hcl(Hair Color) - a # followed by exactly six characters 0-9 or a-f.
                if (data.StartsWith('#') && data.Length == 7)
                {
                    valid = IsHex(data.Substring(1).ToCharArray());
                }
            }
            else if (type == "ecl")
            {
                //ecl(Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
                valid = eyeColors.Contains(data);
            }
            else if (type == "pid")
            {
                //pid(Passport ID) - a nine - digit number, including leading zeroes.
                if (data.Length == 9)
                {
                    valid = Int32.Parse(data) > 0;
                }                
            }
            return valid;
        }

        public static bool validateNumber(int data, int min, int max)
        {            
            if (data >= min && data <= max)
            {
                return true;
            }
            return false;
        }

        private static bool IsHex(char[] chars)
        {
            bool isHex;
            foreach (var c in chars)
            {
                isHex = ((c >= '0' && c <= '9') ||
                         (c >= 'a' && c <= 'f') ||
                         (c >= 'A' && c <= 'F'));

                if (!isHex)
                    return false;
            }
            return true;
        }
    }
}
