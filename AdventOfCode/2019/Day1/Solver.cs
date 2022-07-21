namespace AdventOfCode._2019.Day1;

internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string[] lines = File.ReadAllLines(path);
        double solution = lines.Sum(m => Math.Floor(double.Parse(m) / 3) - 2);

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        string[] lines = File.ReadAllLines(path);
        double[] masses = lines.Select(m => Double.Parse(m)).ToArray<double>();

        Stack<double> modulesMass = new Stack<double>(masses);

        double solution = 0;
        while (modulesMass.Any())
        {
            double mass = modulesMass.Pop();
            double fuel = Math.Floor(mass / 3) - 2;

            if (fuel > 0)
            {
                solution += fuel;
                modulesMass.Push(fuel);
            }
        }
        AdventConsole.PartTwo(solution);
    }
}
