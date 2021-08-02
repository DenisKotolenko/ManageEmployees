using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Employees.Repository.Cache
{
    /// <summary>
    /// Extension for Microsoft.Extensions.Caching.
    /// </summary>
    public static class MemoryCacheExtensions
    {
        /// <summary>
        /// Extension method to provide thread safe and lazy caching.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache">MemoryCache.</param>
        /// <param name="cacheKey">Key that will be stored in cache.</param>
        /// <param name="functionResultToCache">Function to evaluate.</param>
        /// <param name="absoluteExpiration">Expiration of cache key.</param>
        /// <returns></returns>
        public static Task<T> GetOrCreateLazyAsync<T>(this IMemoryCache cache, object cacheKey,
                                                      Func<Task<T>> functionResultToCache, DateTimeOffset absoluteExpiration)
        {
            if (!cache.TryGetValue(cacheKey, out Lazy<Task<T>> lazy))
            {
                ICacheEntry entry = cache.CreateEntry(cacheKey);
                entry.SetOptions(new MemoryCacheEntryOptions()
                {
                    AbsoluteExpiration = absoluteExpiration,
                });
                var lazyFunction = new Lazy<Task<T>>(functionResultToCache);
                entry.Value = lazyFunction;
                entry.Dispose(); // Dispose actually inserts the entry in the cache
                if (!cache.TryGetValue(cacheKey, out lazy)) lazy = lazyFunction;
            }
            return ToAsyncConditional(lazy.Value);
        }
        
        private static Task<TResult> ToAsyncConditional<TResult>(Task<TResult> task)
        {
            if (task.IsCompleted) return task;
            return task.ContinueWith(t => t,
                                     default, TaskContinuationOptions.RunContinuationsAsynchronously,
                                     TaskScheduler.Default).Unwrap();
        }
    }
}
