namespace AdventOfCode._2015.Day17;

internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string[] lines = File.ReadAllLines(path);
        int[] containers = lines.Select(Int32.Parse).ToArray();

        int solution = Combinations(containers).Where(x => x.Sum() == 150).Count();

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        string[] lines = File.ReadAllLines(path);
        int[] containers = lines.Select(Int32.Parse).ToArray();

        int min = Combinations(containers).Where(x => x.Sum() == 150).Min(c => c.Length);
        int solution = Combinations(containers).Where(x => x.Sum() == 150 && x.Length == min).Count();

        AdventConsole.PartTwo(solution);
    }

    private IEnumerable<int[]> Combinations(int[] elements)
    {
        return Enumerable.Range(0, 1 << (elements.Length)).Select(index => elements.Where((v, i) => (index & (1 << i)) != 0).ToArray());
    }
}
