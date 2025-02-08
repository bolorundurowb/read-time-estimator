namespace ReadTimeEstimator.Interfaces;

public interface IMarkupPatterns
{
    /// <summary>
    /// Pattern to find images in the presented article
    /// </summary>
    string ImagePattern { get; }
        
    /// <summary>
    /// Pattern to determine what is mark up and what is content
    /// </summary>
    string? TagsPattern { get; }
        
    /// <summary>
    /// Pattern to determine what a word is
    /// </summary>
    string WordsPattern { get; }
        
    /// <summary>
    /// Pattern to find east asian character sets
    /// </summary>
    string EastAsianCharSetPattern { get; }
}