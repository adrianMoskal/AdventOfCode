namespace AdventOfCode._2016.Day2;

internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string[] lines = File.ReadAllLines(path);

        var keypad = new string[] { "123", "456", "789" };

        string solution = FindBathroomCode(keypad, lines);

        Console.WriteLine($"Part One: {solution}");
    }

    public void PartTwo(string path)
    {
        string[] lines = File.ReadAllLines(path);

        var keypad = new string[] { "  1  ", " 234 ", "56789", " ABC ", "  D  " };

        string solution = FindBathroomCode(keypad, lines);

        Console.WriteLine($"Part Two: {solution}");
    }

    string FindBathroomCode(string[] keypad, string[] directions)
    {
        var (row, col) = FindFive(keypad); // Start at 5

        var code = new StringBuilder();

        foreach (var line in directions)
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

                if ((0 <= (row + newRow) && (row + newRow) <= keypad.Length - 1 &&
                        0 <= (col + newCol) && (col + newCol) <= keypad[0].Length - 1) &&
                            keypad[row + newRow][col + newCol] != ' ')
                {
                    (row, col) = (row + newRow, col + newCol);
                }
            }

            code.Append(keypad[row][col]);
        }

        return code.ToString();
    }

    (int, int) FindFive(string[] keypad)
    {
        for(int row = 0; row < keypad.Length; row++)
            for(int col = 0; col < keypad[0].Length; col++)
                if (keypad[row][col] == '5')
                    return (row, col);

        return (0, 0);
    }

}
