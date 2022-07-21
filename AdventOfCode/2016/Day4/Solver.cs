namespace AdventOfCode._2016.Day4;

internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string[] lines = File.ReadAllLines(path);

        var realRooms = RemoveDecoyRooms(lines);

        int solution = realRooms.Select(x => GetSector(x))
            .Sum();

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        string[] lines = File.ReadAllLines(path);

        var realRooms = RemoveDecoyRooms(lines);

        int solution = 0;

        foreach(var room in realRooms)
        {
            var sector = GetSector(room);
            var name = GetName(room);

            var decoded = DecodeCipher(name, sector);

            if (decoded.Contains("northpole"))
            {
                solution = sector;
                break;
            }
        }

        AdventConsole.PartTwo(solution);
    }

    private string GetName(string room)
        => room.Substring(0, room.LastIndexOf('-')).Replace("-", "");

    private int GetSector(string room)
        => int.Parse(room.Substring(room.LastIndexOf('-') + 1, room.IndexOf('[') - room.LastIndexOf('-') - 1));

    private string GetChecksum(string room)
        => room.Split('[', ']')[1];

    private string DecodeCipher(string txt, int shift)
        => string.Concat(txt.Select(x => (char)((((x + shift) - 'a') % 26) + 'a')));

    private IEnumerable<string> RemoveDecoyRooms(IEnumerable<string> rooms)
    {
        var realRooms = new List<string>();
        rooms.ToList().ForEach(room =>
        {
            var checksum = GetChecksum(room);
            var name = GetName(room);
            
            var mostCommon = name.OrderBy(x => x)
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Take(5)
                .Select(x => x.Key);

            if (mostCommon.All(x => checksum.Contains(x)))
                realRooms.Add(room);
        });

        return realRooms;
    }
}
