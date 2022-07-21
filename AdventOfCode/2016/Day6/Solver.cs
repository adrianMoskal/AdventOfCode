namespace AdventOfCode._2016.Day6;

[Date(Year = "2016", Day = "6")]
[PuzzleName("Signals and Noise")]
internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string[] lines = File.ReadAllLines(path);

        var mostFrequents = Transpose(lines)
            .Select(x => x
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Take(1)
                .Select(x => x.Key))
            .Select(x => x.First());

        var solution = string.Concat(mostFrequents);

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        string[] lines = File.ReadAllLines(path);

        var mostFrequents = Transpose(lines)
            .Select(x => x
                .GroupBy(x => x)
                .OrderBy(x => x.Count())
                .Take(1)
                .Select(x => x.Key))
            .Select(x => x.First());

        var solution = string.Concat(mostFrequents);

        AdventConsole.PartTwo(solution);
    }

    private IEnumerable<string> Transpose(string[] matrix)
    {
        var transposed = new List<string>();

        for (int i = 0; i < matrix.First().Count(); i++)
        {
            string row = "";

            for (int j = 0; j < matrix.Count(); j++)
                row += matrix[j][i];

            transposed.Add(row);
        }

        return transposed;
    }
}

