using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Caching;

namespace SGSI
{
    /// <summary>
    /// 
    /// </summary>
    public delegate List<TValue> LoadCacheListHandler<TValue>(ICacheManager cacheManager, string keyCache);
    /// <summary>
    /// 
    /// </summary>
    public delegate Dictionary<TKey, TValue> LoadCacheDictionaryHandler<TKey, TValue> (ICacheManager cacheManager, string keyCache);

}
