namespace AdventOfCode._2015.Day7;

[Date(Year = "2015", Day = "7")]
[PuzzleName("Some Assembly Required")]
internal sealed class Solver : ISolver
{

    public void PartOne(string path)
    {
        string[] unresolvedInstructions = File.ReadAllLines(path);
        var signals = new Dictionary<string, ushort>();

        ProcessInstructions(signals, unresolvedInstructions.ToList());

        AdventConsole.PartOne(signals["a"]);
    }

    public void PartTwo(string path)
    {
        var unresolvedInstructions = File.ReadAllLines(path).ToList();
        var signals = new Dictionary<string, ushort>();;

        ProcessInstructions(signals, unresolvedInstructions.ToList());

        var aSignal = signals["a"];
        signals.Clear();
        unresolvedInstructions = unresolvedInstructions.Where(instruction => !instruction.EndsWith("-> b")).ToList();
        signals["b"] = aSignal;

        ProcessInstructions(signals, unresolvedInstructions);

        AdventConsole.PartTwo(signals["a"]);
    }

    private static Dictionary<string, ushort> ProcessInstructions(Dictionary<string, ushort> signals, List<string> unresolvedInstructions)
    {
        while (unresolvedInstructions.Any())
        {
            foreach (var instruction in unresolvedInstructions.ToList())
            {
                var parts = instruction.Split(' ');

                try
                {
                    ushort Resolve(string wireOrValue) => ushort.TryParse(wireOrValue, out var value) ? value : signals[wireOrValue];

                    if (parts.Length == 3 && parts[1] == "->")
                    {
                        signals[parts[2]] = Resolve(parts[0]);
                    }
                    else if (parts[0] == "NOT")
                    {
                        signals[parts[3]] = (ushort)~Resolve(parts[1]);
                    }
                    else
                    {
                        ushort left = Resolve(parts[0]);
                        ushort right = Resolve(parts[2]);

                        signals[parts[4]] = parts[1] switch
                        {
                            "AND" => (ushort)(left & right),
                            "OR" => (ushort)(left | right),
                            "LSHIFT" => (ushort)(left << right),
                            "RSHIFT" => (ushort)(left >> right),
                            _ => throw new InvalidOperationException("Invalid operation")
                        };
                    }

                    unresolvedInstructions.Remove(instruction);
                }
                catch (KeyNotFoundException)
                { }
            }
        }

        return signals;
    }

}
