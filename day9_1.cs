using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day9_2
    {        
        public static HashSet<long> numbers = new HashSet<long>();
        public static List<long> numbersList = new List<long>();

        static void Main(string[] args)
        {
            bool valid;
            long current;

            foreach (string line in File.ReadLines("../../../InputDay9.txt"))
            {
                valid = false;
                current = long.Parse(line);                

                if (numbers.Count > 25)
                {
                    foreach (long checkSum in numbers)
                    {
                        long compare = current - checkSum;
                        if (compare > 0 && compare != checkSum)
                        {
                            if (numbers.Contains(compare))
                            {
                                valid = true;
                                numbers.Remove(numbersList[0]);
                                numbersList.RemoveAt(0);
                                break;
                            }
                        }
                    }
                    if (!valid)
                    {
                        Console.WriteLine("output: " + current);
                        break;
                    }
                }                
                numbers.Add(current);
                numbersList.Add(current);
            }
        }
    }
}