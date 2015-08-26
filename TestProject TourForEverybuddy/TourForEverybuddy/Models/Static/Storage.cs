using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using TourForEverybuddy.Model;
using TourForEverybuddy.Models;

namespace TourForEverybuddy.Controllers.Static
{
    public static class Storage
    {
        /// <summary>
        /// Указывает на то под каким именнованным cookie лежит id user
        /// </summary>
        public const string aliasUserID = "buddy";
        private const string aliasUser = "bUbby";


        /// <summary>
        /// Хранилище User объекта
        /// </summary>
        private static User user
        {
            get
            {
                if (HttpContext.Current.Session[aliasUser] == null && HttpContext.Current.Session[aliasUser] is User)
                    return HttpContext.Current.Session[aliasUser] as User;
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session[aliasUser] = value;
            }
        }
        /// <summary>
        /// Получаем User
        /// </summary>
        public static User currentUser
        {
            get
            {
                if (user != null)
                    return user;

                var userID = GetCookie(aliasUserID);

                if (userID != null
                    && !string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
                {
                    DataManager db = new DataManager();
                    return user = db.GetUser(userID, HttpContext.Current.User.Identity.Name);
                }
                return null;
            }
            set { user = value; }
        }

        /// <summary>
        /// Получаем типы User
        /// </summary>
        public static IQueryable<UserType> UserTypes
        {
            get
            {
                if (HttpContext.Current.Application.Get("UserType") == null)
                {
                    DataManager db = new DataManager();
                    HttpContext.Current.Application.Set("UserType", db.GetRoles());
                }

                return HttpContext.Current.Application.Get("UserType") as IQueryable<UserType>;
            }
        }

        /// <summary>
        /// Сохраняет в Response.Cookies данные 
        /// </summary>
        /// <param name="nameCookie"> Название Cookie</param>
        /// <param name="value">Значение которое нужно сохранить</param>
        /// <param name="dateTime">На сколько нужно сохранить информацию</param>
        internal static void SaveCookieID(string nameCookie, string value, DateTime dateTime)
        {
            var cookie = new HttpCookie(nameCookie, value.Encrypt());
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

            return cookie == null ? null : cookie.Value.Decrypt();
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