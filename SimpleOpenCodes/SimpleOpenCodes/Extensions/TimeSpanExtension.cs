using System;

namespace SimpleOpenCodes.Extensions
{
    /// <summary>
    /// The extension methods of the TimeSpan structure.
    /// </summary>
    public static class TimeSpanExtension
    {
        /// <summary>
        /// Returns a new TimeSpan instance that is a copy of this instance.
        /// </summary>
        public static TimeSpan Copy(this TimeSpan source)
        {
            var value = new TimeSpan(source.Ticks);
            return value;
        }

        /// <summary>
        /// Returns a new TimeSpan that rounded this instance down by the specified threshold.
        /// </summary>
        /// <param name="threshold">The threshold value to round down this instance.</param>
        public static TimeSpan RoundDown(this TimeSpan source, TimeSpan threshold)
        {
            var ticks = source.Ticks;
            var borderTicks = threshold.Ticks;
            var newTicks = (ticks / borderTicks) * borderTicks;
            return new TimeSpan(newTicks);
        }

        /// <summary>
        /// Returns a new TimeSpan that rounded this instance up by the specified threshold.
        /// </summary>
        /// <param name="threshold">The threshold value to round up this instance.</param>
        public static TimeSpan RoundUp(this TimeSpan source, TimeSpan threshold)
        {
            var ticks = source.Ticks;
            var borderTicks = threshold.Ticks;
            var newTicks = ((ticks + borderTicks - 1) / borderTicks) * borderTicks;
            return new TimeSpan(newTicks);
        }
    }
}
