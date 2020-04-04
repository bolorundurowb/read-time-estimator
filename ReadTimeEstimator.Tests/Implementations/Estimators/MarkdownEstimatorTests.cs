using FluentAssertions;
using ReadTimeEstimator.Implementations.Estimators;
using Xunit;

namespace ReadTimeEstimator.Tests.Implementations.Estimators
{
    public class MarkdownEstimatorTests
    {
        [Fact]
        public void ShouldHandleNullInput()
        {
            var estimator = new MarkdownEstimator();
            var time = estimator.ReadTimeInMinutes(null);
            time.Should().Be(0.0);
        }

        [Fact]
        public void ShouldHandleWhitespaceInput()
        {
            var estimator = new MarkdownEstimator();
            var time = estimator.ReadTimeInMinutes("        ");
            time.Should().Be(0.0);
        }

        [Fact]
        public void ShouldHandleImagesInput()
        {
            var expectedTimeInMinutes = 33 / 60.0;
            var estimator = new MarkdownEstimator();
            var time = estimator.ReadTimeInMinutes("![x](y) ![x](y) ![x](y)");
            time.Should().Be(expectedTimeInMinutes);
        }

        [Fact]
        public void ShouldHandleMoreThenTenImagesInput()
        {
            var expectedTimeInMinutes = 201 / 60.0;
            var estimator = new MarkdownEstimator();
            var time = estimator.ReadTimeInMinutes(
                "![x](y)![x](y)![x](y)![x](y)![x](y)![x](y)![x](y)![x](y)![x](y)![x](y)![x](y)");
            time.Should().Be(expectedTimeInMinutes);
        }

        [Fact]
        public void ShouldHandlePlainTextInput()
        {
            var expectedTimeInMinutes = 2 / 275.0;
            var estimator = new HtmlEstimator();
            var time = estimator.ReadTimeInMinutes("# Test String");
            time.Should().Be(expectedTimeInMinutes);
        }

        [Fact]
        public void ShouldHandleEastAsianTextInput()
        {
            var expectedTimeInMinutes = 5 / 500.0;
            var estimator = new HtmlEstimator();
            var time = estimator.ReadTimeInMinutes("## 测试字符串");
            time.Should().Be(expectedTimeInMinutes);
        }

        [Fact]
        public void ShouldHandleHumanResponseForEastAsianTextInput()
        {
            var estimator = new HtmlEstimator();
            var readTime = estimator.HumanFriendlyReadTime("## 测试字符串");
            readTime.Should().Be("less than a minute");
        }
    }
}
