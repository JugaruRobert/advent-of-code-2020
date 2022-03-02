using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 2)]
    public class Day02 : BaseDay
    {
        public override string PartOne(string input)
        {
            List<(int min, int max, char letter, string password)> passwords = input.ParseLines(ParsePasswords).ToList();
            return passwords.Count((input) =>
            {
                int letterCount = input.password.Count(c => c == input.letter);
                return letterCount >= input.min && letterCount <= input.max;
            }).ToString();
        }

        public override string PartTwo(string input)
        {
            List<(int left, int right, char letter, string password)> passwords = input.ParseLines(ParsePasswords).ToList();
            return passwords.Count((input) =>
            {
                if (input.password.Length < input.left || input.right > input.password.Length)
                    return false;

                int leftValid = Convert.ToInt32(input.password[input.left - 1] == input.letter);
                int rightValid = Convert.ToInt32(input.password[input.right - 1] == input.letter);
                return leftValid + rightValid == 1;
            }).ToString();
        }

        private (int min, int max, char letter, string password) ParsePasswords(string input)
        {
            string[] segments = input.Split(new char[] { '-', ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);

            int min = int.Parse(segments[0]);
            int max = int.Parse(segments[1]);
            char letter = segments[2][0];
            string password = segments[3];

            return (min, max, letter, password);
        }
    }
}
