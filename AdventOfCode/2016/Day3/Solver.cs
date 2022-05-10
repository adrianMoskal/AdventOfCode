namespace AdventOfCode._2016.Day3;

internal sealed class Solver : ISolver
{
    public string Path { get; set; }

    public void PartOne()
    {
        string[] lines = File.ReadAllLines(Path);

        var triangles = lines.Select(l => Regex.Matches(l, @"\d+").Select(x => int.Parse(x.Value)));

        int solution = triangles.Count(t => ValidTriangle(t));

        Console.WriteLine($"Part One: {solution}");
    }

    public void PartTwo()
    {
        Console.WriteLine($"No Part Two yet");
    }

    private bool ValidTriangle(IEnumerable<int> triangle)
    {
        return triangle.ElementAt(0) + triangle.ElementAt(1) > triangle.ElementAt(2)
            && triangle.ElementAt(0) + triangle.ElementAt(2) > triangle.ElementAt(1)
            && triangle.ElementAt(1) + triangle.ElementAt(2) > triangle.ElementAt(0);
    }
}
