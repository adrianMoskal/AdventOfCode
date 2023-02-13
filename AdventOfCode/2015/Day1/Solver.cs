namespace AdventOfCode._2015.Day1;

[Date(Year = "2015", Day = "1")]
[PuzzleName("Not Quite Lisp")]
internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string input = File.ReadAllText(path);

        int solution = GetFloors(input, 0).Last();

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        string input = File.ReadAllText(path);

        int solution = GetFloors(input, 0).ToList().IndexOf(-1) + 1;

        AdventConsole.PartTwo(solution);
    }

    private IEnumerable<int> GetFloors(string input, int level)
        => input.Select(x => x.Equals('(') ? ++level : --level);
}
