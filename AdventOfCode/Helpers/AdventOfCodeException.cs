namespace AdventOfCode.Helpers;

internal class AdventOfCodeException : Exception
{
    public AdventOfCodeException(AdventOfCodeErrorType error)
        : base(CreateMessage(error)) { }

    private static string CreateMessage(AdventOfCodeErrorType error) => error switch
    {
        AdventOfCodeErrorType.GetTypeError
            => "Cannot get type from provided input",
        AdventOfCodeErrorType.InterfaceMatchError
            => "Object created from input cannot implement ISolver interface",
        AdventOfCodeErrorType.ArgumentsError
            => "Wrong format!\ndotnet run <year> Day<number>",
        AdventOfCodeErrorType.YearArgumentError
            => "Year has to be number between 2015-2021",
        AdventOfCodeErrorType.DayArgumentError
            => "Second argument has to be 'Day<number>' (capitalized day)",
        AdventOfCodeErrorType.DayNumberError
            => "Day<number>: number has to be number between 1 - 25",
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
