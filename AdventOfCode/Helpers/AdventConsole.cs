namespace AdventOfCode.Helpers;

internal static class AdventConsole
{
    public static void WriteLineError(string message)
        => WriteLineRed(message);
    
    public static void PartOneNoSolutionYet()
        => WriteLineDarkGreen("\tThere is no solution for part one yet");

    public static void PartTwoNoSolutionYet()
        => WriteLineDarkGreen("\tThere is no solution for part two yet");

    public static void PartOne(object solution)
    {
        Console.Write("\tPart One: ");
        WriteLineGray(solution.ToString()!);
    }

    public static void PartTwo(object solution)
    {
        Console.Write("\tPart Two: ");
        WriteLineGray(solution.ToString()!);
    }

    public static void PrintTitle(string year, string day, string puzzleName)
    {  
        var title = FiggleFonts.Standard.Render("Advent of Code");
        WriteLineGreen(title);

        WriteLineDarkGreen("\tYear " + year);

        var dayInfo = string.Join(" ", ("Day " + day), puzzleName);
        WriteDarkGreen("\tDay " + day);

        WriteLineYellow(": " + puzzleName + "\n");
    }

    #region WriteColors

    private static void WriteLineGreen(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void WriteLineDarkGreen(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void WriteLineGray(string message)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void WriteLineRed(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }
    private static void WriteLineYellow(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void WriteDarkGreen(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void WriteYellow(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    #endregion
}
