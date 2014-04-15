using AndaForceExtensions.com.andaforce.arazect.package.helpers;

namespace AndaForceExtensions.com.andaforce.arazect.collections.generic
{
    public static class ArrayExtension
    {
        public static TValue GetRandomItem<TValue>(this TValue[] array)
        {
            return array[RandomHelper.Rnd.Next(0, array.Length - 1)];
        }
    }
}