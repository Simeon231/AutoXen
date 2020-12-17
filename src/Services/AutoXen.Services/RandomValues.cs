namespace AutoXen.Services
{
    using System;
    using System.Collections.Generic;

    public static class RandomValues
    {
        public static IEnumerable<int> RandomUniqueNumbers(int maxNumber, int count)
        {
            var nums = new HashSet<int>();

            for (int i = 0; i < count; i++)
            {
                nums.Add(new Random().Next(1, maxNumber + 1));
            }

            return nums;
        }

        public static double RandomPrice(double maxPrice = 100.0)
        {
            return Math.Round(new Random().NextDouble() * maxPrice, 2);
        }
    }
}
