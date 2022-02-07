using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2019.Day1
{
    class Solver : ISolver
    {
        private const string Path = @"../../../2019/Day1/puzzleInput.txt";

        public void PartOne()
        {
            if (File.Exists(Path))
            {
                string[] lines = File.ReadAllLines(Path);
                double fuelNeeded = lines.Sum(m => Math.Floor(double.Parse(m) / 3) - 2);

                Console.WriteLine($"Part One: {fuelNeeded}");
            }
            else
            {
                Console.WriteLine("File with puzzle input not found");
            }
        }

        public void PartTwo()
        {
            if (File.Exists(Path))
            {
                string[] lines = File.ReadAllLines(Path);
                double[] masses = lines.Select(m => Double.Parse(m)).ToArray<double>();

                Stack<double> modulesMass = new Stack<double>(masses);

                double fuelSum = 0;
                while (modulesMass.Any())
                {
                    double mass = modulesMass.Pop();
                    double fuel = Math.Floor(mass / 3) - 2;

                    if (fuel > 0)
                    {
                        fuelSum += fuel;
                        modulesMass.Push(fuel);
                    }
                }
                Console.WriteLine($"Part Two: {fuelSum}");
            }
            else
            {
                Console.WriteLine("File with puzzle input not found");
            }
        }
    }
}
