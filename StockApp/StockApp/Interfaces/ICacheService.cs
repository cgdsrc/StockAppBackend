using System.Collections.Generic;
using StockApp.Model;

namespace CahceAPI.Services
{
    public interface ICacheService
    {
        User GetCacheUser(string Key);
        bool UpdateCache(int orderAmount, string Key);
    }
}