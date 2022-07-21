namespace AdventOfCode._2018.Day2;

[Date(Year = "2018", Day = "2")]
[PuzzleName("Inventory Management System")]
internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string[] lines = File.ReadAllLines(path);

        int count_two = lines.Count(line => 
            line.Any(x => (line.Split(x).Length - 1) == 2)
            );

        int count_three = lines.Count(line => 
            line.Any(x => (line.Split(x).Length - 1) == 3)
            );

        int solution = count_two * count_three;

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        string[] lines = File.ReadAllLines(path);

        (string, string) ids = DifferByOne(lines);
        string firstId = ids.Item1;
        string secondId = ids.Item2;

        StringBuilder sb = new StringBuilder();
        for (int x = 0; x < firstId.Length; x++)
        {
            if (firstId[x].Equals(secondId[x]))
            {
                sb.Append(firstId[x]);
            }
        }

        AdventConsole.PartTwo(sb.ToString());
    }


    private (string, string) DifferByOne(string[] lines)
    {
        foreach (var first in lines)
        {
            foreach (var second in lines)
            {
                int differs = 0;
                for (int x = 0; x < first.Length; x++)
                {
                    if (!first[x].Equals(second[x]))
                    {
                        differs++;
                    }

                    if (differs > 1)
                    {
                        break;
                    }
                }
                if (differs == 1)
                {
                    return (first, second);
                }
            }
        }
        return ("", "");
    }
}
