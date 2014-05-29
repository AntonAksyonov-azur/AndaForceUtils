using System;
using System.Collections.Generic;
using System.Linq;

namespace AndaForceExtensions.com.andaforce.arazect.collections.generic.extension
{
    public static class FindClosestValues
    {
        #region Single

        public static Single FindFirstClosest(this IEnumerable<Single> enumerable, Single value)
        {
            return enumerable
                .Select(a => new {a, distance = Math.Abs(a - value)})
                .OrderBy(b => b.distance)
                .First().a;
        }

        public static List<Single> FindCountClosest(this IEnumerable<Single> enumerable, Single value, int count)
        {
            return enumerable
                .Select(a => new {a, distance = Math.Abs(a - value)})
                .OrderBy(b => b.distance)
                .Take(count)
                .Select(c => c.a)
                .ToList();
        }

        public static List<Single> FindAllClosestWithinRange(this IEnumerable<Single> enumerable, Single value, float range)
        {
            return enumerable
                .Select(a => new {a, distance = Math.Abs(a - value)})
                .Where(b => b.distance <= range)
                .Select(c => c.a)
                .ToList();
        }

        #endregion

        #region Int32

        public static Int32 FindFirstClosest(this IEnumerable<Int32> enumerable, Int32 value)
        {
            return enumerable
                .Select(a => new {a, distance = Math.Abs(a - value)})
                .OrderBy(b => b.distance)
                .First().a;
        }

        public static List<Int32> FindCountClosest(this IEnumerable<Int32> enumerable, Int32 value, Int32 count)
        {
            return enumerable
                .Select(a => new {a, distance = Math.Abs(a - value)})
                .OrderBy(b => b.distance)
                .Take(count)
                .Select(c => c.a)
                .ToList();
        }

        public static List<Int32> FindAllClosestWithinRange(this IEnumerable<Int32> enumerable, Int32 value, Int32 range)
        {
            return enumerable
                .Select(a => new {a, distance = Math.Abs(a - value)})
                .Where(b => b.distance <= range)
                .Select(c => c.a)
                .ToList();
        }

        #endregion
    }
}