using System;
using System.Collections.Generic;

namespace AndaForceUtils.Collections.LinqClone
{
    public static class ClonedLinqCompareMethods
    {
        public static T ClonedMax<T>(this List<T> list) where T : IComparable
        {
            if (list.Count > 0)
            {
                var maxValue = list[0];
                foreach (T t in list)
                {
                    if (maxValue.CompareTo(t) < 0)
                    {
                        maxValue = t;
                    }
                }

                return maxValue;
            }
            return default(T);
        }

        public static T ClonedMin<T>(this List<T> list) where T : IComparable
        {
            if (list.Count > 0)
            {
                var minValue = list[0];
                foreach (T t in list)
                {
                    if (minValue.CompareTo(t) > 0)
                    {
                        minValue = t;
                    }
                }

                return minValue;
            }
            return default(T);
        }
    }
}
