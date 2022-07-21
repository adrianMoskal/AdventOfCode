namespace AdventOfCode._2017.Day4;

[Date(Year = "2017", Day = "4")]
[PuzzleName("High-Entropy Passphrases")]
internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        var lines = File.ReadAllLines(path).Select(x => x.Split(" "));

        int solution = lines.Count(x => 
            x.Distinct().Count() == x.Length);

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        var lines = File.ReadAllLines(path).Select(x => x.Split(" "));

        int solution = lines.Count(x =>
            x.Select(w => string.Join("", w.OrderBy(c => c)))
                .Distinct().Count() == x.Length);

        AdventConsole.PartTwo(solution);
    }
}
