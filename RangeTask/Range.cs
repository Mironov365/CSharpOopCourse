using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeTask
{
    internal class Range
    {
        public double From { get; set; }
        public double To { get; set; }

        public Range(double from, double to)
        {
            this.From = from;
            this.To = to;
        }

        public Range() : this(0, 0)
        {
        }

        public double GetDistance()
        {
            return To - From;
        }

        public bool IsInside(double point)
        {
            return (From <= point) && (To >= point);
        }

        public Range RangesIntersection(Range range)
        {
            if ((From < range.From && To <= range.From) || (From > range.From && From >= range.To))
            {
                return null;
            }

            double maxFrom = Math.Max(this.From, range.From);
            double minTo = Math.Min(this.To, range.To);

            return new Range(maxFrom, minTo);
        }

        public Range[] RangesUnion(Range range)
        {
            if ((From < range.From && To < range.From) || (From > range.From && From > range.To))
            {
                Range[] rangeSeparateArray = new Range[2];
                Range r1 = new Range(From, To);
                Range r2 = new Range(range.From, range.To);
                return new Range[2] { r1, r2 };
            }

            Range[] rangeArray = new Range[1];

            double minFrom = Math.Min(this.From, range.From);
            double maxTo = Math.Max(this.To, range.To);
            rangeArray[0] = new Range(minFrom, maxTo);

            return rangeArray;
        }

        public Range[] RangesDifference(Range range)
        {
            if (From >= range.From && To <= range.To)
            {
                Range r0 = new Range();
                return new Range[1] { r0 };
            }

            if (From < range.From && To > range.To)
            {                
                Range r1 = new Range(From, range.From);
                Range r2 = new Range(range.To, To);
                return new Range[2] { r1, r2 };
            }

            if ((From <= range.From && To <= range.From) || (From >= range.From && From >= range.To))
            {                
                Range  r1 = new Range(From, To);                
                return new Range[1] { r1 };
            }

            if (From < range.To)
            {
                Range r2 = new Range(From, range.From);
                return new Range[1] { r2 };
            }

            if (To > range.From)
            {
                Range r3 = new Range(range.From, From);
                return new Range[1] { r3 };
            }

            return null;
        }
    }
}