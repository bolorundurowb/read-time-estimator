using FluentAssertions;
using ReadTimeEstimator.Implementations.Estimators;
using Xunit;

namespace ReadTimeEstimator.Tests.Implementations.Estimators;

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

    [Fact]
    public void ShouldHandleImagesInput()
    {
        var expectedTimeInMinutes = 33 / 60.0;
        var estimator = new HtmlEstimator();
        var time = estimator.ReadTimeInMinutes("<img /><img/> <Image></Image>");
        time.Should().Be(expectedTimeInMinutes);
    }

    [Fact]
    public void ShouldHandleMoreThenTenImagesInput()
    {
        var expectedTimeInMinutes = 201 / 60.0;
        var estimator = new HtmlEstimator();
        var time = estimator.ReadTimeInMinutes("<Image/><Image/><Image/><Image/><Image/><img/><img/><img/><img/><img/><img/>");
        time.Should().Be(expectedTimeInMinutes);
    }

    [Fact]
    public void ShouldHandlePlainTextInput()
    {
        var expectedTimeInMinutes = 2 / 275.0;
        var estimator = new HtmlEstimator();
        var time = estimator.ReadTimeInMinutes("<div>Test String</div>");
        time.Should().Be(expectedTimeInMinutes);
    }

    [Fact]
    public void ShouldHandleEastAsianTextInput()
    {
        var expectedTimeInMinutes = 5 / 500.0;
        var estimator = new HtmlEstimator();
        var time = estimator.ReadTimeInMinutes("<div>测试字符串</div>");
        time.Should().Be(expectedTimeInMinutes);
    }

    [Fact]
    public void ShouldHandleHumanResponseForEastAsianTextInput()
    {
        var estimator = new HtmlEstimator();
        var readTime = estimator.HumanFriendlyReadTime("<div>测试字符串</div>");
        readTime.Should().Be("less than a minute");
    }
}