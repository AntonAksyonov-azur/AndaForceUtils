using AndaForceUtils.Internal;

namespace AndaForceUtils.Collections.Generic.Extension
{
    public static class ArrayExtension
    {
        public static TValue GetRandomItem<TValue>(this TValue[] array)
        {
            if (array.Length > 0)
            {
                return array[InternalRandomHelper.Rnd.Next(0, array.Length)];
            }
            return default(TValue);
        }
    }
}