namespace ReadTimeEstimator.Interfaces
{
    public interface IMarkupEstimator
    {
        double ReadTimeInMinutes(string markup);

        string HumanFriendlyReadTime(string markup);
    }
}
