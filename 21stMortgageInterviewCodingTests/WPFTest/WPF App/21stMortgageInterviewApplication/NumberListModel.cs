using System;
using System.Collections.Generic;
using System.Linq;

namespace _21stMortgageInterviewApplication
{
    public class NumberListModel
    {
        public List<int> Numbers { get; private set; } = new List<int>();

        public void FromString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Numbers.Clear();
                return;
            }

            try
            {
                Numbers = input.Split(',')
                               .Select(int.Parse)
                               .ToList();
            }
            catch
            {
                Numbers.Clear();
            }
        }

        public int GetNumberCount() => Numbers.Count;

        public int GetLargestNumber() => Numbers.Max();

        public int GetSumOfEvenNumbers() => Numbers.Where(x => x % 2 == 0).Sum();

        public int GetSumOfOddNumbers() => Numbers.Where(x => x % 2 != 0).Sum();

        public List<int> ParseNumbers(string input)
        {
            return input.Split(',')
                        .Select(s => int.TryParse(s, out var n) ? n : (int?)null)
                        .Where(n => n.HasValue)
                        .Select(n => n.Value)
                        .ToList();
        }
    }
}
