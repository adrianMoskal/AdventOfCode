namespace AdventOfCode._2017.Day1;

internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string input = File.ReadAllText(path);

        var solution = Enumerable.Range(0, input.Length)
                .Where(x => input[x] == input[(x+1) % input.Length])
                .Select(x => int.Parse(input[x].ToString()))
                .Sum();

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        string input = File.ReadAllText(path);

        var solution = Enumerable.Range(0, input.Length)
                .Where(x => input[x] == input[(x + input.Length / 2) % input.Length])
                .Select(x => int.Parse(input[x].ToString()))
                .Sum();

        AdventConsole.PartTwo(solution);
    }
}
