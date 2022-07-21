using System.Reflection;

namespace AdventOfCode;

internal static class AppRunner
{
    public static void Run(string[] args)
    {
        try
        {
            Validator.Validate(args);

            Type? type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t =>
                            t.GetCustomAttribute<DateAttribute>()?.Year == args[0] &&
                            t.GetCustomAttribute<DateAttribute>()?.Day == args[1])
                                ?? throw new AdventOfCodeException(AdventOfCodeErrorType.MissingSolutionError);

            dynamic? o = Activator.CreateInstance(type);

            ISolver? solver = (ISolver?)o
                ?? throw new AdventOfCodeException(AdventOfCodeErrorType.InterfaceMatchError);

            string? currentDir = Environment.CurrentDirectory.Contains("Debug")
                ? string.Format("..{0}..{0}..{0}", Path.DirectorySeparatorChar, Environment.CurrentDirectory)
                    : Environment.CurrentDirectory;

            string? endpoint = type.Namespace?.Substring(type.Namespace.IndexOf('_') + 1)
                .Replace('.', Path.DirectorySeparatorChar);

            string? path = string.Format("{0}{1}{2}{1}puzzleInput.txt", currentDir,
                Path.DirectorySeparatorChar, endpoint);

            var dateAttr = type.GetCustomAttribute<DateAttribute>() 
                ?? throw new ArgumentException();

            var nameAttr = type.GetCustomAttribute<PuzzleName>() 
                ?? throw new ArgumentException();

            AdventConsole.PrintTitle(dateAttr.Year, dateAttr.Day, nameAttr.Name);

            solver.PartOne(path);
            solver.PartTwo(path);
        }
        catch (AdventOfCodeException e)
        {
            AdventConsole.WriteLineError(e.Message);
        }
    }
}
