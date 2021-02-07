using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Schema;

namespace AdventOfCode2020
{
    public class Day1
    {
        public void PartA()
        {
            int[] numbers = Utils.ReadIntegerFile("C:\\dev\\AdventOfCode2020\\Inputfiles\\inputday1.txt");
            int[] itr = numbers;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < itr.Length; j++)
                {
                    int sum = numbers[i] + itr[j];

                    if (sum == 2020)
                    {
                        double total = numbers[i] * itr[j];
                        Console.WriteLine("PartA {0} + {1} = 2020, total = {2}", numbers[i], itr[j], total);
                        return;
                    }
                }
            }
        }

        public void PartB()
        {
            int[] numbers = Utils.ReadIntegerFile("C:\\dev\\AdventOfCode2020\\Inputfiles\\inputday1.txt");
            int[] itr = numbers;
            int[] itr1 = numbers;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < itr.Length; j++)
                {
                    for (int k = 0; k < itr1.Length; k++)
                    {
                        int sum = numbers[i] + itr[j] + itr1[k];

                        if (sum == 2020)
                        {
                            double total = numbers[i] * itr[j] * itr[k];
                            Console.WriteLine("PartB {0} + {1} + {2} = 2020, total = {3}", numbers[i], itr[j], itr1[k], total);
                            return;
                        }
                    }
                }
            }
        }

        public void Run()
        {
            PartA(); // 802011
            PartB(); // 248607374
        }
    }
    
}
