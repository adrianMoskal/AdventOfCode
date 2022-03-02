using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2020.Day2
{
    class Solver : ISolver
    {
        public string Path { get; set; }
        public void PartOne()
        {
           var lines = File.ReadAllLines(Path).ToList();

           var passwords = new List<PasswordPolicy>();
           lines.ForEach(x => passwords.Add(new PasswordPolicy(x)));

           int solution = passwords.Count(p => p.OldValidation());

           System.Console.WriteLine($"Part One: {solution}");
        }

        public void PartTwo()
        {
            var lines = File.ReadAllLines(Path).ToList();

            var passwords = new List<PasswordPolicy>();
            lines.ForEach(x => passwords.Add(new PasswordPolicy(x)));

            int solution = passwords.Count(p => p.NewValidation());

            System.Console.WriteLine($"Part Two: {solution}");
        }
    }
}
