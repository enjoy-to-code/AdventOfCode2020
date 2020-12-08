using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    class Day8
    {
        static string[] input = System.IO.File.ReadAllLines(@"C:\\dev\\AdventOfCode2020\\Inputfiles\\inputday8.txt");
        bool[] visited = new bool[input.Length];
        bool isTerminated = false;

        int ExecuteProgram(string[] instructions)
        {
            int ip = 0;
            int accumulator = 0;
            string opCode = "";
            string instruction = "";
            bool[] visited = new bool[1000];

            while (true)
            {
                if (ip == instructions.Length)
                {
                    isTerminated = true;
                    return accumulator;
                }

                if (visited[ip] == true)
                    return accumulator;

                visited[ip] = true;

                string tmp = instructions[ip].ToString();
                string[] res = tmp.Split(null);
                instruction = res[0].ToString();
                opCode = res[1].ToString();

                if (instruction == "nop")
                {
                    ip++;
                }
                else if (instruction == "acc")
                {
                    ip++;

                    if (opCode[0].ToString() == "+")
                    {
                        accumulator = accumulator + int.Parse(opCode.Remove(0, 1).ToString());
                    }
                    else if (opCode[0].ToString() == "-")
                    {
                        accumulator = accumulator - int.Parse(opCode.Remove(0, 1).ToString());
                    }
                }
                else if (instruction == "jmp")
                {
                    if (opCode[0].ToString() == "+")
                    {
                        ip = ip + int.Parse(opCode.Remove(0, 1).ToString());
                    }
                    else if (opCode[0].ToString() == "-")
                    {
                        ip = ip - int.Parse(opCode.Remove(0, 1).ToString());
                    }
                }
            }
            return 0;
        }


        int PartB()
        {
            for (int i = 0; i < input.Length; i++)
            {
                string[] cpyInput = new string[input.Length];
                Array.Copy(input, cpyInput, input.Length);
                int result = 0;

                if (cpyInput[i].Substring(0, 3) == "nop")
                {
                    Array.Copy(input, cpyInput, input.Length);
                    cpyInput[i] = cpyInput[i].Replace("nop", "jmp");
                    result = ExecuteProgram(cpyInput);
                }
                if (cpyInput[i].Substring(0, 3) == "jmp")
                {
                    Array.Copy(input, cpyInput, input.Length);
                    cpyInput[i] = cpyInput[i].Replace("jmp", "nop");
                    result = ExecuteProgram(cpyInput);

                }
                if (isTerminated)
                    return result;
            }
            return 0;
           
        }

        public void Run()
        {
            Console.WriteLine("PartA: {0}", ExecuteProgram(input));
            Console.WriteLine("PartB: {0}", PartB());
        }


    }
}
