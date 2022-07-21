namespace AdventOfCode.Helpers;

internal sealed class AdventOfCodeException : Exception
{
    public AdventOfCodeException(AdventOfCodeErrorType error)
        : base(CreateMessage(error)) { }

    private static string CreateMessage(AdventOfCodeErrorType error) => error switch
    {
        AdventOfCodeErrorType.GetTypeError
            => "\tCannot get type from provided input",
        AdventOfCodeErrorType.InterfaceMatchError
            => "\tObject created from input cannot implement ISolver interface",
        AdventOfCodeErrorType.ArgumentsError
            => "\tWrong format!\ndotnet run <year> day<number>",
        AdventOfCodeErrorType.YearArgumentError
            => "\tYear has to be number between 2015-2021",
        AdventOfCodeErrorType.DayArgumentError
            => "\tSecond argument has to be 'day<number>' or 'Day<number>'",
        AdventOfCodeErrorType.DayNumberError
            => "\tday<number>: number has to be number between 1 - 25",
        _ => "Something went wrong"
    };
}

internal enum AdventOfCodeErrorType
{
    GetTypeError,
    InterfaceMatchError,
    ArgumentsError,
    YearArgumentError,
    DayArgumentError,
    DayNumberError
}
