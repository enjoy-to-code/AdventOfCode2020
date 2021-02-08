using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2020
{
    class Day5
    {
        string input = System.IO.File.ReadAllText(@"C:\\dev\\AdventOfCode2020\\Inputfiles\\inputday5.txt");

        HashSet<int> Seats(string inputdata) =>
            inputdata
                .Replace("B", "1")
                .Replace("F", "0")
                .Replace("R", "1")
                .Replace("L", "0")
                .Split("\r\n")
                .Select(row => Convert.ToInt32(row, 2))
                .ToHashSet();

        public void PartA()
        {
            Console.WriteLine("PartA {0} ", Seats(input).Max());
        }

        public void PartB()
        {
            var seats = Seats(input);
            var (min, max) = (seats.Min(), seats.Max());
            var partB = Enumerable.Range(min, max - min + 1).Single(id => !seats.Contains(id));
            Console.WriteLine("PartA {0} ", partB);
        }

        public void Run()
        {
            PartA(); // 828
            PartB(); // 565
        }
    }
}
