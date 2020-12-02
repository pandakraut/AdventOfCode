using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day1_1
    {
        static void Main(string[] args)
        {
            HashSet<int> set = new HashSet<int>();
         
            foreach (string line in File.ReadLines("../../../InputDay1_1.txt"))
            {
                int current = Int32.Parse(line);
                if (set.Count != 0 && set.Contains(2020-current))
                {
                    Console.WriteLine("output: " + current * (2020-current));
                    break;
                }                
                set.Add(current);
            }                                               
        }
        
    }
}
