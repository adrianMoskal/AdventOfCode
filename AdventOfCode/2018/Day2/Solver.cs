using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode._2018.Day2
{
    class Solver : ISolver
    {
        public string Path { get; set; }
        public void PartOne()
        {
            string[] lines = File.ReadAllLines(Path);

            int count_two = lines.Count(line => 
                line.Any(x => (line.Split(x).Length - 1) == 2)
                );

            int count_three = lines.Count(line => 
                line.Any(x => (line.Split(x).Length - 1) == 3)
                );

            int solution = count_two * count_three;

            Console.WriteLine($"Part One: {solution}");
        }

        public void PartTwo()
        {
            Console.WriteLine("No Part Two yet");
        }
    }
}
