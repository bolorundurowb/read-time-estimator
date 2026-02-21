using System.Text.RegularExpressions;
using ReadTimeEstimator.Extensions;
using ReadTimeEstimator.Implementations.Patterns;
using ReadTimeEstimator.Interfaces;

namespace ReadTimeEstimator.Implementations.Estimators;

public class MarkdownEstimator : IMarkupEstimator
{
    /// <inherit />
    public double ReadTimeInMinutes(string? markup)
    {
        if (string.IsNullOrWhiteSpace(markup))
            return 0.0;

        var trimmedString = markup!.Trim();

        var patterns = new MarkdownPatterns();
        var imageReadTime = trimmedString.GetImageReadTimeInMinutes(patterns);
        var codeBlocksPenalty = trimmedString.GetCodeBlocksPenaltyInMinutes(patterns);

        // remove markdown image constructs from word calculation to avoid counting alt text/urls as words
        var imageRegex = new Regex(patterns.ImagePattern, RegexOptions.Multiline);
        var textWithoutImages = imageRegex.Replace(trimmedString, string.Empty);

        var wordsReadTime = textWithoutImages.GetWordReadTimeInMinutes(patterns);
        return imageReadTime + codeBlocksPenalty + wordsReadTime;
    }

    /// <inherit />
    public string HumanFriendlyReadTime(string markup)
    {
        var readTime = ReadTimeInMinutes(markup);
        return Utilities.HumanizeTime(readTime);
    }
}