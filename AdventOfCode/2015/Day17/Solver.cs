using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015.Day17
{
    class Solver : ISolver
    {
        public string Path { get; set; }

        public void PartOne()
        {
            string[] lines = File.ReadAllLines(Path);
            int[] containers = lines.Select(Int32.Parse).ToArray();

            int solution = Combinations(containers).Where(x => x.Sum() == 150).Count();

            Console.WriteLine($"Part One: {solution}");
        }

        public void PartTwo()
        {
            string[] lines = File.ReadAllLines(Path);
            int[] containers = lines.Select(Int32.Parse).ToArray();

            int min = Combinations(containers).Where(x => x.Sum() == 150).Min(c => c.Length);
            int solution = Combinations(containers).Where(x => x.Sum() == 150 && x.Length == min).Count();

            Console.WriteLine($"Part Two: {solution}");
        }

        private IEnumerable<int[]> Combinations(int[] elements)
        {
            return Enumerable.Range(0, 1 << (elements.Length)).Select(index => elements.Where((v, i) => (index & (1 << i)) != 0).ToArray());
        }
    }
}
