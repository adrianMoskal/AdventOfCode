namespace AdventOfCode.Helpers;

internal static class AdventConsole
{
    public static void PartOne(object solution)
    {
        Console.Write("\tPart One: ");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(solution);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void PartTwo(object solution)
    {
        Console.Write("\tPart Two: ");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(solution);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void PrintTitle()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        
        var title = FiggleFonts.Standard.Render("Advent of Code");
        Console.WriteLine(title);

        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void WriteError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }
}
