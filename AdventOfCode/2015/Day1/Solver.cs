namespace AdventOfCode._2015.Day1;

internal sealed class Solver : ISolver
{

    public void PartOne(string path)
    {
        string input = File.ReadAllText(path);

        int level = 0;
        input.Sum(x => x.Equals('(') ? level++ : level--);

        AdventConsole.PartOne(level);
    }

    public void PartTwo(string path)
    {
        string input = File.ReadAllText(path);

        int level = 0;
        var levels = input.Select(x => x.Equals('(') ? ++level : --level).ToList();
        int position = levels.IndexOf(-1) + 1;

        AdventConsole.PartTwo(position);
    }
}
