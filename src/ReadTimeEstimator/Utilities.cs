using System;

namespace ReadTimeEstimator;

/// <summary>
/// class to hold shared utilities
/// </summary>
internal static class Utilities
{
    /// <summary>
    /// Print out time in a human-readable form
    /// </summary>
    /// <param name="timeInMinutes">Time in minutes</param>
    /// <returns>A formatted string</returns>
    public static string HumanizeTime(double timeInMinutes) =>
        timeInMinutes switch
        {
            < 0.5 => "less than a minute",
            >= 0.5 and < 1.5 => "1 minute",
            _ => $"{Math.Ceiling(timeInMinutes)} minutes"
        };
}