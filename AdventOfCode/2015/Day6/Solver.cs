namespace AdventOfCode._2015.Day6;

internal sealed class Solver : ISolver
{
    private enum Operation
    {
        TurnOn = 0,
        TurnOff,
        Toggle
    }

    public void PartOne(string path)
    {
        string[] lines = File.ReadAllLines(path);
        var instructions = GetInstructions(lines);

        bool[,] grid = new bool[1000, 1000];
        foreach(var instruction in instructions)
        {
            for(int i = instruction.Item2[0]; i <= instruction.Item3[0]; i++)
            {
                for (int j = instruction.Item2[1]; j <= instruction.Item3[1]; j++)
                {
                    if (instruction.Item1 is Operation.TurnOn)
                        grid[i,j] = true;
                    else if (instruction.Item1 is Operation.TurnOff)
                        grid[i, j] = false;
                    else if(instruction.Item1 is Operation.Toggle)
                        grid[i, j] = !grid[i, j];
                }
            }
        }

        int solution = 0;
        for (int i = 0; i < 1000; i++)
        {
            for (int j = 0; j < 1000; j++)
            {
                if(grid[i, j] == true)
                {
                    solution++;
                }
            }
        }

        Console.WriteLine($"Part One: {solution}");
    }

    public void PartTwo(string path)
    {
        string[] lines = File.ReadAllLines(path);
        var instructions = GetInstructions(lines);

        int[,] grid = new int[1000, 1000];
        foreach (var instruction in instructions)
        {
            for (int i = instruction.Item2[0]; i <= instruction.Item3[0]; i++)
            {
                for (int j = instruction.Item2[1]; j <= instruction.Item3[1]; j++)
                {
                    if (instruction.Item1 is Operation.TurnOn)
                    {
                        grid[i, j] = grid[i, j] + 1;
                    }
                    else if (instruction.Item1 is Operation.Toggle)
                    {
                        grid[i, j] = grid[i, j] + 2;
                    }
                    else if (instruction.Item1 is Operation.TurnOff)
                    {
                        if(grid[i, j] > 0)
                        {
                            grid[i, j] = grid[i, j] - 1;
                        }
                    }    
                }
            }
        }

        int solution = 0;
        for (int i = 0; i < 1000; i++)
        {
            for (int j = 0; j < 1000; j++)
            {
                solution += grid[i, j];
            }
        }

        Console.WriteLine($"Part One: {solution}");
    }

    private List<Tuple<Operation, int[], int[]>> GetInstructions(string[] lines)
    {
        var instructions = new List<Tuple<Operation, int[], int[]>>();
        Operation op;
        int[] point1, point2;

        foreach(var line in lines)
        {
            if (line.StartsWith("turn on"))
            {
                string coords1 = line.Substring(8, line.IndexOf("through") - 8);
                point1 = new int[] { int.Parse(coords1.Split(",")[0]), int.Parse(coords1.Split(",")[1]) };

                string coords2 = line.Substring(line.IndexOf("through") + 8);
                point2 = new int[] { int.Parse(coords2.Split(",")[0]), int.Parse(coords2.Split(",")[1]) };

                op = Operation.TurnOn;
            }
            else if(line.StartsWith("turn off"))
            {
                string coords1 = line.Substring(9, line.IndexOf("through") - 9);
                point1 = new int[] { int.Parse(coords1.Split(",")[0]), int.Parse(coords1.Split(",")[1]) };

                string coords2 = line.Substring(line.IndexOf("through") + 8);
                point2 = new int[] { int.Parse(coords2.Split(",")[0]), int.Parse(coords2.Split(",")[1]) };

                op = Operation.TurnOff;
            }
            else
            {
                string coords1 = line.Substring(7, line.IndexOf("through") - 8);
                point1 = new int[] { int.Parse(coords1.Split(",")[0]), int.Parse(coords1.Split(",")[1]) };

                string coords2 = line.Substring(line.IndexOf("through") + 8);
                point2 = new int[] { int.Parse(coords2.Split(",")[0]), int.Parse(coords2.Split(",")[1]) };

                op = Operation.Toggle;
            }

            instructions.Add(new Tuple<Operation, int[], int[]>(op, point1, point2));
        }

        return instructions;
    }

}
