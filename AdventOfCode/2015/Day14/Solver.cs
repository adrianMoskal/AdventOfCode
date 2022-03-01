using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015.Day14
{
    class Solver : ISolver
    {
        public string Path { get; set; }

        public void PartOne()
        {
            string[] lines = File.ReadAllLines(Path);
            int seconds = 2503;

            var reindeers = Parse(lines);

            for (int i = 0; i < seconds; i++)
                reindeers.ForEach(r => r.Step());

            int solution = reindeers.Max(r => r.Distance);

            Console.WriteLine($"Part One: {solution}");
        }

        public void PartTwo()
        {
            string[] lines = File.ReadAllLines(Path);
            int seconds = 2503;

            var reindeers = Parse(lines);

            for (int i = 0; i < seconds; i++)
            {
                reindeers.ForEach(r => r.Step());
                reindeers.Where(r => r.Distance == reindeers.Max(x => x.Distance)).ToList().ForEach(r => r.Points++);
            }   

            int solution = reindeers.Max(r => r.Points);

            Console.WriteLine($"Part Two: {solution}");
        }

        private List<Reindeer> Parse(string[] input)
        {
            var reindeers = new List<Reindeer>();

            foreach (var line in input)
            {
                var elements = line.Split(" ");
                reindeers.Add(new Reindeer(elements[0], int.Parse(elements[3]), int.Parse(elements[6]), int.Parse(elements[13]), true));
            }

            return reindeers;
        }
    }
}
