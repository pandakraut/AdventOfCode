using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day7_1
    {
        public static Dictionary<string, List<KeyValuePair<string, int>>> dict = new Dictionary<string, List<KeyValuePair<string,int>>>();
        public static string currentParent = "";
        public static int parentTotal = 0;
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

            Console.WriteLine("output: " + (findChildren("shiny gold") -1));
        }

        public static void processString(string line)
        {
            int nextComma = line.IndexOf(',');
            int number = 1;
            if (char.IsNumber(line[0]))
            {
                number = Int32.Parse(line[0].ToString());
                line = line.Remove(0, 1);
            }
            if (nextComma == -1)
            {                   
                addToDict(line.Trim(), number);
            }
            else
            {
                addToDict(line.Substring(0, nextComma -1).Trim(), number);
                processString(line.Remove(0, nextComma + 1));
            }
        }

        public static void addToDict(string line, int number)
        {
            if (!dict.ContainsKey(currentParent))
            {
                dict.Add(currentParent, new List<KeyValuePair<string, int>>() { new KeyValuePair<string, int>(line, number) });
            }
            else
            {
                dict[currentParent].Add(new KeyValuePair<string, int>(line, number));
            }
        }

        public static int findChildren(string line)
        {            
            int total = 0;
            int n = 0;
            if (line == "no other")
            {
                return 0;
            }
            else if (dict.ContainsKey(line))
            {
                foreach (KeyValuePair<string, int> child in dict[line])
                {
                    n++;
                    //only add 1 for the parent bag on first pass through it
                    if (n == 1)
                    {
                        total += (child.Value * findChildren(child.Key)) + 1;
                    }
                    else
                    {
                        total += (child.Value * findChildren(child.Key));
                    }
                }
            }
            return total;
        }
    }
}