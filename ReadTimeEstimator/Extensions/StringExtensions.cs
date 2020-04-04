using System.Text.RegularExpressions;
using ReadTimeEstimator.Interfaces;

namespace ReadTimeEstimator.Extensions
{
    internal static class StringExtensions
    {
        private static int GetArticleImageCount(this string input, IMarkupPatterns markupPatterns)
        {
            var regex = new Regex(markupPatterns.ImagePattern, RegexOptions.Multiline);
            var matches = regex.Matches(input);
            return matches.Count;
        }
        
        private static int GetArticleWordCount(this string input, IMarkupPatterns markupPatterns)
        {
            var regex = new Regex(markupPatterns.WordsPattern, RegexOptions.Multiline);
            var matches = regex.Matches(input);
            return matches.Count;
        }
        
        private static (double, string) EstimateAndStripEastAsianCharacters(this string input, IMarkupPatterns markupPatterns)
        {
            var regex = new Regex(markupPatterns.EastAsianCharSetPattern, RegexOptions.Multiline);
            var matches = regex.Matches(input);
            var count = matches.Count;
            var readTimeInMinutes = count / (double) Constants.EastAsianCharactersPerMinute;
            var cleanedString = regex.Replace(input, "");
            return (readTimeInMinutes, cleanedString);
        }

        private static string StripTags(this string input, IMarkupPatterns markupPatterns)
        {
            var regex = new Regex(markupPatterns.TagsPattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            return regex.Replace(input, "");
        }

        public static double GetImageReadTimeInMinutes(this string input, IMarkupPatterns markupPatterns)
        {
            double seconds;
            const int imageReadTime = Constants.ImageReadTimeInSeconds;
            var imageCount = input.GetArticleImageCount(markupPatterns);

            if (imageCount > 10)
            {
                seconds = ((imageCount / 2.0) * (imageReadTime * 3)) + (imageCount - 10) * 3;
            }
            else
            {
                seconds = (imageCount / 2.0) * (2 * imageReadTime + (1 - imageCount));
            }

            return seconds / 60.0;
        }

        public static double GetWordReadTimeInMinutes(this string input, IMarkupPatterns markupPatterns)
        {
            var strippedString = input.StripTags(markupPatterns);
            var (eastAsianReadTime, cleanedString) = strippedString.EstimateAndStripEastAsianCharacters(markupPatterns);
            var wordCount = cleanedString.GetArticleWordCount(markupPatterns);
            var wordReadTimeInMinutes = wordCount / (double) Constants.WordsPerMinute;
            return wordReadTimeInMinutes + eastAsianReadTime;
        }
    }
}
