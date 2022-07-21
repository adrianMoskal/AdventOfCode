namespace AdventOfCode._2017.Day2;

[Date(Year = "2017", Day = "2")]
[PuzzleName("Corruption Checksum")]
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

        AdventConsole.PartOne(solution);
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

        AdventConsole.PartTwo(solution);
    }
}
