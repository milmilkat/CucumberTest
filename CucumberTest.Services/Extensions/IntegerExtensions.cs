using System.Collections.Generic;

namespace CucumberTest.Services.Extensions
{
    public static class IntegerExtensions
    {
        private static readonly Dictionary<int, string> _lessThanTwentydPair = new Dictionary<int, string>() {
            { 0, "zero" }, { 1, "one" }, { 2, "two" }, { 3, "three" }, { 4, "four" },
            { 5, "five" }, { 6, "six" }, { 7, "seven" }, { 8, "eight" }, { 9, "nine" },
            { 10, "ten" }, { 11, "eleven" }, { 12, "twelve" }, { 13, "thirteen" },
            { 14, "fourteen" }, { 15, "fifteen" }, { 16, "sixteen" }, { 17, "seventeen" },
            { 18, "eighteen" }, { 19, "nineteen" }
        };

        private static readonly Dictionary<int, string> _greaterThanTwentyPair = new Dictionary<int, string>() {
            { 2, "twenty" }, { 3, "thirty" }, { 4, "fourty" }, { 5, "fifty" },
            { 6, "sixty" }, { 7, "seventy" }, { 8, "eighty" }, { 9, "ninety" }
        };

        private static readonly Dictionary<int, string> _suffixPair = new Dictionary<int, string>() {
            { 2, "hundred" }, { 3, "thousand" }, { 4, "million" }, { 5, "billion" }
        };

        public static string ToWord(this int number)
        {
            var result = string.Empty;
            var processedDigits = 0;

            if (number < 20)
                return GetLessThanTwentyWord(number);

            // If the number is just two digist, but not less than 20
            if (number / 100 < 1)
            {
                var nth = number % 10;
                number = decimal.ToInt32(number / 10);
                result = nth > 0
                    ? $"{GetGreaterThanTwentyWord(number)} {GetLessThanTwentyWord(nth)}"
                    : $"{GetGreaterThanTwentyWord(number)}";
                return result;
            }

            while (number / 10 >= 1)
            {
                var nth = number % 10;
                number = decimal.ToInt32(number / 10);

                if (nth != 0)
                {
                    if (processedDigits == 1)
                        result = $"{GetGreaterThanTwentyWord(nth)} " + result;
                    else
                        result = processedDigits > 0
                            ? $"{GetLessThanTwentyWord(nth)} {GetSuffixText(processedDigits, nth)} and " + result
                            : $"{ GetLessThanTwentyWord(nth)} " + result;
                }

                processedDigits++;
            }

            result = $"{GetLessThanTwentyWord(number)} {GetSuffixText(processedDigits, number)} and " + result;
            return result.Trim();
        }

        private static string GetGreaterThanTwentyWord(int number)
            => _greaterThanTwentyPair[number];

        private static string GetLessThanTwentyWord(int number)
            => _lessThanTwentydPair[number];

        private static string GetSuffixText(int digit, int number)
            => number > 1 ? _suffixPair[digit] + "s" : _suffixPair[digit];
    }
}
