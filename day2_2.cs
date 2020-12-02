using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day2_2
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

        public static bool validPassword(string input, char match, int first, int second)
        {
            bool valid = false;
            bool firstMatch = false;
            bool secondMatch = false;

            if (input[first - 1] == match)
            {
                firstMatch = true;
            }
            if (input[second - 1] == match)
            {
                secondMatch = true;
            }

            if ((firstMatch || secondMatch) && !(firstMatch && secondMatch))
            {
                valid = true;
            }
            return valid;
        }
    }
}
