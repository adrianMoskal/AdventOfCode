using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015.Day2
{
    class Solver : ISolver
    {
        public string Path { get; set; }

        public void PartOne()
        {
            string[] lines = File.ReadAllLines(Path);
            var sum = Prepare(lines).Select(x => Area(x) + Sides(x).Min()).Sum();

            Console.WriteLine($"Part One: {sum}");
        }

        public void PartTwo()
        {
            string[] lines = File.ReadAllLines(Path);
            var sum = Prepare(lines).Select(x => Volume(x) + Perimeters(x).Min()).Sum();

            Console.WriteLine($"Part Two: {sum}");
        }

        private IEnumerable<int[]> Prepare(string[] dimensions)
        {
            return dimensions.Select(x => x.Split("x").Select(Int32.Parse).ToArray());
        }

        private int Area(int[] d)
        {
            return 2 * d[0] * d[1] + 2 * d[1] * d[2] + 2 * d[2] * d[0];
        }

        private int Volume(int[] d)
        {
            return d[0] * d[1] * d[2];
        }

        private int[] Sides(int[] d)
        {
            return new[] { d[0] * d[1], d[0] * d[2] , d[1] * d[2] };
        }

        private int[] Perimeters(int[] d)
        {
            return new[] { 2 * d[0] + 2 * d[1], 2 * d[0] + 2 * d[2], 2 * d[1] + 2 * d[2]};
        }
    }
}
