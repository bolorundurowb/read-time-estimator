using ReadTimeEstimator.Extensions;
using ReadTimeEstimator.Interfaces;

namespace ReadTimeEstimator.Implementations.Estimators
{
    public class HtmlEstimator : IMarkupEstimator
    {
        public double ReadTimeInMinutes(string markup)
        {
            var trimmedString = markup.Trim();
            var patterns = new HtmlPatterns();
            var imageReadTime = trimmedString.GetImageReadTimeInMinutes(patterns);
            var wordsReadTime = trimmedString.GetWordReadTimeInMinutes(patterns);
            return imageReadTime + wordsReadTime;
        }

        public string HumanFriendlyReadTime(string markup)
        {
            var readTime = ReadTimeInMinutes(markup);
            return Utilities.HumanizeTime(readTime);
        }
    }
}
