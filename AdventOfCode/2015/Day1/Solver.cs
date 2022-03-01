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
        public string Path { get; set; }

        public void PartOne()
        {
            string input = File.ReadAllText(Path);

            int level = 0;
            input.Sum(x => x.Equals('(') ? level++ : level--);

            Console.WriteLine($"Part One: {level}");
        }

        public void PartTwo()
        {
            string input = File.ReadAllText(Path);

            int level = 0;
            var levels = input.Select(x => x.Equals('(') ? ++level : --level).ToList();
            int position = levels.IndexOf(-1) + 1;

            Console.WriteLine($"Part Two: {position}");
        }
    }
}
