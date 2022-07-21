namespace AdventOfCode._2019.Day2;

internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string input = File.ReadAllText(path);
        int[] numbersInput = input.Split(",").Select(Int32.Parse).ToArray();
        int? solution = null;

        IntcodeComputer computer = new IntcodeComputer(numbersInput);
        computer.PrepareProgram();

        computer.RestoreGravityAssistProgram();
        solution = computer.ValueAt(0);

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        string input = File.ReadAllText(path);
        int[] numbersInput = input.Split(",").Select(Int32.Parse).ToArray();

        IntcodeComputer computer = new IntcodeComputer(numbersInput);

        bool flag = false;
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
                break;
        }

        var solution = 100 * computer.Noun + computer.Verb;

        AdventConsole.PartTwo(solution);
    }
}
