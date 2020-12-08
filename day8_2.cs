using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day8_2
    {
        public static List<KeyVal<string, int>> instructions = new List<KeyVal<string, int>>();
        public static HashSet<int> proccessedInstructions = new HashSet<int>();
        public static int acc;
        static void Main(string[] args)
        {            
            foreach (string line in File.ReadLines("../../../InputDay8.txt"))
            {
                instructions.Add(new KeyVal<string, int>(line.Substring(0, 3), Int32.Parse(line.Substring(3, line.Length - 3))));                
            }

            bool makeAttempt;
            foreach (KeyVal<string, int> checkSwitch in instructions)
            {
                string restore = checkSwitch.Instruction;
                makeAttempt = false;
                if (restore == "nop")
                {
                    checkSwitch.Instruction = "jmp";
                    makeAttempt = true;
                }
                else if (restore == "jmp")
                {
                    checkSwitch.Instruction = "nop";
                    makeAttempt = true;
                }

                if (makeAttempt)
                { 
                    if (AttemptBoot())
                    {
                        Console.WriteLine("output: " + acc);
                        break;
                    }
                    else
                    {
                        checkSwitch.Instruction = restore;
                    }
                }
            }            
        }

        public static bool AttemptBoot()
        {
            acc = 0;
            int step = 0;
            bool flag = true;
            
            while (flag && step < instructions.Count)
            {
                if (proccessedInstructions.Contains(step))
                {
                    flag = false;
                    proccessedInstructions.Clear();
                }
                else
                {
                    proccessedInstructions.Add(step);

                    string currentInstruction = instructions[step].Instruction;
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
            return flag;
        }

        public class KeyVal<Key, Val>
        {
            public Key Instruction { get; set; }
            public Val Value { get; set; }

            public KeyVal() { }

            public KeyVal(Key key, Val val)
            {
                this.Instruction = key;
                this.Value = val;
            }
        }
    }
}