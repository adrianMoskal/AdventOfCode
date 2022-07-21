namespace AdventOfCode._2016.Day3;

[Date(Year = "2016", Day = "3")]
[PuzzleName("Squares With Three Sides")]
internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string[] lines = File.ReadAllLines(path);

        int solution = Parse(lines)
            .Count(t => ValidTriangle(t));

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        string[] lines = File.ReadAllLines(path);

        var solution = GetTransposedTriangles(Parse(lines))
            .Count(t => ValidTriangle(t));

        AdventConsole.PartTwo(solution);
    }

    private IEnumerable<IEnumerable<int>> Parse(IEnumerable<string> input)
        => input.Select(l => Regex.Matches(l, @"\d+")
                .Select(x => int.Parse(x.Value)));

    private bool ValidTriangle(IEnumerable<int> triangle)
    {
        return triangle.ElementAt(0) + triangle.ElementAt(1) > triangle.ElementAt(2)
            && triangle.ElementAt(0) + triangle.ElementAt(2) > triangle.ElementAt(1)
            && triangle.ElementAt(1) + triangle.ElementAt(2) > triangle.ElementAt(0);
    }

    private IEnumerable<IEnumerable<int>> GetTransposedTriangles(IEnumerable<IEnumerable<int>> lines)
    {
        var transposedMatrix = Transpose(lines);
        var transposedTriangles = new List<List<int>>();

        transposedMatrix.ToList().ForEach(t =>
        {
            for (int i = 0; i < t.Count() - 2; i += 3)
                transposedTriangles.Add(t.Skip(i).Take(3).ToList());
        });

        return transposedTriangles;
    }

    private IEnumerable<IEnumerable<int>> Transpose(IEnumerable<IEnumerable<int>> matrix)
    {
        var transposed = new List<List<int>>();

        for (int i = 0; i < matrix.First().Count(); i++)
        {
            var row = new List<int>();

            for (int j = 0; j < matrix.Count(); j++)
                row.Add(matrix.ElementAt(j).ElementAt(i));

            transposed.Add(row);
        }

        return transposed;
    }
}
