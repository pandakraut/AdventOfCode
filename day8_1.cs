using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day8_1
    {
        public static List<KeyValuePair<string, int>> instructions = new List<KeyValuePair<string, int>>();
        public static HashSet<int> proccessedInstructions = new HashSet<int>();

        static void Main(string[] args)
        {
            int acc = 0;
            bool flag = true;

            foreach (string line in File.ReadLines("../../../InputDay8.txt"))
            {
                instructions.Add(new KeyValuePair<string, int>(line.Substring(0, 3), Int32.Parse(line.Substring(3, line.Length - 3))));                
            }
            
            int step = 0;
            while (flag)
            {
                if (proccessedInstructions.Contains(step))
                {
                    flag = false;
                    Console.WriteLine("output: " + acc);
                }
                else
                {                
                    proccessedInstructions.Add(step);
                
                    string currentInstruction = instructions[step].Key;
                    int currentValue = instructions[step].Value;
                    if (currentInstruction == "nop")
                    {
                        step++;
                    }
                    else if (currentInstruction == "acc")
                    {
                        acc += currentValue;
                        step++;
                    }
                    else if (currentInstruction == "jmp")
                    {
                        step += currentValue;
                    }
                }
            }         
        }
    }
}