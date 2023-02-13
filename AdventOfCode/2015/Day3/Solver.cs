namespace AdventOfCode._2015.Day3;

[Date(Year = "2015", Day = "3")]
[PuzzleName("Perfectly Spherical Houses in a Vacuum")]
internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string moves = File.ReadAllText(path);

        var houses = Deliver(moves);
        int solution = houses.Count();

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        string moves = File.ReadAllText(path);

        var santaMoves = moves.Where((move, ind) => ind % 2 == 0);
        var roboSantaMoves = moves.Where((move, ind) => ind % 2 != 0);

        var santaHouses = Deliver(santaMoves);
        var roboSantaHouses = Deliver(roboSantaMoves);

        santaHouses.UnionWith(roboSantaHouses);

        int solution = santaHouses.Count();

        AdventConsole.PartTwo(solution);
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
