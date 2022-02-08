using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015.Day1
{
    class Solver : ISolver
    {
        private const string Path = @"../../../2015/Day1/puzzleInput.txt";

        public void PartOne()
        {
            string lines = File.ReadAllText(Path);

            int level = 0;
            lines.Sum(x => x.Equals('(') ? level++ : level--);

            Console.WriteLine($"Part One: {level}");
        }

        public void PartTwo()
        {
            string lines = File.ReadAllText(Path);

            int level = 0;
            var levels = lines.Select(x => x.Equals('(') ? ++level : --level).ToList();
            int position = levels.IndexOf(-1) + 1;

            Console.WriteLine($"Part Two: {position}");
        }
    }
}
