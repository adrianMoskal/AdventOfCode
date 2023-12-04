namespace AdventOfCode._2023.Day1;

[Date(Year = "2023", Day = "1")]
[PuzzleName("Trebuchet?!")]
internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string[] input = File.ReadAllLines(path);

        int solution = input
            .Select(line => int.Parse($"{line.First(char.IsDigit)}{line.Last(char.IsDigit)}"))
            .Sum();

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        AdventConsole.PartTwoNoSolutionYet();
    }    
}
