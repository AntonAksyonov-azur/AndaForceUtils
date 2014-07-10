using System.Collections.Generic;
using AndaForceUtils.Internal;

namespace AndaForceUtils.Collections.Generic.Extension
{
    public static class ListExtension
    {
        public static TValue GetRandomItem<TValue>(this List<TValue> list)
        {
            if (list.Count > 0)
            {
                return list[InternalRandomHelper.Rnd.Next(0, list.Count)];
            }
            return default(TValue);
        }

        public static TValue RemoveRandomItem<TValue>(this List<TValue> list)
        {
            if (list.Count > 0)
            {
                var value = list[InternalRandomHelper.Rnd.Next(0, list.Count)];
                list.Remove(value);

                return value;
            }
            return default(TValue);
        }
    }
}