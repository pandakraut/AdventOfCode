using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day3_1
    {
        static void Main(string[] args)
        {            

            var inputFile = File.ReadAllLines("../../../InputDay3.txt");
            var list = new List<string>(inputFile);
            
            int trees = findTrees(list, 3, 1, '#');
            
            Console.WriteLine("output: " + trees);
        }

        public static int findTrees(List<string> list, int slopeX, int slopeY, char match)
        {
            int trees = 0;
            int x = 0;
            int y = 0;

            while (y < list.Count)
            {
                x += slopeX;                
                if (x >= list[y].Length)
                {
                    x -= list[y].Length;
                }

                y += slopeY;
                if (y >= list.Count)
                {
                    break;
                }
                else if (list[y][x] == match)
                {
                    trees++;
                }
            }
            return trees;
        }
    }
}
