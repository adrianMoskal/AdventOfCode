using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2021.Day3
{
    class Solver : ISolver
    {
        private const string Path = @"../../../2021/Day3/puzzleInput.txt";

        public void PartOne()
        {
            string[] bytes = File.ReadAllLines(Path);
            
            var gammaRateBinary = string.Join("", Enumerable.Range(0, bytes[0].Length).Select(x => MostCommonBit(bytes, x)));
            var epsilonRateBinary = string.Join("", gammaRateBinary.Select(b => b == '0' ? '1' : '0'));

            int gammaRate = Convert.ToInt32(gammaRateBinary, 2);
            int epsilonRate = Convert.ToInt32(epsilonRateBinary, 2);

            int solution = gammaRate * epsilonRate;

            Console.WriteLine($"Part One: {solution}");
        }

        public void PartTwo()
        {
            Console.WriteLine("No Part Two yet");
        }

        private char MostCommonBit(string[] bytes, int position)
        {
            return bytes
               .Select(x => x[position])
               .GroupBy(x => x)
               .OrderByDescending(x => x.Count())
               .Take(1)
               .Select(x => x.Key)
               .ElementAt(0);
        }
    }
}
