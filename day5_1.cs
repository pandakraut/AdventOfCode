using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day5_1
    {
        static void Main(string[] args)
        {

            var inputFile = File.ReadAllLines("../../../InputDay5.txt");
            var list = new List<string>(inputFile);

            int max = 0;
            int current = 0;

            foreach (string line in list)
            {
                current = Convert.ToInt32(line.Replace('B', '1').Replace('F', '0').Replace('R', '1').Replace('L', '0'),2);
                if (current > max)
                {
                    max = current;
                }
            }

            Console.WriteLine("output: " + max);
        }

    }
}
