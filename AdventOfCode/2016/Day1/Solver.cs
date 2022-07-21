namespace AdventOfCode._2016.Day1;

[Date(Year = "2016", Day = "1")]
[PuzzleName("No Time for a Taxicab")]
internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        var instructions = File.ReadAllText(path)
            .Split(", ").ToList();

        var lastPos = GetPositions(instructions).Last();

        int solution = Math.Abs(lastPos.Item1 - 0) + Math.Abs(lastPos.Item2 - 0);

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        var instructions = File.ReadAllText(path)
            .Split(", ").ToList();

        var positions = GetPositions(instructions);

        var firstTwice = positions.First(x => positions.Count(p => p == x) > 1);

        int solution = Math.Abs(firstTwice.Item1 - 0) + Math.Abs(firstTwice.Item2 - 0);

        AdventConsole.PartTwo(solution);
    }

    private enum Direction
    {
        North,
        South,
        East,
        West
    }

    private static Direction ChangeDirection(Direction currentDirection,
        char direction)
            => direction switch
            {
                'L' => currentDirection is Direction.North ? Direction.West
                    : currentDirection is Direction.West ? Direction.South
                    : currentDirection is Direction.South ? Direction.East
                    : Direction.North,
                'R' => currentDirection is Direction.North ? Direction.East
                    : currentDirection is Direction.East ? Direction.South
                    : currentDirection is Direction.South ? Direction.West
                    : Direction.North,
                _ => throw new ArgumentNullException()
            };

    private IEnumerable<(int, int)> GetPositions(List<string> instructions)
    {
        var direction = Direction.North;
        var (row, col) = (0, 0);

        foreach (var instruction in instructions)
        {
            var steps = Convert.ToInt32(instruction.Substring(1));
            direction = ChangeDirection(direction, instruction[0]);

            for (int i = 0; i < steps; i++)
            {
                (row, col) = direction switch
                {
                    Direction.North => (row, col + 1),
                    Direction.South => (row, col - 1),
                    Direction.East => (row + 1, col),
                    Direction.West => (row - 1, col),
                    _ => throw new ArgumentNullException()
                };
                yield return (row, col);
            } 
        };
    }
}

