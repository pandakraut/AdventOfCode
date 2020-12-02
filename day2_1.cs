using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day1_1
    {
        static void Main(string[] args)
        {
            string[] values;
            string[] range;
            int validPasswords = 0;            

            foreach (string line in File.ReadLines("../../../InputDay2.txt"))
            {
                values = line.Split(' ');
                range = values[0].Split('-');
                
                if (validPassword(values[2], values[1][0], Int32.Parse(range[0]), Int32.Parse(range[1])))
                {
                    validPasswords++;
                }
            }
            Console.WriteLine("output: " + validPasswords);
        }        

        public static bool validPassword(string input, char match, int min, int max)
        {
            bool valid = true;
            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == match)
                {
                    count++;
                    if (count > max)
                    {
                        valid = false;
                        break;
                    }
                }                
            }
            if (count < min)
            {
                valid = false;
            }
            return valid;
        }
    }
}
