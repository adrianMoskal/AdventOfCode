namespace AdventOfCode._2019.Day3;

internal sealed class Solver : ISolver
{
    public string Path { get; set; }

    public void PartOne()
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

    public void PartTwo()
    {
        
    }
}
