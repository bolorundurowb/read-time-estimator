using FluentAssertions;
using Xunit;

namespace ReadTimeEstimator.Tests
{
    public class UtilitiesTests
    {
        [Fact]
        public void BasicTest()
        {
            var timeInMinutes = 0.4;
            var response = Utilities.HumanizeTime(timeInMinutes);
            response.Should().Be("less than a minute");
        }
    }
}
