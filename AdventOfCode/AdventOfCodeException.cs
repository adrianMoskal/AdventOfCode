using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public enum AdventOfCodeError
    {
        ArgumentsError,
        YearArgumentError,
        DayArgumentError,
        DayNumberError
    }

    public class AdventOfCodeException : Exception
    {
        public AdventOfCodeException(AdventOfCodeError error) : base(CreateMessage(error))
        {
        }

        private static string CreateMessage(AdventOfCodeError error)
        {
            switch(error)
            {
                case AdventOfCodeError.ArgumentsError:
                    return "Wrong format!\ndotnet run <year> Day<number>";
                case AdventOfCodeError.YearArgumentError:
                    return "Year has to be number between 2015-2021";
                case AdventOfCodeError.DayArgumentError:
                    return "Second argument has to be 'Day<number>' (capitalized day)";
                case AdventOfCodeError.DayNumberError:
                    return "Day<number>: number has to be number between 1 - 25";
                default:
                    return "Something went wrong";
            }
        }
    }
}
