namespace AdventOfCode._2015.Day3;

internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string moves = File.ReadAllText(path);

        HashSet<Tuple<int, int>> houses = Deliver(moves);
        int solution = houses.Count();

        Console.WriteLine($"Part One: {solution}");
    }

    public void PartTwo(string path)
    {
        string moves = File.ReadAllText(path);

        var santaMoves = moves.Where((move, ind) => ind % 2 == 0);
        var roboSantaMoves = moves.Where((move, ind) => ind % 2 != 0);

        HashSet<Tuple<int, int>> santaHouses = Deliver(santaMoves);
        HashSet<Tuple<int, int>> roboSantaHouses = Deliver(roboSantaMoves);

        santaHouses.UnionWith(roboSantaHouses);

        int solution = santaHouses.Count();

        Console.WriteLine($"Part Two: {solution}");
    }


    private HashSet<Tuple<int, int>> Deliver(IEnumerable<char> moves)
    {
        HashSet<Tuple<int, int>> houses = new HashSet<Tuple<int, int>>();

        int x = 0, y = 0;
        foreach (var move in moves)
        {
            switch (move)
            {
                case '^':
                    y++;
                    break;
                case '>':
                    x++;
                    break;
                case 'v':
                    y--;
                    break;
                case '<':
                    x--;
                    break;
            }
            houses.Add(new Tuple<int, int>(x, y));
        }

        return houses;
    }
}
