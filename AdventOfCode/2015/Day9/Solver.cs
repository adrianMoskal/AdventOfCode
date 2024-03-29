﻿namespace AdventOfCode._2015.Day9;

[Date(Year = "2015", Day = "9")]
[PuzzleName("All in a Single Night")]
internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string[] lines = File.ReadAllLines(path);

        var verticles = Parse(lines);

        AdventConsole.PartOneNoSolutionYet();
    }

    public void PartTwo(string path)
    {
        AdventConsole.PartTwoNoSolutionYet();
    }

    Dictionary<string, List<(string, int)>> Parse(string[] input)
    {
        var verticles = new Dictionary<string, List<(string, int)>>();

        foreach (var line in input)
        {
            var splited = line.Split(' ');
            var (from, to, dist) = (splited[0], splited[2], int.Parse(splited[4]));

            if (verticles.ContainsKey(from))
                verticles[from].Add((to, dist));
            else
                verticles[from] = new List<(string, int)> { (to, dist) };

            if (verticles.ContainsKey(to))
                verticles[to].Add((from, dist));
            else
                verticles[to] = new List<(string, int)> { (from, dist) };
        }

        return verticles;
    }
}
