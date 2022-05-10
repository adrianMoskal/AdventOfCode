namespace AdventOfCode._2017.Day2;

internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        var rows = File.ReadAllText(path).Split('\n');

        int solution = 0;
        foreach (var row in rows)
        {
            var elements = row.Split('\t').Select(int.Parse);
            solution += elements.Max() - elements.Min();
        }

        Console.WriteLine($"Part One: {solution}");
    }

    public void PartTwo(string path)
    {
        var rows = File.ReadAllText(path).Split('\n');

        int solution = 0;
        foreach (var row in rows)
        {
            var elements = row.Split('\t').Select(int.Parse);
            solution += elements.SelectMany(e => elements,
                (x, y) => (x > y && x % y == 0) ? x / y : 0
            ).Sum();
        }

        Console.WriteLine($"Part Two: {solution}");
    }
}
