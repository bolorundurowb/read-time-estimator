using System;

namespace ReadTimeEstimator
{
    public class Utilities
    {
        public string HumanizeTime(double time)
        {
            if (time < 0.5)
            {
                return "less than a minute";
            }

            if (time >= 0.5 && time < 1.5)
            {
                return "1 minute";
            }

            return $"{Math.Ceiling(time)} minutes";
        }
    }
}
