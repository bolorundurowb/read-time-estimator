using System;

namespace ReadTimeEstimator
{
    /// <summary>
    /// class to hold shared utilities
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Print out time in a human readable form
        /// </summary>
        /// <param name="timeInMinutes">Time in minutes</param>
        /// <returns>A formatted string</returns>
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
