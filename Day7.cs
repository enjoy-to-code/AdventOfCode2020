using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;

namespace AdventOfCode2020
{
    class Day7
    {
        static List<string> bagResult = new List<string>();
        string[] input = File.ReadAllLines(@"C:\\dev\\AdventOfCode2020\\Inputfiles\\inputday7.txt"); 

        private static Dictionary<string, List<string>> ParseData(string[] input)
        {
            Dictionary<string, List<string>> bagContains = new Dictionary<string, List<string>>();
            foreach (string bag in input)
            {
                string[] bagsContent = bag.Split(" bags contain ");
                List<string> bagsChilds = bagsContent[1].Split(",")
                                                        .Select(x => x.Replace("bags.", "")
                                                        .Replace("bag.", "").Replace("bags", "")
                                                        .Replace("bag", "")
                                                        .Trim())
                                                        .ToList();

                if (!bagContains.ContainsKey(bagsContent[0]))
                {
                    bagContains.Add(bagsContent[0], bagsChilds);
                }
                else
                {
                    bagContains[bagsContent[0]].AddRange(bagsChilds);
                }
            }
            return bagContains
                        .OrderBy(x => x.Key)
                        .ToDictionary(x => x.Key, x => x.Value);
        }

        private static void PartA(Dictionary<string, List<string>> bagContains)
        {
            var childBags = new List<string>();
            foreach (KeyValuePair<string, List<string>> contents in bagContains)
            {
                if (contents.Value.Any(bag => bag.Contains("no other")))
                {
                    continue;
                }
                if (contents.Value.Any(bag => bag.Contains("shiny gold")))
                {
                    childBags.Add(contents.Key);
                    bagResult.Add(contents.Key);
                }
            }
            SearchBag(childBags, bagContains);
        }

        private static void SearchBag(List<string> childBags, Dictionary<string, List<string>> allBags)
        {
            List<string> dependentBags = new List<string>();
            foreach (string needBag in childBags)
            {
                foreach (KeyValuePair<string, List<string>> bag in allBags)
                {
                    if (bag.Value.Any(x => x.Contains(needBag)))
                    {
                        dependentBags.Add(bag.Key);
                        bagResult.Add(bag.Key);
                    }
                }
            }
            if (dependentBags.Count != 0)
            {
                dependentBags = dependentBags.Distinct().ToList();
                bagResult = bagResult.Distinct().ToList();
                SearchBag(dependentBags, allBags);
            }
        }

        private static int PartB(Dictionary<string, List<string>> bagContains)
        {
            string regex = @"(?<value>\d) (?<name>\w+ \w+)";
            int result = 0;
            var bags = bagContains["shiny gold"];
            foreach (var bag in bags)
            {
                Match match = Regex.Match(bag, regex);
                int count = Int32.Parse(match.Groups["value"].Value);
                string bagName = match.Groups["name"].Value;
                int bagsNumber = SearchBags(bagName, bagContains, regex);
                if (bagsNumber == 1)
                {
                    result += count * bagsNumber;
                }
                else
                {
                    result += count + count * bagsNumber;
                }
            }
            return result;
        }

        private static int SearchBags(string bagName, Dictionary<string, List<string>> bagContains, string regex)
        {
            int result = 0;
            var bags = bagContains[bagName];
            foreach (var bag in bags)
            {
                if (bag.Contains("no other"))
                {
                    return 1;
                }
                Match match = Regex.Match(bag, regex);
                int count = Int32.Parse(match.Groups["value"].Value);
                string bagName2 = match.Groups["name"].Value;
                int child = SearchBags(bagName2, bagContains, regex);
                if (child == 1)
                {
                    result += count * child;
                }
                else
                {
                    result += count + count * child;
                }
            }
            return result;
        }

        public void Run()
        {
            Dictionary<string, List<string>> bagContains = ParseData(input);
            PartA(bagContains);
            Console.WriteLine("PartA: {0}", bagResult.Count);       // 179
            Console.WriteLine("PartB: {0}", PartB(bagContains));    // 18925
        }
    }
}
