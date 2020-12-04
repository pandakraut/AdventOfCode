using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day3_2
    {
        static void Main(string[] args)
        {            

            var inputFile = File.ReadAllLines("../../../InputDay3.txt");
            var list = new List<string>(inputFile);

            int[,] slopes = new int[,] { { 1, 1 }, { 3, 1 }, { 5, 1 }, { 7, 1 }, { 1, 2 } };
            List<List<int>> progress = new List<List<int>>();            
            for (int i = 0; i < slopes.Length / 2; i++)
            {
                progress.Add(new List<int>(){ 0,0,0 });
            }

            long trees = findTrees(list, slopes, progress, '#');
            
            Console.WriteLine("output: " + trees);
        }

        public static long findTrees(List<string> list, int[,] slopes, List<List<int>> progress, char match)
        {
            long trees = 0;                                   
            int y = 0;
            int smallestY = 0;
            int currentY = 0;
            int currentX = 0;

            while (y < list.Count -1)
            {
                for (int i = 0; i < slopes.Length / 2; i++)
                {
                    //only process if next value to check is on current line
                    if (progress[i][1] == y)
                    {
                        //increment all x progress
                        progress[i][0] += slopes[i,0];
                        if (progress[i][0] >= list[y].Length)
                        {
                            progress[i][0] -= list[y].Length;
                        }
                        currentX = progress[i][0];

                        //increment all y progress
                        currentY = progress[i][1] += slopes[i, 1];
                        if (smallestY == 0 || smallestY > currentY)
                        {
                            smallestY = currentY;
                        }
                        if (currentY < list.Count)
                        {
                            //increment number of trees
                            if (list[currentY][currentX] == match)
                            {
                                progress[i][2]++;
                            }
                        }
                    }
                }
                y += smallestY;
            }

            trees = progress[0][2];
            for (int i = 1; i < slopes.Length / 2; i++)
            {
                trees *= progress[i][2];
            }
            return trees;
        }
    }
}
