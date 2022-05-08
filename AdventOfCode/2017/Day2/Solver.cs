using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2017.Day2
{
    class Solver : ISolver
    {
        public string Path { get; set; }

        public void PartOne()
        {
            var rows = File.ReadAllText(Path).Split('\n');

            int solution = 0;
            foreach (var row in rows)
            {
                var elements = row.Split('\t').Select(int.Parse);
                solution += elements.Max() - elements.Min();
            }

            Console.WriteLine($"Part One: {solution}");
        }

        public void PartTwo()
        {
            var rows = File.ReadAllText(Path).Split('\n');



            //Console.WriteLine($"Part Two: {solution}");
        }
    }
}
