using System.Linq;
using Xunit;

namespace LargestStates.Test
{
    public class CountryTest
    {
        [Fact]
        public void Should_Return_10_Itens_When_Get_Top_10_States()
        {
            var states = new Country();
            var top = states.Top10StatesByArea();
            Assert.NotNull(top);
            Assert.Equal(10, top.Length);
        }

        [Fact]
        public void LargestState()
        {
            var states = new Country();
            var first = states.Top10StatesByArea().First();
            Assert.Equal(1559159.148, first.Extension);
            Assert.Equal("AM", first.Acronym);
        }
    }
}