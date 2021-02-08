using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    class Day3
    {
        public void PartA()
        {
            string[] input = System.IO.File.ReadAllLines(@"C:\\dev\\AdventOfCode2020\\Inputfiles\\inputday3.txt");

            int right = 3;
            int down = 1;
            int rightIndex = right;

            var trees = 0;

            for (int row = down; row < input.Count(); row+= down)
            {
                var line = input[row];

                if (rightIndex >= line.Length)
                {
                    rightIndex = rightIndex - line.Length;
                }

                var block = line.Substring(rightIndex, 1);
                rightIndex += right;

                if (block.ToString().Equals("#"))
                {
                    trees++;
                }
            }
            Console.WriteLine("PartA {0} ", trees);

        }

        double CalcNumbOfTrees(int right, int down)
        {
            string[] input = System.IO.File.ReadAllLines(@"C:\\dev\\AdventOfCode2020\\Inputfiles\\inputday3.txt");

            int rightIndex = right;

            var trees = 0;

            for (int row = down; row < input.Count(); row += down)
            {
                var line = input[row];

                if (rightIndex >= line.Length)
                {
                    rightIndex = rightIndex - line.Length;
                }

                var block = line.Substring(rightIndex, 1);
                rightIndex += right;

                if (block.ToString().Equals("#"))
                {
                    trees++;
                }
            }
            return trees;
        }

        public void PartB()
        {
            double res = CalcNumbOfTrees(1, 1) * CalcNumbOfTrees(3, 1) * CalcNumbOfTrees(5, 1) * CalcNumbOfTrees(7, 1) * CalcNumbOfTrees(1, 2);
            Console.WriteLine("PartB {0} ", res);
        }

        public void Run()
        {
            PartA(); // 164
            PartB(); // 5007658656
        }
    }
}
