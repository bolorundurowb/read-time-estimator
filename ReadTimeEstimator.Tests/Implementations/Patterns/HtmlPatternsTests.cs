using System;
using FluentAssertions;
using ReadTimeEstimator.Implementations.Patterns;
using Xunit;

namespace ReadTimeEstimator.Tests.Implementations.Patterns;

public class HtmlPatternsTests
{
    [Fact]
    public void ShouldInstantiatePatternSuccessfully()
    {
        Action action = () => new HtmlPatterns();
        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldInstantiatePatternWithExpectedValues()
    {
        var pattern = new HtmlPatterns();
        pattern.Should().NotBeNull();
        pattern.ImagePattern.Should().Be("<(img|Image)([\\w\\W]+?)[\\/]?>");
        pattern.TagsPattern.Should().Be("<[^>]*>");
        pattern.WordsPattern.Should().Be("\\w+");
        pattern.EastAsianCharSetPattern.Should()
            .Be("[\u3040-\u30ff\u3400-\u4dbf\u4e00-\u9fff\uf900-\ufaff\uff66-\uff9f]");
    }
}