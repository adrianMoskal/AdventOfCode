namespace AdventOfCode._2017.Day5;

[Date(Year = "2017", Day = "5")]
[PuzzleName("A Maze of Twisty Trampolines, All Alike")]
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

        AdventConsole.PartOne(solution);
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

        AdventConsole.PartTwo(solution);
    }
}
