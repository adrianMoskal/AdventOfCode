using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2019.Day3
{
    class Solver : ISolver
    {
        private const string Path = @"../../../2019/Day3/puzzleInput.txt";

        public void PartOne()
        {
            if (File.Exists(Path))
            {
                string input = File.ReadAllText(Path);
                string[] wireOneCommands = input.Split("\n")[0].Split(",");
                string[] wireTwoCommands = input.Split("\n")[1].Split(",");

                var wireOnePoint = new Point(0, 0);
                var wireTwoPoint = new Point(0, 0);
                var centralPortPoint = new Point(0, 0);

                List<Point> wireOnePath = wireOnePoint.GetPath(wireOneCommands);
                List<Point> wireTwoPath = wireTwoPoint.GetPath(wireTwoCommands);

                List<Point> intersections = wireOnePath.Intersect(wireTwoPath, new PointComparer()).ToList();

                Point first = intersections.First();
                int closest = Math.Abs(first.X - centralPortPoint.X) + Math.Abs(first.Y - centralPortPoint.Y);

                foreach (var intersection in intersections)
                {
                    int distance = Math.Abs(intersection.X - centralPortPoint.X) + Math.Abs(intersection.Y - centralPortPoint.Y);
                    if (distance < closest)
                    {
                        closest = distance;
                    }
                }

                Console.WriteLine($"Part One: {closest}");
            }
            else
            {
                Console.WriteLine("File with puzzle input not found");
            }
        }

        public void PartTwo()
        {
            
        }
    }
}
