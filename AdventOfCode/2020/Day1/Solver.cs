namespace AdventOfCode._2020.Day1;

[Date(Year = "2020", Day = "1")]
[PuzzleName("Report Repair")]
internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        var numbers = File.ReadAllLines(path).Select(Int32.Parse);

        int solution = numbers.DifferentCombinations(2)
            .First(c => c.Sum() == 2020)
            .Aggregate((x, y) => x * y);

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        var numbers = File.ReadAllLines(path).Select(Int32.Parse);

        int solution = numbers.DifferentCombinations(3)
            .First(c => c.Sum() == 2020)
            .Aggregate((x, y) => x * y);

        AdventConsole.PartTwo(solution);
    }
}

public static class IEnumerableExtension
{
    public static IEnumerable<IEnumerable<T>> DifferentCombinations<T>(this IEnumerable<T> elements, int k)
    {
        return k == 0 ? new[] { new T[0] } :
          elements.SelectMany((e, i) =>
            elements.Skip(i + 1).DifferentCombinations(k - 1).Select(c => (new[] { e }).Concat(c)));
    }
}
