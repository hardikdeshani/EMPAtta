using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

/// <summary>
/// Summary description for Tools
/// </summary>
public class Tools
{
    public Tools()
    {

    }
    /// <summary>
    /// Contains information of Cache Type, Used in operating cache.
    /// </summary>
    public enum MyCacheType
    {
        VendorProfile = 0, DriverProfile = 1, AdminProfile = 2
    }
    /// <summary>
    /// Local paired value collection for caching.
    /// </summary>
    static Dictionary<MyCacheType, string> CachePairedValueCollection = new Dictionary<MyCacheType, string> 
    {
        { MyCacheType.VendorProfile, "_VENPROF"},{ MyCacheType.DriverProfile, "_DRVPROF"},{ MyCacheType.AdminProfile, "_ADPROF"}
    };
    /// <summary>
    /// Extended version of getting cached data by CacheType.
    /// </summary>
    /// <param name="ChType">Type of cache to retrive.</param>
    /// <returns>Returns the data as object.</returns>
    public static object GetCacheExtended(MyCacheType ChType)
    {
        string KeyPrefix = "_" + UserIdForCacheKey + CachePairedValueCollection[ChType];
        if (HttpContext.Current.Cache[KeyPrefix] != null)
            return HttpContext.Current.Cache[KeyPrefix];
        else
            return null;
    }

    /// <summary>
    /// Extended version of setting data to cache.
    /// </summary>
    /// <param name="ChType">Type of cache to store in.</param>
    /// <param name="ValueToSet">Data to be stored in cache.</param>
    public static void SetCacheValueExtended(MyCacheType ChType, object ValueToSet)
    {
        string KeyPrefix = "_" + UserIdForCacheKey + CachePairedValueCollection[ChType];
        if (HttpContext.Current.Cache[KeyPrefix] == null)
            CreateCacheObject(KeyPrefix, ValueToSet);
        else
            HttpContext.Current.Cache[KeyPrefix] = ValueToSet;
    }



    /// <summary>
    /// Creates new cache with unique key if not exists.
    /// </summary>
    /// <param name="KEY">Name of cache to be created.</param>
    static void CreateCacheObject(string KEY, object ValeToSet)
    {
        HttpContext.Current.Cache.Insert(KEY, ValeToSet, null, DateTime.Now.AddMinutes(30), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
    }

    public static string UserIdForCacheKey
    {
        get
        {
            if (HttpContext.Current.Session["_lgnKey"] == null)
                return string.Empty;
            return HttpContext.Current.Session["_lgnKey"].ToString();
        }
        set { HttpContext.Current.Session["_lgnKey"] = value; }
    }

    /// <summary>
    /// Removes all cache related to the logged in user. Call this method on LOGOUT.
    /// </summary>
    public static void RemoveMyCache()
    {
        string KeyPrefix = "_" + UserIdForCacheKey;
        foreach (KeyValuePair<MyCacheType, string> PAIR in CachePairedValueCollection)
        {
            HttpContext.Current.Cache.Remove(KeyPrefix + PAIR.Value.ToString());
        }
    }

    /// <summary>
    /// Get Proper Date Format
    /// </summary>
    /// <param name="Date"></param>
    /// <returns></returns>
    public static string GetDateFormatProper(string Date)
    {
        string WholeString = string.Empty;
        if (Date.Contains("/"))
        {
            string[] SplitString = Date.Split('/');
            WholeString = SplitString[1] + "/" + SplitString[0] + "/" + SplitString[2];
        }
        else
        {
            string[] SplitString = Date.Split('-');
            WholeString = SplitString[2] + "-" + SplitString[1] + "-" + SplitString[0];
        }
        return WholeString;
    }
}