using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    class Day4
    {
        bool checkPasswordFields(string passportLine)
        {
            string pattern = @"\w+";
            pattern = @"[A-Za-z0-9#]+|(#.*?)";
            Regex rg = new Regex(pattern);
            var res = rg.Matches(passportLine);
            int val= 0;
            string strval;
            bool returnVal = false;

            if (res.Count == 0)
                return false;
            if (res.Count < 14)
                return false;

            // Check if all required fields are in the string
            pattern = @"hcl|iyr|ecl|byr|iyr|hgt|pid|eyr";
            rg = new Regex(pattern);
            var rval = rg.Matches(passportLine);
            if (rval.Count != 7)
                return false;


            for (int pos = 0; pos < res.Count; pos++)
            {
                if (res[pos].Value == "byr")
                {
                    val = int.Parse(res[pos + 1].Value);
                    if (val >= 1920 && val <= 2002)
                        returnVal = true;
                    else
                        return false;
                }

                if (res[pos].Value == "iyr")
                {
                    val = int.Parse(res[pos + 1].Value);
                    if (val >= 2010 && val <= 2020)
                        returnVal = true;
                    else
                        return false;
                }

                if (res[pos].Value == "eyr")
                {
                    val = int.Parse(res[pos + 1].Value);
                    if (val >= 2020 && val <= 2030)
                        returnVal = true;
                    else
                        return false;
                }

                if (res[pos].Value == "hgt")
                {
                    strval = res[pos + 1].Value;
                    int length = strval.Length;

                    if (length <= 2)
                        return false;

                    int hgt = int.Parse(strval.Substring(0, length - 2));
                    string m = strval.Substring(length - 2, 2);
                    if (m == "cm")
                    {
                        if (hgt >= 150 && hgt <= 193)
                            returnVal = true;
                        else
                            return false;
                    }
                    else if (m == "in")
                    {
                        if (hgt >= 59 && hgt <= 76)
                            returnVal = true;
                        else
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                }

                if (res[pos].Value == "hcl")
                {
                    strval = res[pos + 1].Value;

                    if (strval.Length != 7)
                        return false;

                    pattern = @"#[0-9|a-f][0-9|a-f][0-9|a-f][0-9|a-f][0-9|a-f][0-9|a-f]";
                    rg = new Regex(pattern);
                    rval = rg.Matches(strval);
                    if (rval.Count > 0)
                        returnVal = true;
                    else
                        return false;
                }

                if (res[pos].Value == "ecl")
                {
                    strval = res[pos + 1].Value;

                    if (strval.Length != 3)
                        return false;

                    pattern = @"(amb)|(blu)|(brn)|(gry)|(grn)|(hzl)|(oth)";
                    rg = new Regex(pattern);
                    rval = rg.Matches(strval);
                    if (rval.Count > 0)
                       returnVal = true;
                    else
                        return false;
                }

                if (res[pos].Value == "pid")
                {
                    strval = res[pos + 1].Value;

                    if (strval.Length != 9)
                        return false;

                    pattern = @"[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]";
                    rg = new Regex(pattern);
                    rval = rg.Matches(strval);
                    if (rval.Count > 0)
                        returnVal = true;
                    else
                        return false;
                }
            }
            return returnVal;
        }

        bool checkPasswordValid(string passpordLine)
        {
            string pattern = @"\w+";
            Regex rg = new Regex(pattern);
            var res = rg.Matches(passpordLine).Count;

            if (res == 16)
            {
                return true;
            }
            
            // Check only missing fiels is CID
            if (res == 14) 
            {
                pattern = @"cid:";
                rg = new Regex(pattern);
                var resCid = rg.Matches(passpordLine).Count;
                if (resCid == 0)
                    return true;
            }
            return false;
         }


        public void PartA()
        {
            string[] input = System.IO.File.ReadAllLines(@"C:\\dev\\AdventOfCode2020\\Inputfiles\\inputday4.txt");
            string passportData = "";
            string passportLine;
            string[] passportList;
            List<string> myPassportCollection = new List<string>();
            int passportValid = 0;
           
            for (int row = 0; row < input.Length; row++)
            {
                passportLine = input[row];

                if (passportLine.Length >0)
                {
                    passportData = passportData + passportLine + " ";
                }
                if (passportLine.Length == 0)
                {
                    myPassportCollection.Add(passportData);
                    passportData = "";
                }
            }

            passportList = myPassportCollection.ToArray();

            foreach (string s in passportList)
            {
                if (s != null)
                {
                    bool check = checkPasswordValid(s);
                    if (check == true)
                    {
                        if (checkPasswordValid(s) == true)
                        {
                            passportValid++;
                        }                               
                    }
                }
            }
            Console.WriteLine("PartA {0} ", passportValid);
        }
    

        public void PartB()
        {
            string[] input = System.IO.File.ReadAllLines(@"C:\\dev\\AdventOfCode2020\\Inputfiles\\inputday4.txt");
            string passportData = "";
            string passportLine;
            string[] passportList;
            List<string> myPassportCollection = new List<string>();
            int passportValid = 0;
         
            for (int row = 0; row < input.Length; row++)
            {
                passportLine = input[row];

                if (passportLine.Length > 0)
                {
                    passportData = passportData + passportLine + " ";
                }
                if ((passportLine.Length == 0) || (row == input.Length-1))
                {
                    myPassportCollection.Add(passportData);
                    passportData = "";
                }
            }

            passportList = myPassportCollection.ToArray();

            foreach (string s in passportList)
            {
                if (s != null)
                {
                    if (checkPasswordFields(s))
                    {
                        passportValid++;
                    }
                }
            }
            Console.WriteLine("PartB {0} ", passportValid);
        }

    

        public void Run()
        {
            PartA();  // 200
            PartB();  // 116
        }


    }
}
