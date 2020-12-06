using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day6_2
    {
        public static Dictionary<char, int> questions = new Dictionary<char, int>(26);

        static void Main(string[] args)
        {
            int sumCounts = 0;
            int groupSize = 0;

            foreach (string line in File.ReadLines("../../../InputDay6.txt"))
            {
                if (line.Length == 0)
                {
                    sumCounts += countAnswers(groupSize);
                    groupSize = 0;
                    questions.Clear();
                }
                else
                {
                    groupSize++;
                    foreach (char c in line)
                    {
                        if (!questions.ContainsKey(c))
                        {
                            questions.Add(c,1);
                        }
                        else
                        {
                            questions[c]++;
                        }
                    }
                }
            }

            //Account for no return at end of file
            sumCounts += countAnswers(groupSize);

            Console.WriteLine("output: " + sumCounts);
        }

        public static int countAnswers(int groupSize)
        {
            int answers = 0;
            foreach (KeyValuePair<char, int> pair in questions)
            {
                if (pair.Value == groupSize)
                {
                    answers++;
                }
            }
            return answers;
        }
    }
}
