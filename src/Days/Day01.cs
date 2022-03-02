using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 1)]
    public class Day01 : BaseDay
    {
        public override string PartOne(string input)
        {
            List<int> numbers = input.Integers().ToList();
            HashSet<int> uniqueNumbers = new();
            int result = 0;

            for(int i = 0; i < numbers.Count; i++)
            {
                int inverse = Math.Abs(numbers[i] - 2020);
                if (uniqueNumbers.Contains(inverse))
                {
                    result = inverse * numbers[i];
                    break;
                }

                uniqueNumbers.Add(numbers[i]);
            }

            return result.ToString();
        }

        public override string PartTwo(string input)
        {
            List<int> numbers = input.Integers().ToList();
            numbers.Sort();
            int product = 0;

            for(int i = 0; i < numbers.Count - 2; i++)
            {
                if (i > 0 && numbers[i] == numbers[i - 1])
                    continue;

                int left = i + 1, right = numbers.Count - 1;
                
                while(left < right)
                {
                    int sum = numbers[i] + numbers[left] + numbers[right];

                    if (sum == 2020)
                        return (numbers[i] * numbers[left] * numbers[right]).ToString();
                    else if(sum > 2020)
                        right--;
                    else
                        left++;
                }
            }

            return product.ToString();
        }
    }
}
