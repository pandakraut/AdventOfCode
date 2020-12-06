using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day6_1
    {
        public static List<char> questions = new List<char>(26);

        static void Main(string[] args)
        {
            int sumCounts = 0;

            foreach (string line in File.ReadLines("../../../InputDay6.txt"))
            {
                if (line.Length == 0)
                {
                    sumCounts += questions.Count;
                    questions.Clear();
                }
                else
                {
                    foreach (char c in line)
                    {
                        if (!questions.Contains(c))
                        {
                            questions.Add(c);
                        }
                    }
                }
            }

            //Account for no return at end of file
            sumCounts += questions.Count;

            Console.WriteLine("output: " + sumCounts);
        }
    }
}
