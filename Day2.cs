using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day2
    {
        public void PartA()
        {
            string passwordline;
            int numberofmatches = 0, min = 0, max = 0, passwordValid = 0;

            StreamReader file = new StreamReader(@"C:\\dev\\AdventOfCode2020\\Inputfiles\\inputday2.txt");

            while ((passwordline = file.ReadLine()) != null)
            {
                string pattern = @"\w+";
                Regex rg = new Regex(pattern);
                var res = rg.Matches(passwordline);

                min = int.Parse(res[0].Value);
                max = int.Parse(res[1].Value);
                string searchChar = res[2].Value;
                string passWord = res[3].Value;

                numberofmatches = Regex.Matches(passWord, searchChar).Count;

                if (numberofmatches >= min && numberofmatches <= max)
                {
                    passwordValid++;
                }
            }
            Console.WriteLine("PartA {0} ", passwordValid);
        }

        public void PartB()
        {
            string passwordline;
            int numberofmatches = 0, pos1 = 0, pos2 = 0, passwordValid = 0;

            StreamReader file = new StreamReader(@"C:\\dev\\AdventOfCode2020\\Inputfiles\\inputday2.txt");

            while ((passwordline = file.ReadLine()) != null)
            {
                string pattern = @"\w+";
                Regex rg = new Regex(pattern);
                var res = rg.Matches(passwordline);

                pos1 = int.Parse(res[0].Value);
                pos2 = int.Parse(res[1].Value);
                string searchChar = res[2].Value;
                string passWord = res[3].Value;

                numberofmatches = Regex.Matches(passWord, searchChar).Count;

                if ((passWord[pos1-1].ToString().Equals(searchChar)) && (!passWord[pos2-1].ToString().Equals(searchChar)))
                {       
                    passwordValid++;
                  
                }
                if ((!passWord[pos1-1].ToString().Equals(searchChar)) && (passWord[pos2-1].ToString().Equals(searchChar)))
                {
                    passwordValid++;
                }
            }
            Console.WriteLine("PartB {0} ", passwordValid);
        }


        public void Run()
        {
            PartA(); // 622
            PartB(); // 263
        }
    }
}
