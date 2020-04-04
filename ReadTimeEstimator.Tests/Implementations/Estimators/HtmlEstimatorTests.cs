using FluentAssertions;
using ReadTimeEstimator.Implementations.Estimators;
using Xunit;

namespace ReadTimeEstimator.Tests.Implementations.Estimators
{
    public class HtmlEstimatorTests
    {
        [Fact]
        public void ShouldHandleNullInput()
        {
            var estimator = new HtmlEstimator();
            var time = estimator.ReadTimeInMinutes(null);
            time.Should().Be(0.0);
        }
        
        [Fact]
        public void ShouldHandleWhitespaceInput()
        {
            var estimator = new HtmlEstimator();
            var time = estimator.ReadTimeInMinutes("        ");
            time.Should().Be(0.0);
        }
    }
}
