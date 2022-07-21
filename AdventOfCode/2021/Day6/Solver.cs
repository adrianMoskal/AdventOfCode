namespace AdventOfCode._2021.Day6;

internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        var lanternFishes = File.ReadAllText(path)
            .Split(',')
            .Select(int.Parse)
            .ToList();

        int solution = FishesGenerator(lanternFishes)
            .Skip(80)
            .Take(1)
            .First()
            .Count();

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        Console.WriteLine($"\tNo Part Two yet");
    }

    IEnumerable<IEnumerable<int>> FishesGenerator(List<int> fishes)
    {
        yield return fishes;

        for(int i = 0; i < int.MaxValue; i++)
        {
            fishes = fishes.Select(x => --x).ToList();

            fishes.Where(x => x < 0).ToList().ForEach(x =>
                fishes.Add(8));

            fishes = fishes.Select(x => x < 0 ? x = 6 : x).ToList();

            yield return fishes;
        }
    }
}
