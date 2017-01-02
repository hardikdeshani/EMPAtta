using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

/// <summary>
/// Summary description for SessionClass
/// </summary>
public class SessionClass
{
    public enum SessionKey
    {
        UserID,
        UserName
    }

    public string GetMyUniqueKey()
    {
        string cVal = string.Empty;

        if (HttpContext.Current.Request.Cookies["scookie"] != null)
        {
            cVal = HttpContext.Current.Request.Cookies["scookie"].Value.ToString();
        }
        else
        {
            HttpContext.Current.Response.Cookies["scookie"].Value = Guid.NewGuid().ToString();
            HttpContext.Current.Response.Cookies["scookie"].Expires = DateTime.Now.AddHours(10);
            cVal = HttpContext.Current.Request.Cookies["scookie"].Value.ToString();
        }

        return cVal;
    }

    public void SetValue(SessionKey sKey, string Value)
    {
        string Key = GetMyUniqueKey() + "_" + sKey.ToString();
        if (HttpContext.Current.Cache[Key] == null)
        {
            HttpContext.Current.Cache[Key] = Value;
        }
    }

    public string GetValue(SessionKey sKey)
    {
        string ReturnValue = string.Empty;
        string Key = GetMyUniqueKey() + "_" + sKey.ToString();
        if (HttpContext.Current.Cache[Key] == null)
        {
            ReturnValue = string.Empty;
        }
        else
        {
            ReturnValue = HttpContext.Current.Cache[Key].ToString();
        }

        return ReturnValue;
    }

    public void ClearCache()
    {
        HttpContext.Current.Cache.Remove(GetMyUniqueKey() + "_" + SessionKey.UserID);
        HttpContext.Current.Cache.Remove(GetMyUniqueKey() + "_" + SessionKey.UserName);
        HttpContext.Current.Response.Cookies["scookie"].Expires = DateTime.Now.AddMinutes(-1);
    }
}