using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services
{
    interface IResponseCacheService
    {
        Task CacheResponseAsnyc(string cacheKey, object response, TimeSpan timeTimeLive);

        Task<String> GetCachedResponseAsync(string cacheKey);
    }
}
