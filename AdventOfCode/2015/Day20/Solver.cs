namespace AdventOfCode._2015.Day20;

internal sealed class Solver : ISolver
{
    public string Path { get; set; }

    public void PartOne()
    {
        int input = int.Parse(File.ReadAllText(Path));

        int solution = HousePresents(10).First(x => x.Item2 >= input).Item1;

        Console.WriteLine($"Part One: {solution}");
    }

    public void PartTwo()
    {
        int input = int.Parse(File.ReadAllText(Path));

        int solution = HousePresents(11, true).First(x => x.Item2 >= input).Item1;

        Console.WriteLine($"Part Two: {solution}");
    }

    IEnumerable<Tuple<int, int>> HousePresents(int presentsForHouse, bool stop=false)
    {
        int[] houses = new int[int.MaxValue / 100];
        for (int elf = 1; elf < houses.Length; elf++)
        {
            int counter = 0;
            var elfHouse = elf;
            while (elfHouse < houses.Length && (stop ? counter < 50 : true))
            {
                houses[elfHouse] += elf * presentsForHouse;
                elfHouse += elf;
                counter++;
            }

            yield return new Tuple<int, int>(elf, houses[elf]);
        }
    }
}
