using System;

namespace App.Core.Services
{
    public class RandomService
    {
        private readonly Random _random;

        public RandomService(Random random)
        {
            _random = random;
        }

        public int Next()
        {
            return _random.Next();
        }

        public int Next(int maxValue)
        {
            return _random.Next(maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }
}