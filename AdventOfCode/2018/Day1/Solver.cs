namespace AdventOfCode._2018.Day1;

internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string[] lines = File.ReadAllLines(path);

        int solution = 0;
        foreach(var change in lines.Select(Int32.Parse))
        {
            solution += change;
        }

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        string[] lines = File.ReadAllLines(path);

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

        AdventConsole.PartTwo(solution);
    }
}
