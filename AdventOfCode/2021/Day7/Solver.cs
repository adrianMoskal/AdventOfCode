namespace AdventOfCode._2021.Day7;

[Date(Year = "2021", Day = "7")]
[PuzzleName("The Treachery of Whales")]
internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        var positions = File.ReadAllText(path)
            .Split(',')
            .Select(int.Parse);

        int solution = PossibleFuels(positions, true).Min();

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        var positions = File.ReadAllText(path)
            .Split(',')
            .Select(int.Parse);

        int solution = PossibleFuels(positions, false).Min();

        AdventConsole.PartTwo(solution);
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
