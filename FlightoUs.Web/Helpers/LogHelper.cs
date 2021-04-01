
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FlightoUs.Web.Helpers
{
    public static class LogHelper
    {
        //public static async Task LogError(Exception ex, HttpContext httpContext, ClaimsPrincipal user)
        //{
        //    string shortMessage = ex.Message;
        //    string longMessage = ex.ToString();

        //    await InsertLog(httpContext, user, shortMessage, longMessage, SysteLogLevelType.Error);
        //}

        //public static async Task LogWarning(HttpContext httpContext, ClaimsPrincipal user, string shortMessage, string longMessage)
        //{
        //    await InsertLog(httpContext, user, shortMessage, longMessage, SysteLogLevelType.Warning);
        //}

        //public static async Task LogInfo(HttpContext httpContext, ClaimsPrincipal user, string shortMessage, string longMessage)
        //{
        //    await InsertLog(httpContext, user, shortMessage, longMessage, SysteLogLevelType.Info);
        //}

        //private static async Task InsertLog(HttpContext httpContext, ClaimsPrincipal user, string shortMessage, string longMessage, SysteLogLevelType levelType)
        //{
        //    BllSystemLog bllSystemLog = new BllSystemLog();
            
        //    var systemLog = WorkContext.GetSystemLog(httpContext, user);

        //    if (shortMessage.Length > 200)
        //    {
        //        shortMessage = shortMessage.Substring(0, 200);
        //    }
        //    if (longMessage.Length > 4000)
        //    {
        //        longMessage = longMessage.Substring(0, 4000);
        //    }

        //    systemLog.LevelType = levelType;

        //    await bllSystemLog.Insert(systemLog);
        //}
    }
}
