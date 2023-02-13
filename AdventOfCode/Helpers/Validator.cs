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
        if (year < 2015 || year > 2022)
            throw new AdventOfCodeException(AdventOfCodeErrorType.YearArgumentError);
    }

    private static void ValidateDay(string dayArg)
    {
        bool successfullyParsed = int.TryParse(dayArg, out int day);

        if (successfullyParsed)
            ValidateDayRange(day);
        else
            throw new AdventOfCodeException(AdventOfCodeErrorType.DayNumberError);
    }

    private static void ValidateDayRange(int day)
    {
        if (day < 1 || day > 25)
            throw new AdventOfCodeException(AdventOfCodeErrorType.DayNumberError);
    }
}
