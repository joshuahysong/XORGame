using System;
using System.Runtime.Caching;

namespace XORGame.Data
{
    public static class DataCache
    {
        private static void SetCachedItem(string cacheKey, object item, DateTimeOffset? offset = null)
        {
            ObjectCache cache = MemoryCache.Default;
            cache.Add(cacheKey, item, offset ?? new DateTimeOffset(DateTime.Now.AddHours(1)));
        }

        private static T GetCachedItem<T>(string cacheKey, Func<T> getResult, DateTimeOffset? offset = null)
        {
            ObjectCache cache = MemoryCache.Default;
            if (cache.Contains(cacheKey))
            {
                return (T)cache.Get(cacheKey);
            }

            var result = getResult();
            SetCachedItem(cacheKey, result, offset);
            return result;
        }
    }
}
