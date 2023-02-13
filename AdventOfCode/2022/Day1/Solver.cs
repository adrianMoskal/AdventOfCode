namespace AdventOfCode._2022.Day1;

[Date(Year = "2022", Day = "1")]
[PuzzleName("Calorie Counting")]
internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string input = File.ReadAllText(path);

        int solution = GetCaloriesDescendingOrder(input).First();

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        string input = File.ReadAllText(path);

        int solution = GetCaloriesDescendingOrder(input).Take(3).Sum();

        AdventConsole.PartTwo(solution);
    }

    private IEnumerable<int> GetCaloriesDescendingOrder(string input)
        => input.Split(Environment.NewLine + Environment.NewLine)
            .Select(x => x.Split(Environment.NewLine).Select(int.Parse).Sum())
            .OrderByDescending(x => x);
}
