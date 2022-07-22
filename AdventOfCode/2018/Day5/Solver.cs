namespace AdventOfCode._2018.Day5;

[Date(Year = "2018", Day = "5")]
[PuzzleName("Alchemical Reduction")]
internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        var input = File.ReadAllText(path);

        var polymer = new Stack<char>();

        input.ToList().ForEach(unit =>
        {
            if (polymer.Count > 0 && unit != polymer.Peek()
                && char.ToUpper(unit) == char.ToUpper(polymer.Peek()))
                polymer.Pop();
            else
                polymer.Push(unit);
        });

        int solution = polymer.Count;

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        var input = File.ReadAllText(path);
        var unitTypes = Enumerable.Range('A', 'Z' - 'A' + 1);

        int solution = input.Length;

        foreach (char type in unitTypes)
        {
            var polymer = new Stack<char>();

            foreach (var unit in input)
            {
                if (char.ToUpper(unit) == type)
                    continue;

                if (polymer.Count > 0 && unit != polymer.Peek()
                    && char.ToUpper(unit) == char.ToUpper(polymer.Peek()))
                        polymer.Pop();
                else
                    polymer.Push(unit);
            }

            if (polymer.Count < solution)
                solution = polymer.Count;
        }
        
        AdventConsole.PartTwo(solution);
    }
}
