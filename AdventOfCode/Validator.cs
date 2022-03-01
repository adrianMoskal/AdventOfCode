using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Validator
    {
        public static void Validate(string[] args)
        {
            ValidateArgumentsLength(args);
            ValidateYear(args[0]);
            ValidateDay(args[1]);
        }

        private static void ValidateArgumentsLength(string[] args)
        {
            if (args.Length != 2)
            {
                throw new AdventOfCodeException(AdventOfCodeError.ArgumentsError);
            }
        }

        private static void ValidateYear(string yearArg)
        {
            int year;
            bool successfullyParsed = int.TryParse(yearArg, out year);

            if (successfullyParsed)
            {
                ValidateYearRange(year);
            }
            else
            {
                throw new AdventOfCodeException(AdventOfCodeError.YearArgumentError);
            }
        }

        private static void ValidateYearRange(int year)
        {
            if (2015 > year || year > 2021)
            {
                throw new AdventOfCodeException(AdventOfCodeError.YearArgumentError);
            }
        }

        private static void ValidateDay(string dayArg)
        {
            ValidateDayIsCapitalized(dayArg);
            ValidateDayIsNumber(dayArg);
        }

        private static void ValidateDayIsCapitalized(string dayArg)
        {
            if (!dayArg.StartsWith("Day"))
            {
                throw new AdventOfCodeException(AdventOfCodeError.DayArgumentError);
            }
        }

        private static void ValidateDayIsNumber(string dayArg)
        {
            int day;
            bool successfullyParsed = int.TryParse(dayArg.Substring(3), out day);

            if (successfullyParsed)
            {
                ValidateDayRange(day);
            }
            else
            {
                throw new AdventOfCodeException(AdventOfCodeError.DayNumberError);
            }
        }

        private static void ValidateDayRange(int day)
        {
            if (1 > day || day > 25)
            {
                throw new AdventOfCodeException(AdventOfCodeError.DayNumberError);
            }
        }
    }
}
