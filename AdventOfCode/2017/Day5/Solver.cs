namespace AdventOfCode._2017.Day5;

internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        var lines = File.ReadAllLines(path)
            .Select(int.Parse)
            .ToArray();

        var (pos, solution) = (0, 0);

        while (0 <= pos && pos < lines.Length)
        {
            pos += lines[pos]++;
            solution++;
        }

        Console.WriteLine($"Part One: {solution}");
    }

    public void PartTwo(string path)
    {
        var lines = File.ReadAllLines(path)
            .Select(int.Parse)
            .ToArray();

        var (pos, solution) = (0, 0);

        while (0 <= pos && pos < lines.Length)
        {
            (pos, lines[pos]) 
                = (pos + lines[pos], lines[pos] >= 3 ? --lines[pos] : ++lines[pos]);

            solution++;
        }

        Console.WriteLine($"Part Two: {solution}");
    }
}
