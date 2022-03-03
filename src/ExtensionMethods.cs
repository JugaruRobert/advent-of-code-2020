using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class StringManipulationExtensions
    {
        public static IEnumerable<string> Lines(this string input)
        {
            return input.Split(new string[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static IEnumerable<string> Words(this string input)
        {
            return input.Split(new string[] { " ", "\t", Environment.NewLine, ",", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static IEnumerable<int> Integers(this string input)
        {
            return input.Words().Select(x => int.Parse(x)).ToList();
        }

        public static IEnumerable<List<string>> Paragraphs(this string input)
        {
            return input.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries)
                        .Select(paragraph => paragraph.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToList());
        }
        public static IEnumerable<long> Longs(this string input)
        {
            return input.Words().Select(x => long.Parse(x)).ToList();
        }

        public static IEnumerable<double> Doubles(this string input)
        {
            return input.Words().Select(x => double.Parse(x)).ToList();
        }

        public static IEnumerable<T> ParseLines<T>(this string input, Func<string, T> parser)
        {
            return input.Lines().Select(parser);
        }
    }
}