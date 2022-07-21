namespace AdventOfCode._2020.Day4;

internal sealed class Solver : ISolver
{
    private string[] mandatoryFields = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
    public void PartOne(string path)
    {
        var input = File.ReadAllText(path).Split("\r\n\r\n");

        int solution = input.Where(x =>
            mandatoryFields.All(f => x.Contains(f))
        ).Count();

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        Console.WriteLine($"\tNo Part Two yet ");
    }
}
