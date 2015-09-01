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
            var section = new TagBuilder("section"); section.AddCssClass("post");
            var divImg = new TagBuilder("div"); divImg.AddCssClass("img");
            var img = new TagBuilder("img"); img.Attributes.Add("id", "img"); img.Attributes.Add("src", "tra");
            
            var divContent = new TagBuilder("div"); divContent.AddCssClass("content");
            
            

            return new MvcHtmlString(section.ToString());
        }

        /*
         * 
         *  <section class="post">
            <div class="img">
                <img id="img" src="@Url.Action("GetUrlFromPictureOfTour", "Picture", new { pictureId = Model.Tours.ElementAt(0).Tour_PictureOfTour.ElementAt(0).Id,
                 tourID = Model.Tours.ElementAt(0).Tour_PictureOfTour.ElementAt(0).TourID })"
                     alt="" />
            </div>
            <div class="content">
                @Html.ActionLink(Model.Tours.ElementAt(0).title, "ActionName", "controllerName", null, new { @class = "titleTour" })
                @*<b class="titleTour">Same text from title tour and text from title tour</b>*@
                <p class="contentDescription">
                    There's a funny blog post about how to download SQL Server Express from Long Zheng.
                    It surprisingly how complex some companies make downloading things. I've always thought that a giant Download Now button is the best way, but perhaps that's just me?
                </p>

                @*<input class="button" type="submit" value="View" />*@
            </div>
        </section>
         */
    }
}