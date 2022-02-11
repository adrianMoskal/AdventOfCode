﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015.Day11
{
    class Solver : ISolver
    {
        private const string Path = @"../../../2015/Day11/puzzleInput.txt";

        public void PartOne()
        {
            string password = File.ReadAllText(Path);

            password = PasswordChanger(password).ElementAt(0);

            Console.WriteLine($"Part One: {password}");
        }

        public void PartTwo()
        {
            string password = File.ReadAllText(Path);

            password = PasswordChanger(password).ElementAt(1);

            Console.WriteLine($"Part Two: {password}");
        }

        IEnumerable<string> PasswordChanger(string password)
        {
            for(int i = 0; i < int.MaxValue; i++)
            {
                password = PasswordIncrementation(password);

                while (!IncreasingRequirements(password) || !ForbiddenRequirement(password) || !PairRequirement(password))
                {
                    password = PasswordIncrementation(password);
                }

                yield return password;
            } 
        }

        private string PasswordIncrementation(string password)
        {
            int min = 'a';
            int max = 'z';
            int last = password.Length - 1;

            StringBuilder result = new StringBuilder();
            while (last >= 0)
            {
                if (password[last] == max)
                {
                    result.Append((char)min);
                    last--;
                }
                else
                {
                    int character = password[last];
                    result.Append((char)++character);
                    last--;
                    break;
                }
            }

            for (int i = last; i >= 0; i--)
                result.Append(password[i]);

            return string.Join("", result.ToString().Reverse());
        }

        private bool IncreasingRequirements(string password)
        {
            return Enumerable.Range(0, password.Length - 3).Any(x => password[x+1] - password[x] == 1 && password[x + 2] - password[x + 1] == 1);
        }

        private bool ForbiddenRequirement(string password)
        {
            return !(password.Contains('i') || password.Contains('o') || password.Contains('l'));
        }

        private bool PairRequirement(string password)
        {
            int i = 0;
            int count = 0;

            while (i < password.Length - 1)
            {
                if (password[i] == password[i + 1])
                {
                    count++;
                    i += 2;
                }
                else
                {
                    i++;
                }
            }

            return count > 1;
        }
    }
}