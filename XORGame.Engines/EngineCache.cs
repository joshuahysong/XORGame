using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using XORGame.Data.DataTransferEntities;

namespace XORGame.Engines
{
    public static class EngineCache
    {
        public static BattleData GetBattleData(string userID, int friendlyTeamID, int enemyTeamID)
        {
            return GetCachedItem(string.Format("{0}_ArenaBattle", userID), () =>
            {
                return BattleEngine.GenerateBattleData(friendlyTeamID, enemyTeamID);
            });
        }

        public static void SetBattleData(string userID, BattleData battleData)
        {
            SetCachedItem(string.Format("{0}_ArenaBattle", userID), battleData);
        }

        public static void ClearBattleData(string userID)
        {
            ClearCacheItem(string.Format("{0}_ArenaBattle", userID));
        }

        private static void SetCachedItem(string cacheKey, object item, DateTimeOffset? offset = null)
        {
            ObjectCache cache = MemoryCache.Default;
            cache.Add(cacheKey, item, offset ?? new DateTimeOffset(DateTime.Now.AddHours(6)));
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

        private static void ClearCacheItem(string cacheKey)
        {
            ObjectCache cache = MemoryCache.Default;
            if (cache.Contains(cacheKey))
            {
                cache.Remove(cacheKey);
            }
        }
    }
}
