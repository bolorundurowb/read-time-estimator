using ReadTimeEstimator.Interfaces;

namespace ReadTimeEstimator.Implementations.Patterns;

public class MarkdownPatterns : IMarkupPatterns
{
    /// <inherit />
    public string ImagePattern => "(?:!\\[(.*?)\\]\\((.*?)\\))";

    /// <inherit />
    public string CodeBlocksPattern => "```[\\w\\W]*?```|~~~[\\w\\W]*?~~~";

    /// <inherit />
    public string TagsPattern => string.Empty;

    /// <inherit />
    public string WordsPattern => "\\w+";

    /// <inherit />
    public string EastAsianCharSetPattern => "[\u3040-\u30ff\u3400-\u4dbf\u4e00-\u9fff\uf900-\ufaff\uff66-\uff9f]";
}
