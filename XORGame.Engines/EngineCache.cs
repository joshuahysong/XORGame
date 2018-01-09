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
        public static BattleData GetBattleData(int friendlyTeamID, int enemyTeamID)
        {
            return GetCachedItem(string.Format("Battle_{0}_{1}", friendlyTeamID, enemyTeamID), () =>
            {
                return BattleEngine.GenerateBattleData(friendlyTeamID, enemyTeamID);
            });
        }

        public static void SetBattleData(BattleData battleData)
        {
            SetCachedItem(string.Format("Battle_{0}_{1}", battleData.FriendlyTeamID, battleData.EnemyTeamID), battleData);
        }

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
