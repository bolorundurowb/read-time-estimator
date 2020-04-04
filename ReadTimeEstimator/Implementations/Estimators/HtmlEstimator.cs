using ReadTimeEstimator.Extensions;
using ReadTimeEstimator.Implementations.Patterns;
using ReadTimeEstimator.Interfaces;

namespace ReadTimeEstimator.Implementations.Estimators
{
    public class HtmlEstimator : IMarkupEstimator
    {
        /// <inherit />
        public double ReadTimeInMinutes(string markup)
        {
            var trimmedString = markup.Trim();
            var patterns = new HtmlPatterns();
            var imageReadTime = trimmedString.GetImageReadTimeInMinutes(patterns);
            var wordsReadTime = trimmedString.GetWordReadTimeInMinutes(patterns);
            return imageReadTime + wordsReadTime;
        }

        /// <inherit />
        public string HumanFriendlyReadTime(string markup)
        {
            var readTime = ReadTimeInMinutes(markup);
            return Utilities.HumanizeTime(readTime);
        }
    }
}
