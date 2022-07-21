namespace AdventOfCode._2015.Day8;

[Date(Year = "2015", Day = "8")]
[PuzzleName("Matchsticks")]
internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string[] lines = File.ReadAllLines(path);

        int solution = lines.Select(l => (l.Length + 2) - Regex.Unescape(l).Length).Sum();

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        AdventConsole.PartTwoNoSolutionYet();
    }
}
