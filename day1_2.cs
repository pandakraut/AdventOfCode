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
            bool done = false;

            foreach (string line in File.ReadLines("../../../InputDay1_1.txt"))
            {
                int current = Int32.Parse(line);

                if (set.Count > 2)
                {
                    foreach (int prior in set)
                    {
                        int compare = 2020 - current - prior;
                        if (compare > 0 && set.Contains(compare))
                        {
                            Console.WriteLine("output: " + current * prior * compare);
                            done = true;
                            break;
                        }
                    }
                    
                }      
                if (!done)
                {
                    set.Add(current);
                }
                else
                {
                    break;
                }
            }                                               
        }        
    }
}
