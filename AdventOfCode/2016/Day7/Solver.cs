﻿namespace AdventOfCode._2016.Day7;

[Date(Year = "2016", Day = "7")]
[PuzzleName("Internet Protocol Version 7")]
internal sealed class Solver : ISolver
{
    public void PartOne(string path)
    {
        string[] lines = File.ReadAllLines(path);

        int solution = lines.Count(x => SupportTLS(x));

        AdventConsole.PartOne(solution);
    }

    public void PartTwo(string path)
    {
        AdventConsole.PartTwoNoSolutionYet();
    }

    private bool SupportTLS(string address)
    {
        var splitted = address.Split('[', ']').ToArray();

        for(int i = 0; i <= splitted.Length - 2; i += 2)
        {
            if (HaveAbba(splitted[i + 1]))
                return false;

            if ((HaveAbba(splitted[i]) || HaveAbba(splitted[i + 2])))
                return true;
        }
            
        return false;
    }

    private bool HaveAbba(string txt)
    {
        for (int i = 0; i < txt.Length - 3; i++)
            if (txt[i] == txt[i + 3] && txt[i + 1] == txt[i + 2] && txt[i] != txt[i + 1])
                return true;

        return false;
    }
}

