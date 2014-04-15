using System.Collections.Generic;
using System.Linq;
using AndaForceExtensions.com.andaforce.arazect.package.helpers;

namespace AndaForceExtensions.com.andaforce.arazect.collections.generic
{
    public static class DictionaryExtension
    {
        public static TValue GetRandomItem<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            TValue[] flatten = dictionary.Select(x => x.Value).ToArray();
            return flatten[RandomHelper.Rnd.Next(0, flatten.Length)];
        }
        
        public static TKey GetRandomKey<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            TKey[] flatten = dictionary.Keys.ToArray();
            return flatten[RandomHelper.Rnd.Next(0, dictionary.Keys.Count)];
        }
    }
}