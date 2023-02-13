namespace AdventOfCode._2015.Day2;

[Date(Year = "2015", Day = "2")]
[PuzzleName("I Was Told There Would Be No Match")]
internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string[] lines = File.ReadAllLines(path);

        var solution = GetWrappingMaterial(lines, Area, Sides);

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        string[] lines = File.ReadAllLines(path);

        int solution = GetWrappingMaterial(lines, Volume, Perimeters);

        AdventConsole.PartTwo(solution);
    }

    private int GetWrappingMaterial(string[] dimensions, Func<int[], int> wrappingFunc, Func<int[], int[]> additionalFunc)
        => dimensions.Select(x => x.Split("x").Select(int.Parse).ToArray())
            .Select(x => wrappingFunc.Invoke(x) + additionalFunc.Invoke(x).Min()).Sum();

    private int Area(int[] d)
        => 2 * d[0] * d[1] + 2 * d[1] * d[2] + 2 * d[2] * d[0];

    private int Volume(int[] d)
        => d[0] * d[1] * d[2];

    private int[] Sides(int[] d)
        => new[] { d[0] * d[1], d[0] * d[2] , d[1] * d[2] };

    private int[] Perimeters(int[] d)
        => new[] { 2 * d[0] + 2 * d[1], 2 * d[0] + 2 * d[2], 2 * d[1] + 2 * d[2]};
}
