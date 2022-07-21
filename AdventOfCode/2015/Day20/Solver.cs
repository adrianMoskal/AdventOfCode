namespace AdventOfCode._2015.Day20;

[Date(Year = "2015", Day = "20")]
[PuzzleName("Infinite Elves and Infinite Houses")]
internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        int input = int.Parse(File.ReadAllText(path));

        int solution = HousePresents(10).First(x => x.Item2 >= input).Item1;

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        int input = int.Parse(File.ReadAllText(path));

        int solution = HousePresents(11, true).First(x => x.Item2 >= input).Item1;

        AdventConsole.PartTwo(solution);
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
