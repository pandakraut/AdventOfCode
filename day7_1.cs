using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day6_1
    {
        public static Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
        public static string currentParent = "";
        public static int sumBags = 0;
        public static HashSet<string> countedBags = new HashSet<string>();

        static void Main(string[] args)
        {
            
            string[] split;
            
            foreach (string line in File.ReadLines("../../../InputDay7.txt"))
            {
                split = line.Replace("contain", ":").Replace("bags", "").Replace("bag", "").Replace(".", "").Split(':');
                currentParent = split[0].Trim();
                processString(split[1].Trim());                
            }

            findParents("shiny gold");

            Console.WriteLine("output: " + sumBags);
        }

        public static void processString(string line)
        {
            int nextComma = line.IndexOf(',');
            if (char.IsNumber(line[0]))
            {
                line = line.Remove(0, 1);
            }
            if (nextComma == -1)
            {                   
                addToDict(line.Trim());
            }
            else
            {
                addToDict(line.Substring(0, nextComma -1).Trim());
                processString(line.Remove(0, nextComma + 1));
            }
        }

        public static void addToDict(string line)
        {
            if (!dict.ContainsKey(line))
            {
                dict.Add(line, new List<string>() { currentParent });
            }
            else
            {
                dict[line].Add(currentParent);
            }
        }

        public static void findParents(string line)
        {
            if (dict.ContainsKey(line))
            { 
                foreach (string parent in dict[line])
                {
                    if (!countedBags.Contains(parent))
                    {
                        countedBags.Add(parent);
                        sumBags++;
                    }                    
                    findParents(parent);
                }
            }
        }
    }
}