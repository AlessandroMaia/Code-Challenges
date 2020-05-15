using Xunit;

namespace FibonacciSequence.Test
{
    public class SequenceTest
    {
        [Fact]
        public void Fibonacci_Test()
        {
            var sequence = new Sequence();
            var result = sequence.Fibonacci();
            Assert.NotNull(result);
        }

        [Fact]
        public void Is_Fibonacci_Test()
        {
            var sequence = new Sequence();
            Assert.True(sequence.IsFibonacci(5));
        }

        [Fact]
        public void Is_NotFibonacci_Test()
        {
            var sequence = new Sequence();
            Assert.False(sequence.IsFibonacci(4));
        }
    }
}
