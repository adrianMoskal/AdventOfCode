namespace AdventOfCode.Helpers;

internal interface ISolver
{
    string? Path { get; set; }
    void PartOne();
    void PartTwo();
}
