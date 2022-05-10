namespace AdventOfCode._2021.Day7;

internal sealed class Solver : ISolver
{
    public string Path { get; set; }

    public void PartOne()
    {
        var positions = File.ReadAllText(Path)
            .Split(',')
            .Select(int.Parse);

        int solution = PossibleFuels(positions, true).Min();

        Console.WriteLine($"Part One: {solution}");
    }

    public void PartTwo()
    {
        var positions = File.ReadAllText(Path)
            .Split(',')
            .Select(int.Parse);

        int solution = PossibleFuels(positions, false).Min();

        Console.WriteLine($"Part Two: {solution}");
    }

    private IEnumerable<int> PossibleFuels(IEnumerable<int> positions, bool constantRate)
    {
        int min = positions.Min();
        int max = positions.Max();

        return Enumerable.Range(min, max).Select(x =>
            positions.Select(p => Cost(Math.Abs(p - x), constantRate)).Sum()
        );
    }

    private int Cost(int n, bool constantRate)
    {
        if (constantRate || n < 2)
            return n;
        else
            return Enumerable.Range(1, n).Sum();
    }
}
