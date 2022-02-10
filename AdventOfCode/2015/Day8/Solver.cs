using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode._2015.Day8
{
    class Solver : ISolver
    {
        private const string Path = @"../../../2015/Day8/puzzleInput.txt";

        public void PartOne()
        {
            string[] lines = File.ReadAllLines(Path);

            int solution = lines.Select(l => (l.Length + 2) - Regex.Unescape(l).Length).Sum();

            Console.WriteLine($"Part One: {solution}");
        }

        public void PartTwo()
        {
            Console.WriteLine($"No Part Two yet");
        }
    }
}
