namespace RangeTask
{
    internal class Range
    {
        public double From { get; set; }

        public double To { get; set; }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double point)
        {
            return point >= From && point <= To;
        }

        public Range? GetIntersection(Range range)
        {
            if (range.From >= To || range.To <= From)
            {
                return null;
            }

            double maxFrom = Math.Max(From, range.From);
            double minTo = Math.Min(To, range.To);

            return new Range(maxFrom, minTo);
        }

        public Range[] GetUnion(Range range)
        {
            if (range.From > To || range.To < From)
            {
                return new Range[] { new Range(From, To), new Range(range.From, range.To) };
            }

            double minFrom = Math.Min(From, range.From);
            double maxTo = Math.Max(To, range.To);

            return new Range[] { new Range(minFrom, maxTo) };
        }

        public Range[] GetDifference(Range range)
        {
            if (From >= range.From && To <= range.To)
            {
                return new Range[] { };
            }

            if (From < range.From && To > range.To)
            {
                return new Range[] { new Range(From, range.From), new Range(range.To, To) };
            }

            if (range.From > To || range.To < From)
            {
                return new Range[] { new Range(From, To) };
            }

            if (From >= range.From)
            {
                return new Range[] { new Range(range.To, To) };
            }

            return new Range[] { new Range(From, range.From) };
        }
    }
}