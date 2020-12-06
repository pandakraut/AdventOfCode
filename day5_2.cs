using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day5_2
    {
        static void Main(string[] args)
        {

            var inputFile = File.ReadAllLines("../../../InputDay5.txt");
            var list = new List<string>(inputFile);
            List<int> valueList = new List<int>(list.Count);

            int current = 0;
            foreach (string line in list)
            {
                current = Convert.ToInt32(line.Replace('B', '1').Replace('F', '0').Replace('R', '1').Replace('L', '0'),2);
                valueList.Add(current);
            }
            valueList.Sort();

            int previous = 0;
            foreach (int value in valueList)
            {
                if (previous != 0)
                {
                    if (value - previous > 1)
                    {
                        Console.WriteLine("output: " + (value - 1)); ;
                        break;
                    }                   
                }                
                previous = value;                
            }
        }

    }
}
