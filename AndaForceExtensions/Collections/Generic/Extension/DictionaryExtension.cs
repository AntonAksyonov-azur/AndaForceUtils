using System.Collections.Generic;
using System.Linq;
using AndaForceUtils.Internal;

namespace AndaForceUtils.Collections.Generic.Extension
{
    public static class DictionaryExtension
    {
        public static TValue GetRandomItem<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            TValue[] flatten = dictionary.Select(x => x.Value).ToArray();
            if (flatten.Length > 0)
            {
                return flatten[InternalRandomHelper.Rnd.Next(0, flatten.Length)];
            }
            return default(TValue);
        }
        
        public static TKey GetRandomKey<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            TKey[] flatten = dictionary.Keys.ToArray();
            if (flatten.Length > 0)
            {
                return flatten[InternalRandomHelper.Rnd.Next(0, dictionary.Keys.Count)];
            }
            return default(TKey);
        }
    }
}