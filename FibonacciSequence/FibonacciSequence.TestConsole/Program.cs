using System;

namespace FibonacciSequence.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var fibo = new Sequence();
            foreach (var num in fibo.Fibonacci())
            {
                Console.WriteLine(num);
            }
        }
    }
}
