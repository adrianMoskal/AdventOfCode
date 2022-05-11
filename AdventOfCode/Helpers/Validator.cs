namespace AdventOfCode.Helpers;

internal static class Validator
{
    public static void Validate(string[] args)
    {
        ValidateArgumentsLength(args);
        ValidateYear(args[0]);
        ValidateDay(args[1]);
    }

    private static void ValidateArgumentsLength(string[] args)
    {
        if (args.Length != 2)
            throw new AdventOfCodeException(AdventOfCodeErrorType.ArgumentsError);
    }

    private static void ValidateYear(string yearArg)
    {
        bool successfullyParsed = int.TryParse(yearArg, out int year);

        if (successfullyParsed)
            ValidateYearRange(year);
        else
            throw new AdventOfCodeException(AdventOfCodeErrorType.YearArgumentError);
    }

    private static void ValidateYearRange(int year)
    {
        if (2015 > year || year > 2021)
            throw new AdventOfCodeException(AdventOfCodeErrorType.YearArgumentError);
    }

    private static void ValidateDay(string dayArg)
    {
        ValidateDayContent(dayArg);
        ValidateDayIsNumber(dayArg);
    }

    private static void ValidateDayContent(string dayArg)
    {
        if (!dayArg.ToLower().StartsWith("day"))
            throw new AdventOfCodeException(AdventOfCodeErrorType.DayArgumentError);
    }

    private static void ValidateDayIsNumber(string dayArg)
    {
        bool successfullyParsed = int.TryParse(dayArg.Substring(3), out int day);

        if (successfullyParsed)
            ValidateDayRange(day);
        else
            throw new AdventOfCodeException(AdventOfCodeErrorType.DayNumberError);
    }

    private static void ValidateDayRange(int day)
    {
        if (1 > day || day > 25)
            throw new AdventOfCodeException(AdventOfCodeErrorType.DayNumberError);
    }
}
