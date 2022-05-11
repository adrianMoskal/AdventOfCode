namespace AdventOfCode.Helpers;

internal static class Extensions
{
    public static string Capitalize(this string text)
        => char.ToUpper(text[0]) + text.Substring(1);
}
