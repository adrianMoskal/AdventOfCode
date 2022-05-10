namespace AdventOfCode._2021.Day1;

class Solver : ISolver
{
    public string Path { get; set; }

    public void PartOne()
    {
        string[] lines = File.ReadAllLines(Path);
        var measurements = lines.Select(Int32.Parse);

        int solution = Enumerable.Range(1, lines.Length - 1)
            .Count(x => measurements.ElementAt(x) > measurements.ElementAt(x - 1));

        Console.WriteLine($"Part One: {solution}");
    }

    public void PartTwo()
    {
        string[] lines = File.ReadAllLines(Path);
        var measurements = lines.Select(Int32.Parse);

        var windowSums = Enumerable.Range(0, lines.Length - 2)
            .Select(x => measurements.ElementAt(x) + measurements.ElementAt(x + 1) + measurements.ElementAt(x + 2));

        int solution = Enumerable.Range(1, windowSums.Count() - 1).Count(x => windowSums.ElementAt(x) > windowSums.ElementAt(x - 1));

        Console.WriteLine($"Part Two: {solution}");
    }
}
