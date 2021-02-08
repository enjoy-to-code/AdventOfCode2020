using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    class Day6
    {
        string[] input = System.IO.File.ReadAllLines(@"C:\\dev\\AdventOfCode2020\\Inputfiles\\inputday6.txt");

        void PartA()
        {
            string formsData = "";
            string formsLine;
            List<string> myFormsCollection = new List<string>();
            int numberOfQuestions = 0;
            int numberOfQuestionsValid = 0;

            for (int row = 0; row <= input.Length - 1; row++)
            {
                formsLine = input[row];

                if (formsLine.Length > 0)
                {
                    formsData = formsData + formsLine;
                }
                if ((formsLine.Length == 0) || (row == input.Length - 1))
                {
                    myFormsCollection.Add(formsData);
                    formsData = "";
                }
            }

            foreach (string s in myFormsCollection)
            {
                if (s != null)
                {
                    numberOfQuestionsValid = s.Distinct().Count();
                }
                numberOfQuestions = numberOfQuestions + numberOfQuestionsValid;
            }
            Console.WriteLine("PartA {0} ", numberOfQuestions);
        }

        void PartB()
        {
            int numberOfQuestions = 0;
            HashSet<char> hashSet = new HashSet<char>();

            // Read the first row
            hashSet = new HashSet<char>(input[0].ToCharArray());

            for (int row = 0; row <= input.Length - 1; row++)
            {
                if ((input[row].Length == 0) || (row == input.Length - 1))
                {
                    numberOfQuestions = numberOfQuestions + hashSet.Count();
                    if (row < input.Length-1)
                    {
                        hashSet = new HashSet<char>(input[row + 1].ToCharArray());
                    }
                } 
                else if (input[row].Length > 0)
                {
                    hashSet.IntersectWith(input[row].ToCharArray());
                }

            }
            Console.WriteLine("PartB {0} ", numberOfQuestions);
        }

        public void Run()
        {
            PartA(); // 6947
            PartB(); // 3398
        }
    }
}

