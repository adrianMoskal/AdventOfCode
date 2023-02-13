namespace AdventOfCode._2015.Day4;

[Date(Year = "2015", Day = "4")]
[PuzzleName("The Ideal Stocking Stuffer")]
internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string input = File.ReadAllText(path);
        string prefix = "00000";

        int solution = GetHashes(input)
            .First(x =>x.Item2.StartsWith(prefix)).Item1;

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        string input = File.ReadAllText(path);
        string prefix = "000000";

        int solution = GetHashes(input)
            .First(x => x.Item2.StartsWith(prefix)).Item1;

        AdventConsole.PartTwo(solution);
    }

    private IEnumerable<(int, string)> GetHashes(string input)
    {
        for (int i = 1; i <= int.MaxValue; i++)
            yield return (i, CreateMD5(input + i));
    }

    public static string CreateMD5(string input)
    {
        MD5 md5 = MD5.Create();
        byte[] hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(input));

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
        {
            sb.Append(hashBytes[i].ToString("X2"));
        }

        return sb.ToString();
    }
}
