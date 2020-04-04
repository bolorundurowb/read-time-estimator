using ReadTimeEstimator.Interfaces;

namespace ReadTimeEstimator.Implementations
{
    public class MarkdownPatterns : IMarkupPatterns
    {
        public string ImagePattern { get; }
        
        public string TagsPattern { get; }

        public string EastAsianCharSetPattern => "[\u3040-\u30ff\u3400-\u4dbf\u4e00-\u9fff\uf900-\ufaff\uff66-\uff9f]";
    }
}
