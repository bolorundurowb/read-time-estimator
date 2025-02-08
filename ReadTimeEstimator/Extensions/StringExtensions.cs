using System.Text.RegularExpressions;
using ReadTimeEstimator.Interfaces;

namespace ReadTimeEstimator.Extensions;

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

    private static (double, string) EstimateAndStripEastAsianCharacters(this string input,
        IMarkupPatterns markupPatterns)
    {
        var regex = new Regex(markupPatterns.EastAsianCharSetPattern, RegexOptions.Multiline);
        var matches = regex.Matches(input);
        var count = matches.Count;
        var readTimeInMinutes = count / (double)Constants.EastAsianCharactersPerMinute;
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
        const int imageReadTime = Constants.ImageReadTimeInSeconds; // Assumed read time per image in seconds
        var imageCount = input.GetArticleImageCount(markupPatterns);

        // Calculate total read time for images based on the number of images
        if (imageCount > 10)
        {
            // For more than 10 images, use a formula that accounts for diminishing returns
            // Formula: ((imageCount / 2) * (imageReadTime * 3)) + (imageCount - 10) * 3
            // This assumes that users spend less time per image when there are many images
            seconds = ((imageCount / 2.0) * (imageReadTime * 3)) + (imageCount - 10) * 3;
        }
        else
        {
            // For 10 or fewer images, use a formula that adjusts read time based on the number of images
            // Formula: (imageCount / 2) * (2 * imageReadTime + (1 - imageCount))
            // This assumes that users spend more time per image when there are fewer images
            seconds = (imageCount / 2.0) * (2 * imageReadTime + (1 - imageCount));
        }

        // Convert the total read time from seconds to minutes
        return seconds / 60.0;
    }

    public static double GetWordReadTimeInMinutes(this string input, IMarkupPatterns markupPatterns)
    {
        // Strip markup tags from the input to get plain text
        var strippedString = input.StripTags(markupPatterns);

        // Estimate read time for East Asian characters and strip them from the string
        // East Asian characters (e.g., Chinese, Japanese) are read at a different speed than Latin characters
        var (eastAsianReadTime, cleanedString) = strippedString.EstimateAndStripEastAsianCharacters(markupPatterns);

        // Count the number of words in the cleaned string (excluding East Asian characters)
        var wordCount = cleanedString.GetArticleWordCount(markupPatterns);

        // Calculate read time for words based on the assumed reading speed of 275 words per minute
        var wordReadTimeInMinutes = wordCount / (double)Constants.WordsPerMinute;

        // Return the total read time by adding word read time and East Asian character read time
        return wordReadTimeInMinutes + eastAsianReadTime;
    }
}
