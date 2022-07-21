namespace AdventOfCode._2015.Day2;

internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string[] lines = File.ReadAllLines(path);
        var sum = Prepare(lines).Select(x => Area(x) + Sides(x).Min()).Sum();

        AdventConsole.PartOne(sum);
    }

    public void PartTwo(string path)
    {
        string[] lines = File.ReadAllLines(path);
        var sum = Prepare(lines).Select(x => Volume(x) + Perimeters(x).Min()).Sum();

        AdventConsole.PartTwo(sum);
    }

    private IEnumerable<int[]> Prepare(string[] dimensions)
    {
        return dimensions.Select(x => x.Split("x").Select(Int32.Parse).ToArray());
    }

    private int Area(int[] d)
    {
        return 2 * d[0] * d[1] + 2 * d[1] * d[2] + 2 * d[2] * d[0];
    }

    private int Volume(int[] d)
    {
        return d[0] * d[1] * d[2];
    }

    private int[] Sides(int[] d)
    {
        return new[] { d[0] * d[1], d[0] * d[2] , d[1] * d[2] };
    }

    private int[] Perimeters(int[] d)
    {
        return new[] { 2 * d[0] + 2 * d[1], 2 * d[0] + 2 * d[2], 2 * d[1] + 2 * d[2]};
    }
}
