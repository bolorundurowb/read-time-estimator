using ReadTimeEstimator.Extensions;
using ReadTimeEstimator.Implementations.Patterns;
using ReadTimeEstimator.Interfaces;

namespace ReadTimeEstimator.Implementations.Estimators;

public class HtmlEstimator : IMarkupEstimator
{
    /// <inherit />
    public double ReadTimeInMinutes(string? markup)
    {
        if (markup == null) 
            return 0.0;

        var trimmedString = markup.Trim();

        if (trimmedString.Length == 0) 
            return 0.0;

        var patterns = new HtmlPatterns();
        var imageReadTime = trimmedString.GetImageReadTimeInMinutes(patterns);
        var codeBlocksPenalty = trimmedString.GetCodeBlocksPenaltyInMinutes(patterns);
        var wordsReadTime = trimmedString.GetWordReadTimeInMinutes(patterns);
        return imageReadTime + codeBlocksPenalty + wordsReadTime;
    }

    /// <inherit />
    public string HumanFriendlyReadTime(string markup)
    {
        var readTime = ReadTimeInMinutes(markup);
        return Utilities.HumanizeTime(readTime);
    }
}