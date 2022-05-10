namespace AdventOfCode._2015.Day1;

internal sealed class Solver : ISolver
{
    public string Path { get; set; }

    public void PartOne()
    {
        string input = File.ReadAllText(Path);

        int level = 0;
        input.Sum(x => x.Equals('(') ? level++ : level--);

        Console.WriteLine($"Part One: {level}");
    }

    public void PartTwo()
    {
        string input = File.ReadAllText(Path);

        int level = 0;
        var levels = input.Select(x => x.Equals('(') ? ++level : --level).ToList();
        int position = levels.IndexOf(-1) + 1;

        Console.WriteLine($"Part Two: {position}");
    }
}
