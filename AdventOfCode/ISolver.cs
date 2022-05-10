namespace AdventOfCode;

internal interface ISolver
{
    string? Path { get; set; }
    void PartOne();
    void PartTwo();
}
