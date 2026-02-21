using FluentAssertions;
using Xunit;

namespace ReadTimeEstimator.Tests;

public class UtilitiesTests
{
    [Fact]
    public void ShouldHandleTimeSmallerThanHalfAMinute()
    {
        var timeInMinutes = 0.4;
        var response = Utilities.HumanizeTime(timeInMinutes);
        response.Should().Be("less than a minute");
    }
        
    [Fact]
    public void ShouldHandleTimeJustOverHHalfAMinute()
    {
        var timeInMinutes = 0.68;
        var response = Utilities.HumanizeTime(timeInMinutes);
        response.Should().Be("1 minute");
    }
        
    [Fact]
    public void ShouldHandleTimeWellOverAMinute()
    {
        var timeInMinutes = 12.10;
        var response = Utilities.HumanizeTime(timeInMinutes);
        response.Should().Be("13 minutes");
    }
}