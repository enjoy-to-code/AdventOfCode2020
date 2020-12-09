using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace AdventOfCode2020
{
    class Day9
    {
        static string[] input = System.IO.File.ReadAllLines(@"C:\\dev\\AdventOfCode2020\\Inputfiles\\inputday9.txt");
        int preamble = 25;
        double[] inputInDoubles = new double[input.Length];
        double min, max;

        double[] src;
        int offset = 0;
        int start = 0;

        void PartA()
        {
            for (int i = 0; i < input.Length; i++)
            {
                inputInDoubles[i] = double.Parse(input[i]);
            }

            offset = preamble;
            start =  0;
           
            while ((offset+preamble) < input.Length)
            {
                src = new ArraySegment<double>(inputInDoubles, start, preamble).ToArray();

                if (findPairs(src, src, src.Length, src.Length, inputInDoubles[offset]) == 0)
                    Console.WriteLine("Part {0}", inputInDoubles[offset]); 
                offset++;
                start++;
            }
        }

        void PartB()
        {
            int start = 0;
            double sum = 0;
            double total = 1492208709;
            double elementVal;

            for (int i = 0; i < input.Length; i++)
            {
                elementVal = double.Parse(input[i]);
                inputInDoubles[i] = elementVal;
                sum += elementVal;
                if (sum > total) {
                    i = start;
                    start++;
                    sum = 0;
                    Array.Clear(inputInDoubles, 0, input.Length);
                }
                else if (sum == total)
                {
                    max  = inputInDoubles.Max();
                    min = inputInDoubles.Where(x => x != 0).Min();
                    Console.WriteLine("PartB: {0}", min+max);
                    return;
                }
            }
        }


        static int findPairs(double[] arr1, double[] arr2, int n, int m, double x)
        {
            int nrOffPairs = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (arr1[i] + arr2[j] == x)
                    {
                        nrOffPairs++;
                    }
            return nrOffPairs;
        }

        public void Run()
        {
            // PartA(); // 1492208709
            PartB(); //  238243506
        }





    }





}
