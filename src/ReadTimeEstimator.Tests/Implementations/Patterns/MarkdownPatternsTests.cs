using System;
using FluentAssertions;
using ReadTimeEstimator.Implementations.Patterns;
using Xunit;

namespace ReadTimeEstimator.Tests.Implementations.Patterns;

public class MarkdownPatternsTests
{
    [Fact]
    public void ShouldInstantiatePatternSuccessfully()
    {
        Action action = () => _ = new MarkdownPatterns();
        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldInstantiatePatternWithExpectedValues()
    {
        var pattern = new MarkdownPatterns();
        pattern.Should().NotBeNull();
        pattern.ImagePattern.Should().Be("(?:!\\[(.*?)\\]\\((.*?)\\))");
        pattern.TagsPattern.Should().BeEmpty();
        pattern.WordsPattern.Should().Be("\\w+");
        pattern.EastAsianCharSetPattern.Should()
            .Be("[\u3040-\u30ff\u3400-\u4dbf\u4e00-\u9fff\uf900-\ufaff\uff66-\uff9f]");
    }
}