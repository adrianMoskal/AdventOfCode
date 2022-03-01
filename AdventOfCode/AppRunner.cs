using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class AppRunner
    {
        public static void Run(string[] args)
        {
            try
            {
                Validator.Validate(args);

                StringBuilder inputString = new StringBuilder("AdventOfCode._");

                foreach (var arg in args)
                {
                    inputString.Append(arg + ".");
                }
                inputString.Append("Solver");

                Type type = Type.GetType(inputString.ToString());
                dynamic o = Activator.CreateInstance(type);
                ISolver solver = (ISolver)o;
                o.Path = string.Format("{0}{1}{2}{1}puzzleInput.txt", Environment.CurrentDirectory, Path.DirectorySeparatorChar, string.Join(Path.DirectorySeparatorChar, args));

                solver.PartOne();
                solver.PartTwo();
            }

            catch (ArgumentNullException)
            {
                Console.WriteLine("There is no solution for this quiz yet :c");
            }
            catch (AdventOfCodeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
