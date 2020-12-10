using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day10_1
    {        
        public static List<int> numbersList = new List<int>();
        public static int oneJolt = 0;
        public static int threeJolt = 0;

        static void Main(string[] args)
        {
            int current;
            int previous = 0;

            foreach (string line in File.ReadLines("../../../InputDay10.txt"))
            {
                current = int.Parse(line);               
                numbersList.Add(current);                
            }
            numbersList.Sort();
            numbersList.Add(numbersList[numbersList.Count - 1] + 3);

            foreach(int adaptor in numbersList)
            {
                checkGap(adaptor - previous);
                previous = adaptor;
            }
            Console.WriteLine("output: " + oneJolt * threeJolt);

        }

        public static void checkGap(int gap)
        {
            if (gap == 1)
            {
                oneJolt++;
            }
            else if (gap == 3)
            {
                threeJolt++;
            }
        }
    }
}