namespace AdventOfCode._2015.Day8;

internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string[] lines = File.ReadAllLines(path);

        int solution = lines.Select(l => (l.Length + 2) - Regex.Unescape(l).Length).Sum();

        Console.WriteLine($"Part One: {solution}");
    }

    public void PartTwo(string path)
    {
        Console.WriteLine($"No Part Two yet");
    }
}
