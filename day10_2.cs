using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day10_2
    {        
        public static List<int> numbersList = new List<int>();
        public static HashSet<int> hash;
        public static Dictionary<int, long> pathResults = new Dictionary<int, long>();

        static void Main(string[] args)
        {
            int current;

            foreach (string line in File.ReadLines("../../../InputDay10.txt"))
            {
                current = int.Parse(line);               
                numbersList.Add(current);                
            }
            numbersList.Sort();
            numbersList.Add(numbersList[numbersList.Count - 1] + 3);
            hash = new HashSet<int>(numbersList);
            
            Console.WriteLine("output: " + checkAllPaths(0));

        }

        public static long checkAllPaths(int adaptor)
        {
            long result = 0;
            if (adaptor >= numbersList[numbersList.Count - 1])
            {
                return 1;
            }
            if (hash.Contains(adaptor + 1))
            {
                if (pathResults.ContainsKey(adaptor + 1))
                {
                    result += pathResults[adaptor + 1];
                }
                else
                {
                    long value = checkAllPaths(adaptor + 1);
                    pathResults.Add(adaptor + 1, value);                    
                    result += value;
                }                
            }
            if (hash.Contains(adaptor + 2))
            {
                if (pathResults.ContainsKey(adaptor + 2))
                {
                    result += pathResults[adaptor + 2];
                }
                else
                {
                    long value = checkAllPaths(adaptor + 2);
                    pathResults.Add(adaptor + 2, value);
                    result += value;
                }
            }
            if (hash.Contains(adaptor + 3))
            {
                if (pathResults.ContainsKey(adaptor + 3))
                {
                    result += pathResults[adaptor + 3];
                }
                else
                {
                    long value = checkAllPaths(adaptor + 3);
                    pathResults.Add(adaptor + 3, value);
                    result += value;
                }
            }
            return result;
        }
    }
}