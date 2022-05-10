namespace AdventOfCode._2018.Day1;

internal sealed class Solver : ISolver
{
    public string Path { get; set; }

    public void PartOne()
    {
        string[] lines = File.ReadAllLines(Path);

        int solution = 0;
        foreach(var change in lines.Select(Int32.Parse))
        {
            solution += change;
        }

        Console.WriteLine($"Part One: {solution}");
    }

    public void PartTwo()
    {
        string[] lines = File.ReadAllLines(Path);

        int solution = 0;
        bool repeat = true;
        var history = new List<int>(0);
        while(repeat)
        {
            foreach (var change in lines.Select(Int32.Parse))
            {
                solution += change;
                if (history.Contains(solution))
                {
                    repeat = false;
                    break;
                }
                history.Add(solution);
            }
        }

        Console.WriteLine($"Part Two: {solution}");
    }
}
