using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class AppRunner
    {
        public static void Run(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Wrong format!");
                Console.WriteLine("dotnet run <year> day<number>");
            }

            StringBuilder inputString = new StringBuilder("AdventOfCode._");

            foreach(var arg in args)
            {
                inputString.Append(arg + ".");
            }
            inputString.Append("Solver");

            Type type = Type.GetType(inputString.ToString());
            object o = Activator.CreateInstance(type);
            ISolver solver = (ISolver)o;

            solver.PartOne();
            solver.PartTwo();
        }
    }
}
