namespace AdventOfCode._2020.Day2;

internal sealed class Solver : ISolver
{
    public string Path { get; set; }
    public void PartOne()
    {
       var lines = File.ReadAllLines(Path).ToList();

       var passwords = new List<PasswordPolicy>();
       lines.ForEach(x => passwords.Add(new PasswordPolicy(x)));

       int solution = passwords.Count(p => p.OldValidation());

       System.Console.WriteLine($"Part One: {solution}");
    }

    public void PartTwo()
    {
        var lines = File.ReadAllLines(Path).ToList();

        var passwords = new List<PasswordPolicy>();
        lines.ForEach(x => passwords.Add(new PasswordPolicy(x)));

        int solution = passwords.Count(p => p.NewValidation());

        System.Console.WriteLine($"Part Two: {solution}");
    }
}
