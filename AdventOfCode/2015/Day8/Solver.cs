namespace AdventOfCode._2015.Day8;

internal sealed class Solver : ISolver
{
    public string Path { get; set; }

    public void PartOne()
    {
        string[] lines = File.ReadAllLines(Path);

        int solution = lines.Select(l => (l.Length + 2) - Regex.Unescape(l).Length).Sum();

        Console.WriteLine($"Part One: {solution}");
    }

    public void PartTwo()
    {
        Console.WriteLine($"No Part Two yet");
    }
}
