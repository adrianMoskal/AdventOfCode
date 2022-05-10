﻿namespace AdventOfCode._2021.Day2;

class Solver : ISolver
{
    public string Path { get; set; }
    public void PartOne()
    {
        string[] lines = File.ReadAllLines(Path);

        var state = Dive(lines, false).Last();
        int solution = state[0] * state[1];

        Console.WriteLine($"Part One: {solution}");
    }

    public void PartTwo()
    {
        string[] lines = File.ReadAllLines(Path);

        var state = Dive(lines, true).Last();
        int solution = state[0] * state[1];

        Console.WriteLine($"Part Two: {solution}");
    }

    private IEnumerable<List<int>> Dive(string[] instructions, bool aiming)
    {
        var state = new List<int>() { 0, 0, 0 };
        yield return state;

        if (aiming)
        {
            foreach (var instruction in instructions)
            {
                string command = instruction.Split(" ")[0];
                int value = int.Parse(instruction.Split(" ")[1]);

                state = new List<int>(state);
                switch (command)
                {
                    case "forward":
                        state[0] += value;
                        state[1] += state[2] * value;
                        break;
                    case "down":
                        state[2] += value;
                        break;
                    case "up":
                        state[2] -= value;
                        break;
                }
                yield return state;
            }
        }
        else
        {
            foreach (var instruction in instructions)
            {
                string command = instruction.Split(" ")[0];
                int value = int.Parse(instruction.Split(" ")[1]);

                state = new List<int>(state);
                switch (command)
                {
                    case "forward":
                        state[0] += value;
                        break;
                    case "down":
                        state[1] += value;
                        break;
                    case "up":
                        state[1] -= value;
                        break;
                }
                yield return state;
            }
        }
        
    }
}
