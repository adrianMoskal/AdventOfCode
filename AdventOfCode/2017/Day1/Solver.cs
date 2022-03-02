using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2017.Day1
{
    class Solver : ISolver
    {
        public string Path { get; set; }

        public void PartOne()
        {
            string input = File.ReadAllText(Path);

            var solution = Enumerable.Range(0, input.Length - 1)
                    .Where(x => input[x] == input[x+1])
                    .Select(x => int.Parse(input[x].ToString()))
                    .Sum();

            if(input.Last() == input.First())
                solution += int.Parse(input.First().ToString());

            Console.WriteLine($"Part One: {solution}");
        }

        public void PartTwo()
        {

        }
    }
}
