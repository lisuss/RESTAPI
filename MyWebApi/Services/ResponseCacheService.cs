using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services
{
    public class ResponseCacheService : IResponseCacheService
    {

        private readonly IDistributedCache _distributedCache;

        public ResponseCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public async Task CacheResponseAsnyc(string cacheKey, object response, TimeSpan timeTimeLive)
        {
            if(response == null)
            {
                return;
            }

            var serializedResponse = JsonConvert.SerializeObject(response);

            await _distributedCache.SetStringAsync(cacheKey, serializedResponse, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = timeTimeLive
            });

           
        }

        public async Task<string> GetCachedResponseAsync(string cacheKey)
        {
            var cachedReponse = await _distributedCache.GetStringAsync(cacheKey);
            return string.IsNullOrEmpty(cachedReponse) ? null : cachedReponse;
        }
    }
}
