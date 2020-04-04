using ReadTimeEstimator.Interfaces;

namespace ReadTimeEstimator.Implementations
{
    public class HtmlPatterns : IMarkupPatterns
    {
        public string ImagePattern => "<({img|Image})([\\w\\W]+?)[\\/]?>";

        public string TagsPattern => "<\\w+(\\s+(\"[^\"]*\"|\\\'[^\\\']*\'|[^>])+)?>|<\\/\\w+>";

        public string EastAsianCharSetPattern => "[\u3040-\u30ff\u3400-\u4dbf\u4e00-\u9fff\uf900-\ufaff\uff66-\uff9f]";
    }
}