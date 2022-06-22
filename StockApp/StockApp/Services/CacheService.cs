using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using StockApp.Model;

namespace CahceAPI.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public User GetCacheUser(string Key)
        {
            User user = new User();
            if (!IsCacheNull(Key))
            {
                user = (User)_memoryCache.Get(Key);
            }
            else
            {
                user = new User()
                {
                    Id = 1,
                    UserName = "Cagdas",
                    Balance = 10000
                };
                var cacheEntryOptions = new MemoryCacheEntryOptions();
                _memoryCache.Set(Key, user, cacheEntryOptions);

            }

            return user;
        }

        public bool UpdateCache(int OrderAmount, string Key)
        {

            User user = (User)_memoryCache.Get(Key);

            if (OrderAmount < user.Balance)
            {
                user.Balance -= OrderAmount;
                var cacheEntryOptions = new MemoryCacheEntryOptions();
                _memoryCache.Set(Key, user, cacheEntryOptions);
                return true;
            }
            return false;
        }

        private bool IsCacheNull(string Key)
        {
            if (_memoryCache.TryGetValue(Key, out User cacheValue))
            {
                return false;
            }

            return true;
        }

    }
}