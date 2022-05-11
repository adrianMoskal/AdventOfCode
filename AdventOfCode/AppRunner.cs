namespace AdventOfCode;

internal static class AppRunner
{
    public static void Run(string[] args)
    {
        try
        {
            Validator.Validate(args);

            string argsInput = string.Format("AdventOfCode._{0}.{1}.Solver", args[0], args[1].Capitalize());

            Type? type = Type.GetType(argsInput)
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
