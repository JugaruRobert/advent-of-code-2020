using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 6)]
    public class Day06 : BaseDay
    {
        public override string PartOne(string input)
        {
            int sum = 0;
            List<List<string>> groups = input.Paragraphs().ToList();
            foreach(List<string> group in groups)
            {
                HashSet<char> uniqueQuestions = new HashSet<char>();
                foreach(string answer in group)
                {
                    foreach (char c in answer)
                    {
                        uniqueQuestions.Add(c);
                    }
                }

                sum += uniqueQuestions.Count;
            }

            return sum.ToString();
        }

        public override string PartTwo(string input)
        {
            int sum = 0;
            List<List<string>> groups = input.Paragraphs().ToList();
            foreach (List<string> group in groups)
            {
                Dictionary<char, int> questions = new Dictionary<char, int>();
                foreach (string answer in group)
                {
                    foreach (char c in answer)
                    {
                        questions[c] = questions.GetValueOrDefault(c, 0) + 1;
                    }
                }

                foreach(char key in questions.Keys)
                {
                    if(questions[key] == group.Count)
                    {
                        sum++;
                    }
                }
            }

            return sum.ToString();
        }
    }
}
