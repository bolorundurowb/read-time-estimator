namespace ReadTimeEstimator.Interfaces
{
    public interface IMarkupPatterns
    {
        string ImagePattern { get; }
        
        string TagsPattern { get; }
        
        string WordsPattern { get; }
        
        string EastAsianCharSetPattern { get; }
    }
}
