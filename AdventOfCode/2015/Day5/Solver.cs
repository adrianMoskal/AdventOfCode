namespace AdventOfCode._2015.Day5;

[Date(Year = "2015", Day = "5")]
[PuzzleName("Doesn't He Have Intern-Elves For This?")]
internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string[] words = File.ReadAllLines(path);
        string[] forbiddens = { "ab", "cd", "pq", "xy" };
        string vowels = "aeiou";


        int solution = words.Where(w => w.Count(c => vowels.Contains(c)) >= 3)
            .Where(w => !forbiddens.Any(f => w.Contains(f)))
            .Where(w => Enumerable.Range(0, w.Length - 1).Any(x => w[x].Equals(w[x + 1])))
            .Count();

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        AdventConsole.PartTwoNoSolutionYet();
    }
}

