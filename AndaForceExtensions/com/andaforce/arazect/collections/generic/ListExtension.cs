using System.Collections.Generic;
using AndaForceExtensions.com.andaforce.arazect.package.helpers;

namespace AndaForceExtensions.com.andaforce.arazect.collections.generic
{
    public static class ListExtension
    {
        public static TValue GetRandomItem<TValue>(this List<TValue> list)
        {
            if (list.Count > 0)
            {
                return list[RandomHelper.Rnd.Next(0, list.Count - 1)];
            }
            return default(TValue);
        }

        public static TValue RemoveRandomItem<TValue>(this List<TValue> list)
        {
            if (list.Count > 0)
            {
                var value = list[RandomHelper.Rnd.Next(0, list.Count - 1)];
                list.Remove(value);

                return value;
            }
            return default(TValue);
        }
    }
}