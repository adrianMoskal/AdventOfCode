namespace AdventOfCode._2016.Day5;

internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string input = File.ReadAllText(path);

        int i = 0;
        var password = new StringBuilder();

        while (password.Length < 8)
        {
            var hash = CreateMD5(input + i++);

            while (!hash.StartsWith("00000"))
                hash = CreateMD5(input + i++);

            password.Append(hash[5]);
        }

        Console.WriteLine($"Part One: {password}");
    }

    public void PartTwo(string path)
    {
        string input = File.ReadAllText(path);

        int i = 0;
        var password = "________".ToList();

        while (password.Any(x => x == '_'))
        {
            var hash = CreateMD5(input + i++);

            while (!hash.StartsWith("00000"))
                hash = CreateMD5(input + i++);

            if(int.TryParse(new string(hash[5], 1), out int position))
                if (position >= 0 && position <= 7 && password[position] == '_')
                    password[position] = hash[6];           
        }

        Console.WriteLine($"Part Two: {string.Join("", password)}");
    }

    public string CreateMD5(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }
}
