﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015.Day4
{
    class Solver : ISolver
    {
        private const string Path = @"../../../2015/Day4/puzzleInput.txt";

        public void PartOne()
        {
            string input = File.ReadAllText(Path);
            string prefix = "00000";

            int solution = Enumerable.Range(1, int.MaxValue).First(x => CreateMD5(input + x).StartsWith(prefix));

            Console.WriteLine($"Part One: {solution}");
        }

        public void PartTwo()
        {
            string input = File.ReadAllText(Path);
            string prefix = "000000";

            int solution = Enumerable.Range(1, int.MaxValue).First(x => CreateMD5(input + x).StartsWith(prefix));

            Console.WriteLine($"Part One: {solution}");
        }

        public static string CreateMD5(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(input));

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
