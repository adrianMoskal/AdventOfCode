namespace AdventOfCode;

internal static class AppRunner
{
    public static void Run(string[] args)
    {
        try
        {
            Validator.Validate(args);

            StringBuilder inputString = new StringBuilder("AdventOfCode._");
            foreach (var arg in args)
                inputString.Append(arg + ".");

            inputString.Append("Solver");

            Type? type = Type.GetType(inputString.ToString())
                ?? throw new AdventOfCodeException(AdventOfCodeErrorType.GetTypeError);

            dynamic? o = Activator.CreateInstance(type);

            ISolver? solver = (ISolver?)o
                ?? throw new AdventOfCodeException(AdventOfCodeErrorType.InterfaceMatchError);

            string? path = string.Format("{0}{1}{2}{1}puzzleInput.txt", Environment.CurrentDirectory,
                Path.DirectorySeparatorChar, string.Join(Path.DirectorySeparatorChar, args));

            solver.PartOne(path);
            solver.PartTwo(path);
        }

        catch (ArgumentNullException)
        {
            Console.WriteLine("There is no solution for this quiz yet :c");
        }
        catch (AdventOfCodeException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
