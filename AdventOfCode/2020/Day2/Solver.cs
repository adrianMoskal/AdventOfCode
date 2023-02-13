namespace AdventOfCode._2020.Day2;

[Date(Year = "2020", Day = "2")]
[PuzzleName("Password Philosophy")]
internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
       var lines = File.ReadAllLines(path).ToList();

       var passwords = new List<PasswordPolicy>();
       lines.ForEach(x => passwords.Add(new PasswordPolicy(x)));

       int solution = passwords.Count(p => p.OldValidation());

       AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        var lines = File.ReadAllLines(path).ToList();

        var passwords = new List<PasswordPolicy>();
        lines.ForEach(x => passwords.Add(new PasswordPolicy(x)));

        int solution = passwords.Count(p => p.NewValidation());

        AdventConsole.PartTwo(solution);
    }
}
