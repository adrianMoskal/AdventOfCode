namespace AdventOfCode._2021.Day3;

internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        var bytes = File.ReadAllLines(path).ToList();
        
        var gammaRateBinary = string.Join("", Enumerable.Range(0, bytes[0].Length).Select(x => MostCommonBit(bytes, x)));
        var epsilonRateBinary = string.Join("", gammaRateBinary.Select(b => b == '0' ? '1' : '0'));

        int gammaRate = Convert.ToInt32(gammaRateBinary, 2);
        int epsilonRate = Convert.ToInt32(epsilonRateBinary, 2);

        int solution = gammaRate * epsilonRate;

        Console.WriteLine($"Part One: {solution}");
    }

    public void PartTwo(string path)
    {
        string[] bytes = File.ReadAllLines(path);

        int i = 0;
        var bytesForOxygen = new List<string>(bytes);
        while(bytesForOxygen.Count() > 1)
        {
            bytesForOxygen = bytesForOxygen.Where(b => b[i].Equals(MostCommonBit(bytesForOxygen, i))).ToList();
            i++;
        }

        i = 0;
        var bytesForCO2 = new List<string>(bytes);
        while (bytesForCO2.Count() > 1)
        {
            bytesForCO2 = bytesForCO2.Where(b => !b[i].Equals(MostCommonBit(bytesForCO2, i))).ToList();
            i++;
        }

        int oxygenGeneratorRating = Convert.ToInt32(bytesForOxygen[0], 2);
        int co2ScrubberRating = Convert.ToInt32(bytesForCO2[0], 2);

        int solution = oxygenGeneratorRating * co2ScrubberRating;

        Console.WriteLine($"Part Two: {solution}");
    }

    private char MostCommonBit(List<string> bytes, int position)
    {
        int ones = bytes.Count(b => b.ElementAt(position).Equals('1'));
        int zeroes = bytes.Count(b => b.ElementAt(position).Equals('0'));

        return zeroes > ones ? '0' : '1';
    }
}
