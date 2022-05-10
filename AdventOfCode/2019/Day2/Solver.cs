namespace AdventOfCode._2019.Day2;

internal sealed class Solver : ISolver
{
    public string Path { get; set; }

    public void PartOne()
    {
        string input = File.ReadAllText(Path);
        int[] numbersInput = input.Split(",").Select(Int32.Parse).ToArray();
        int? solution = null;

        IntcodeComputer computer = new IntcodeComputer(numbersInput);
        computer.PrepareProgram();

        try
        {
            computer.RestoreGravityAssistProgram();
            solution = computer.ValueAt(0);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        if (solution != null)
        {
            Console.WriteLine($"Part One: {solution}");
        }
    }

    public void PartTwo()
    {
        string input = File.ReadAllText(Path);
        int[] numbersInput = input.Split(",").Select(Int32.Parse).ToArray();

        IntcodeComputer computer = new IntcodeComputer(numbersInput);

        bool flag = false;
        try
        {
            for (int i = 0; i <= 99; i++)
            {
                computer.Noun = i;
                for (int j = 0; j <= 99; j++)
                {
                    computer.Verb = j;
                    computer.PrepareProgram();
                    computer.RestoreGravityAssistProgram();

                    if (computer.ValueAt(0) == 19690720)
                    {
                        flag = true;
                        break;
                    }

                    computer.RestoreToDefault();
                }

                if (flag)
                {
                    break;
                }
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine($"Part Two: {100 * computer.Noun + computer.Verb}");
    }
}
