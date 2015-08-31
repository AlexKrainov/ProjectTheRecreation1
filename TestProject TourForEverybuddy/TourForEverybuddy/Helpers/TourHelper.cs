using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourForEverybuddy.Helpers
{
    public static class TourHelper
    {
        /// <summary>
        /// Свойство InnerHtml позволяет установить или получить содержимое тега в виде строки
        /// Метод MergeAttribute (string, string, bool) позволяет добавить к элементу один атрибут. Для получения всех атрибутов можно использовать коллекцию Attributes
        /// Метод SetInnerText(string) устанавливает текстовое содержимое внутри элемента
        /// Метод AddCssClass(sting) добавляет класс css к элементу
        /// </summary>
        /// <param name="html"></param>
        /// <param name="id"></param>
        /// <param name="edit"></param>
        /// <returns></returns>
        public static MvcHtmlString Tour(this HtmlHelper html, int id, bool edit = false)
        {
            var tag = new TagBuilder("a");
            tag.Attributes.Add("style", "background-color: red");
            tag.SetInnerText("Hello");


            return new MvcHtmlString(tag.ToString());
        }

    }
}