using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day9_2
    {        
        public static List<long> numbersList = new List<long>();

        static void Main(string[] args)
        {
            long current;
            long sum = 0;
            long invalidNumber = 776203571;
            //Test value 
            //long invalidNumber = 127;
            long result = 0;

            foreach (string line in File.ReadLines("../../../InputDay9.txt"))
            {
                current = long.Parse(line);
                sum += current;                

                while (sum > invalidNumber)
                {
                    sum -= numbersList[0];
                    if (sum == invalidNumber && numbersList.Count > 1)
                    {
                        numbersList.Sort();
                        //sort and output result
                        result = numbersList[0] + numbersList[numbersList.Count - 1];
                        break;
                    }
                    else if (numbersList.Count != 0)
                    { 
                        numbersList.RemoveAt(0);
                    }
                }
                if (result != 0)
                {
                    Console.WriteLine("output: " + result);
                    break;
                }
                numbersList.Add(current);
                
            }
        }
    }
}