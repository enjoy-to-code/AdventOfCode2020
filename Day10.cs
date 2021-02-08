using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{

    class Day10
    {
        static string[] input = System.IO.File.ReadAllLines(@"C:\\dev\\AdventOfCode2020\\Inputfiles\\inputday10.txt");
        List<int> inputData = new List<int>();
        int diff1 = 0, diff3 = 0, adapterDiff = 0;
        long totResult = 0;

        void ReadInput()
        {
            inputData.Clear();
            for (int i = 0; i < input.Length; i++)
            {
                inputData.Add(int.Parse(input[i]));
            }
            inputData.Add(0);
            inputData.Add(inputData.Max() + 3);
            inputData.Sort();
        }


        int PartA()
        {
            ReadInput();
    
            for (int adapter=0; adapter < inputData.Count-1; adapter++)
            {
                adapterDiff = inputData[adapter+1] - inputData[adapter];
                
                if (adapterDiff == 1)
                    diff1++;
                else if (adapterDiff == 3)
                    diff3++;
            }
            return diff1 * diff3;
        }

        long PartB()
        {
            ReadInput();

            var buffer = new Dictionary<int, long> { [inputData.Count() - 1] = 1 };

            for (int i = inputData.Count() - 2; i >= 0; i--)
            {
                totResult = 0;
                for (int idx = i + 1; idx < inputData.Count() && inputData[idx] - inputData[i] <= 3; idx++)
                {
                    totResult += buffer[idx];
                }
                buffer[i] = totResult;
            }
            return totResult;
        }


        public void Run()
        {
            Console.WriteLine("PartA: {0}", PartA()); // 3210
            Console.WriteLine("PartB: {0}", PartB()); // 64793042714624   
        }
    }
}
