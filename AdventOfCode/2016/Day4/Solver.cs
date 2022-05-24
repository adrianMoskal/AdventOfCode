namespace AdventOfCode._2016.Day4;

internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string[] lines = File.ReadAllLines(path);

        int solution = 0;

        foreach(var line in lines)
        {
            var checksum = line.Split('[', ']')[1];
            var name = line.Substring(0, line.LastIndexOf('-'));
            var sector = line.Substring(line.LastIndexOf('-')+1, line.IndexOf('[') - line.LastIndexOf('-') - 1);
            
            var mostCommon = name.Replace("-", "")
                .OrderBy(x => x)
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Take(5)
                .Select(x => x.Key);

            if (mostCommon.All(x => checksum.Contains(x)))
                solution += int.Parse(sector);               
        }

        Console.WriteLine($"Part One: {solution}");
    }

    public void PartTwo(string path)
    {
        Console.WriteLine($"No Part Two yet");
    }
}
