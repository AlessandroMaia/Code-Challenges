using System;

namespace Source.Services
{
    public class RandomService : IRandomService
    {
        public int RandomInteger(int max)
        {
            Random random = new Random();
            return random.Next(0, max);
        }
    }
}
