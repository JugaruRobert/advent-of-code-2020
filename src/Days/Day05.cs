using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 5)]
    public class Day05 : BaseDay
    {
        public override string PartOne(string input)
        {
            List<string> passes = input.Words().ToList();

            int highestSeatId = int.MinValue;

            foreach(string pass in passes)
            {
                int row = GetSeatValue(pass.Substring(0, 7), 'F', 'B', 0, 127);
                int column = GetSeatValue(pass.Substring(7, 3), 'L', 'H', 0, 7);

                int seatId = row * 8 + column;
                if (seatId > highestSeatId)
                    highestSeatId = seatId;
            }

            return highestSeatId.ToString();
        }

        private int GetSeatValue(string code, char leftChar, char rightChar, int leftBoundary, int rightBoundary)
        {
            int left = leftBoundary, right = rightBoundary;
            foreach(char c in code)
            {
                int middle = left + (right - left) / 2;
                if (c == leftChar)
                    right = middle;
                else
                    left = middle + 1;
            }

            return left;
        }

        public override string PartTwo(string input)
        {
            throw new NotImplementedException();
        }
    }
}
