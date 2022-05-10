namespace AdventOfCode._2015.Day10;

class Solver : ISolver
{
    public string Path { get; set; }

    public void PartOne()
    {
        string input = File.ReadAllText(Path);

        int solution = LookAndSayNumbers(input).ElementAt(39).Length;

        Console.WriteLine($"Part One: {solution} ");
    }

    public void PartTwo()
    {
        string input = File.ReadAllText(Path);

        int solution = LookAndSayNumbers(input).ElementAt(49).Length;

        Console.WriteLine($"Part Two: {solution} ");
    }

    IEnumerable<string> LookAndSayNumbers(string number)
    {
        for(int i = 0; i < int.MaxValue; i++)
        {
            number = LookAndSay(number);
            yield return number;
        }
    }


    private string LookAndSay(string input)
    {
        StringBuilder output = new StringBuilder();
        int i = 0;
        while (i < input.Length)
        {
            int count = 1;
            while ((i + 1 < input.Length) && (input[i] == input[i + 1]))
            {
                count++;
                i++;
            }

            output.Append(count.ToString() + input[i]);
            i++;
        }
        return output.ToString();
    }
}
