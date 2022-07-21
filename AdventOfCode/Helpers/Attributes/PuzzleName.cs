namespace AdventOfCode.Helpers.Attributes;

[AttributeUsage(AttributeTargets.Class)]
internal class PuzzleName : Attribute
{
    public string Name { get; set; }

    public PuzzleName(string name)
        => Name = name;
}