namespace AdventOfCode._2020.Day1;

internal sealed class Solver : ISolver
{
    public string Path { get; set; }
    public void PartOne()
    {
        var numbers = File.ReadAllLines(Path).Select(Int32.Parse);

        int solution = numbers.DifferentCombinations(2)
            .First(c => c.Sum() == 2020)
            .Aggregate((x, y) => x * y);

        Console.WriteLine($"Part One: {solution}");
    }

    public void PartTwo()
    {
        var numbers = File.ReadAllLines(Path).Select(Int32.Parse);

        int solution = numbers.DifferentCombinations(3)
            .First(c => c.Sum() == 2020)
            .Aggregate((x, y) => x * y);

        Console.WriteLine($"Part Two: {solution}");
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
