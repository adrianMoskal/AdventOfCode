namespace AdventOfCode._2017.Day8;

internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        var lines = File.ReadAllLines(path).ToList();

        var registers = new Dictionary<string, int>();

        lines.ForEach(line => 
            registers[line.Split(' ')[0]] = 0);

        lines.ForEach(line =>
        {
            var splitted = line.Split(' ');
            var (reg, instr, val, condReg, sym, condVal)
                = (splitted[0], splitted[1], int.Parse(splitted[2]), splitted[4], splitted[5], int.Parse(splitted[6]));

            if (ValidateCondition(registers[condReg], sym, condVal))
                registers[reg] = PerformInstruction(registers[reg], val, instr);
        });

        int solution = registers.Values.Max();

        Console.WriteLine($"Part One: {solution}");
    }

    public void PartTwo(string path)
    {
        var lines = File.ReadAllLines(path).ToList();

        int solution = 0;
        var registers = new Dictionary<string, int>();

        lines.ForEach(line =>
            registers[line.Split(' ')[0]] = 0);

        lines.ForEach(line =>
        {
            var splitted = line.Split(' ');
            var (reg, instr, val, condReg, sym, condVal)
                = (splitted[0], splitted[1], int.Parse(splitted[2]), splitted[4], splitted[5], int.Parse(splitted[6]));

            if (ValidateCondition(registers[condReg], sym, condVal))
                registers[reg] = PerformInstruction(registers[reg], val, instr);

            if (registers[reg] > solution)
                solution = registers[reg];
        });

        Console.WriteLine($"Part Two: {solution}");
    }

    private bool ValidateCondition(int registerValue, string symbol, int conditionValue)
     => symbol switch
     {
         ">" => registerValue > conditionValue,
         "<" => registerValue < conditionValue,
         ">=" => registerValue >= conditionValue,
         "<=" => registerValue <= conditionValue,
         "==" => registerValue == conditionValue,
         "!=" => registerValue != conditionValue,
         _ => throw new ArgumentException()
     };

    private int PerformInstruction(int startValue, int diffValue, string instruction)
     => instruction switch
     {
         "inc" => startValue + diffValue,
         "dec" => startValue - diffValue,
         _ => throw new ArgumentException()
     };
}
