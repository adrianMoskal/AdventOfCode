namespace AdventOfCode._2016.Day5;

internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string input = File.ReadAllText(path);

        int i = 0;
        var solution = new StringBuilder();

        while (solution.Length < 8)
        {
            var hash = "";

            while (!hash.StartsWith("00000"))
                hash = CreateMD5(input + i++);

            solution.Append(hash[5]);
        }

        Console.WriteLine($"Part One: {solution}");
    }

    public void PartTwo(string path)
    {
        Console.WriteLine($"No Part Two yet");
    }

    public static string CreateMD5(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }
}
