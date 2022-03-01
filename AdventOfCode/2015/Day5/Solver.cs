using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015.Day5
{
    class Solver : ISolver
    {
        public string Path { get; set; }

        public void PartOne()
        {
            string[] words = File.ReadAllLines(Path);
            string[] forbiddens = { "ab", "cd", "pq", "xy" };
            string vowels = "aeiou";


            int solution = words.Where(w => w.Count(c => vowels.Contains(c)) >= 3)
                .Where(w => !forbiddens.Any(f => w.Contains(f)))
                .Where(w => Enumerable.Range(0, w.Length - 1).Any(x => w[x].Equals(w[x + 1])))
                .Count();

            Console.WriteLine($"Part One: {solution}");
        }

        public void PartTwo()
        {
            Console.WriteLine($"No Part Two yet");
        }
    }
}

