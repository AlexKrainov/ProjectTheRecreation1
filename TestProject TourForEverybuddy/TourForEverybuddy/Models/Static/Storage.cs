using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using TourForEverybuddy.Model;

namespace TourForEverybuddy.Controllers.Static
{
    public static class Storage
    {
        public const string UserID = "buddy";

        public static int GetUserID()
        {
            var value = GetCookie(UserID);
            return 0;
        }


        /// <summary>
        /// Сохраняет в Response.Cookies данные 
        /// </summary>
        /// <param name="nameCookie"> Название Cookie</param>
        /// <param name="value">Значение которое нужно сохранить</param>
        /// <param name="dateTime">На сколько нужно сохранить информацию</param>
        internal static void SaveCookieID(string nameCookie, string value, DateTime dateTime)
        {
            
            //ToDo: Кодировать ли ?
            var cookie = new HttpCookie("buddy", value.Encrypt());
            cookie.Expires = DateTime.Now.AddYears(1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameCookie"></param>
        /// <returns></returns>
        internal static string GetCookie(string nameCookie)
        {
            var cookie = HttpContext.Current.Request.Cookies[nameCookie];

            return cookie.Value.Decrypt();
        }

        /// <summary>
        /// Удаляем Cookie
        /// </summary>
        /// <param name="nameCookie">Название Cookie</param>
        internal static void RemoveCookie(string nameCookie)
        {
            var cookie = HttpContext.Current.Request.Cookies[nameCookie];
            cookie.Expires = DateTime.Now.AddMilliseconds(-1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}