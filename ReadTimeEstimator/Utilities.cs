using System;

namespace ReadTimeEstimator
{
    public static class Utilities
    {
        public static string HumanizeTime(double timeInMinutes)
        {
            if (timeInMinutes < 0.5)
            {
                return "less than a minute";
            }

            if (timeInMinutes >= 0.5 && timeInMinutes < 1.5)
            {
                return "1 minute";
            }

            return $"{Math.Ceiling(timeInMinutes)} minutes";
        }
    }
}
