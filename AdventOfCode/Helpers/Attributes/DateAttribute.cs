namespace AdventOfCode.Helpers.Attributes;

[AttributeUsage(AttributeTargets.Class)]
internal class DateAttribute : Attribute
{
    public string Year { get; set; } = string.Empty;
    public string Day { get; set; } = string.Empty;
}
