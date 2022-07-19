namespace AdventOfCode._2016.Day2;

internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string[] lines = File.ReadAllLines(path);

        var keypad = new string[] { "123", "456", "789" };
        var (row, col) = (1, 1); // Start at 5

        var solution = new StringBuilder();

        foreach (var line in lines)
        {
            foreach (var character in line)
            {
                var (newRow, newCol) = character switch
                {
                    'U' => (-1, 0),
                    'R' => (0, 1),
                    'D' => (1, 0),
                    'L' => (0, -1),
                    _ => (0, 0)
                };

                if (0 <= (row + newRow) && (row + newRow) <= 2 &&
                        0 <= (col + newCol) && (col + newCol) <= 2)
                {
                    (row, col) = (row + newRow, col + newCol);
                }
            }

            solution.Append(keypad[row][col]);
        }

        Console.WriteLine($"Part One: {solution}");
    }

    public void PartTwo(string path)
    {
        Console.WriteLine($"No Part Two yet");
    }


}
