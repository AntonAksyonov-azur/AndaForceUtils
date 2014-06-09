using System;
using System.Collections.Generic;
using System.Linq;

namespace AndaForceExtensions.com.andaforce.arazect.collections.generic.extension
{
    public static class FindClosestValues
    {
        #region Single

        public static Int32 FindFirstClosestId(this IEnumerable<Single> enumerable, Single value)
        {
            return enumerable
                .Select((a, position) => new {Value = a, Distance = Math.Abs(a - value), Id = position})
                .OrderBy(b => b.Distance).ThenBy(c => c.Value)
                .First().Id;
        }

        public static Single FindFirstClosest(this IEnumerable<Single> enumerable, Single value)
        {
            return enumerable
                .Select(a => new { Value = a, Distance = Math.Abs(a - value) })
                .OrderBy(b => b.Distance).ThenBy(c => c.Value)
                .First().Value;
        }

        public static List<Single> FindCountClosest(this IEnumerable<Single> enumerable, Single value, int count)
        {
            return enumerable
                .Select(a => new {Value = a, Distance = Math.Abs(a - value)})
                .OrderBy(b => b.Distance).ThenBy(c => c.Value)
                .Take(count)
                .Select(c => c.Value)
                .ToList();
        }

        public static List<Single> FindAllClosestWithinRange(this IEnumerable<Single> enumerable, Single value,
            float range)
        {
            return enumerable
                .Select(a => new {Value = a, Distance = Math.Abs(a - value)})
                .Where(b => b.Distance <= range)
                .Select(c => c.Value)
                .ToList();
        }

        #endregion

        #region Int32

        public static Int32 FindFirstClosestId(this IEnumerable<Int32> enumerable, Int32 value)
        {
            return enumerable
                .Select((a, position) => new {Value = a, Distance = Math.Abs(a - value), Id = position})
                .OrderBy(b => b.Distance).ThenBy(c => c.Value)
                .First().Id;
        }

        public static Int32 FindFirstClosest(this IEnumerable<Int32> enumerable, Int32 value)
        {
            return enumerable
                .Select(a => new {Value = a, Distance = Math.Abs(a - value)})
                .OrderBy(b => b.Distance).ThenBy(c => c.Value)
                .First().Value;
        }

        public static List<Int32> FindCountClosest(this IEnumerable<Int32> enumerable, Int32 value, Int32 count)
        {
            return enumerable
                .Select(a => new {Value = a, Distance = Math.Abs(a - value)})
                .OrderBy(b => b.Distance).ThenBy(c => c.Value)
                .Take(count)
                .Select(c => c.Value)
                .ToList();
        }

        public static List<Int32> FindAllClosestWithinRange(this IEnumerable<Int32> enumerable, Int32 value, Int32 range)
        {
            return enumerable
                .Select(a => new {Value = a, Distance = Math.Abs(a - value)})
                .Where(b => b.Distance <= range)
                .Select(c => c.Value)
                .ToList();
        }

        #endregion
    }
}