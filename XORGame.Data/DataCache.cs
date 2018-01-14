using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using XORGame.Data.Entities;
using XORGame.Data.Repositories;

namespace XORGame.Data
{
    public static class DataCache
    {
        public static List<Ability> GetAbilities()
        {
            return GetCachedItem("Abilities", () =>
            {
                return AbilityRepository.GetAbilities();
            });
        }

        public static Ability GetAbility(int abilityID)
        {
            return GetAbilities().FirstOrDefault(a => a.ID == abilityID);
        }

        public static Ability GetAbility(string abilityName)
        {
            // We need to check against the trimed and uppered version of the ability's name also to match against classes.
            return GetAbilities().FirstOrDefault(a => a.Name == abilityName || a.Name.ToUpper().Replace(" ", string.Empty) == abilityName.ToUpper());
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
