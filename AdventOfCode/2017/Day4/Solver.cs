namespace AdventOfCode._2017.Day4;

internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        var lines = File.ReadAllLines(path).Select(x => x.Split(" "));

        int solution = lines.Count(x => 
            x.Distinct().Count() == x.Length);

        Console.WriteLine($"Part One: {solution}");
    }

    public void PartTwo(string path)
    {
        var lines = File.ReadAllLines(path).Select(x => x.Split(" "));

        int solution = lines.Count(x =>
            x.Select(w => string.Join("", w.OrderBy(c => c)))
                .Distinct().Count() == x.Length);

        Console.WriteLine($"Part Two: {solution}");
    }
}
