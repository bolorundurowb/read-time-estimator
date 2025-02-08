using Markdig;
using ReadTimeEstimator.Extensions;
using ReadTimeEstimator.Implementations.Patterns;
using ReadTimeEstimator.Interfaces;

namespace ReadTimeEstimator.Implementations.Estimators;

public class MarkdownEstimator : IMarkupEstimator
{
    /// <inherit />
    public double ReadTimeInMinutes(string? markup)
    {
        if (markup == null) 
            return 0.0;

        var trimmedString = markup.Trim();

        if (trimmedString.Length == 0) 
            return 0.0;

        var html = Markdown.ToHtml(trimmedString);
        var patterns = new HtmlPatterns();
        var imageReadTime = html.GetImageReadTimeInMinutes(patterns);
        var wordsReadTime = html.GetWordReadTimeInMinutes(patterns);
        return imageReadTime + wordsReadTime;
    }

    /// <inherit />
    public string HumanFriendlyReadTime(string markup)
    {
        var readTime = ReadTimeInMinutes(markup);
        return Utilities.HumanizeTime(readTime);
    }
}