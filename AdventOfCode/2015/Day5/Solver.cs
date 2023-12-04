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
            .Where(w => HasTwiceInRow(w))
            .Count();

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        string[] words = File.ReadAllLines(path);

        int solution = words.Count(x => HasPair(x) && HasRepeatingLetterWithOneInBetween(x));

        AdventConsole.PartTwo(solution);
    }

    private bool HasTwiceInRow(string w)
        => Enumerable.Range(0, w.Length - 1)
                        .Any(x => w[x].Equals(w[x + 1]));

    private bool HasPair(string w)
        => Enumerable.Range(0, w.Length - 1)
                         .Any(i => w.IndexOf(w.Substring(i, 2), i + 2) != -1);

    private bool HasRepeatingLetterWithOneInBetween(string w)
        => Enumerable.Range(0, w.Length - 2)
                         .Any(i => w[i] == w[i + 2]);
}

