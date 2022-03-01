using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015.Day16
{
    class Solver : ISolver
    {
        public string Path { get; set; }

        private Aunt pattern = new Aunt(-1)
        {
            Children = 3,
            Cats = 7,
            Samoyeds = 2,
            Pomeranians = 3,
            Akitas = 0,
            Vizslas = 0,
            Goldfish = 5,
            Trees = 3,
            Cars = 2,
            Perfumes = 1
        };

        public void PartOne()
        {
            string[] lines = File.ReadAllLines(Path);
            List<Aunt> aunts = Parse(lines);

            int solution = aunts.Single(a => pattern.Equals(a)).Number;

            Console.WriteLine($"Part One: {solution}");
        }

        public void PartTwo()
        {
            string[] lines = File.ReadAllLines(Path);
            List<Aunt> aunts = Parse(lines);

            int solution = aunts.Single(a => pattern.EqualsPartTwo(a)).Number;

            Console.WriteLine($"Part Two: {solution}");
        }

        private List<Aunt> Parse(string[] input)
        {
            var aunts = new List<Aunt>();

            int number = 1;
            foreach(var line in input)
            {
                var aunt = new Aunt(number++);
                var elements = line.Replace(",", "").Split(" ");
                for(int i = 0; i < elements.Length; i++)
                {
                    switch(elements[i])
                    {
                        case "children:":
                            aunt.Children = int.Parse(elements[i + 1]);
                            break;
                        case "cats:":
                            aunt.Cats = int.Parse(elements[i + 1]);
                            break;
                        case "samoyeds:":
                            aunt.Samoyeds = int.Parse(elements[i + 1]);
                            break;
                        case "pomeranians:":
                            aunt.Pomeranians = int.Parse(elements[i + 1]);
                            break;
                        case "akitas:":
                            aunt.Akitas = int.Parse(elements[i + 1]);
                            break;
                        case "vizslas:":
                            aunt.Vizslas = int.Parse(elements[i + 1]);
                            break;
                        case "goldfish:":
                            aunt.Goldfish = int.Parse(elements[i + 1]);
                            break;
                        case "trees:":
                            aunt.Trees = int.Parse(elements[i + 1]);
                            break;
                        case "cars:":
                            aunt.Cars = int.Parse(elements[i + 1]);
                            break;
                        case "perfumes:":
                            aunt.Perfumes = int.Parse(elements[i + 1]);
                            break;
                    }
                }
                aunts.Add(aunt);
            }

            return aunts;
        }
    }
}
