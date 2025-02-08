namespace ReadTimeEstimator.Interfaces;

public interface IMarkupEstimator
{
    /// <summary>
    /// get the reading time for an article
    /// </summary>
    /// <param name="markup">markup string</param>
    /// <returns>The required read time in minutes</returns>
    double ReadTimeInMinutes(string? markup);

    /// <summary>
    /// get the reading time for an article
    /// </summary>
    /// <param name="markup">markup string</param>
    /// <returns>The human readable read time</returns>
    string HumanFriendlyReadTime(string markup);
}