using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TourForEverybuddy.Controllers.Static;
using TourForEverybuddy.Models;

namespace TourForEverybuddy.Controllers.Elements
{
    using TourForEverybuddy.Models.Filters;
    using Image = System.Drawing.Image;
    public class PictureController : Controller
    {
        public ActionResult GetUrlFromTour(int id)
        {
            var tour = Storage.currentUser.Tours.FirstOrDefault(x => x.Id == id);

            if (tour.Tour_PictureOfTour.Count >= 0)
                return File(tour.Tour_PictureOfTour.ElementAt(0).Picture, tour.Tour_PictureOfTour.ElementAt(0).ContentType);

            return File("pic01.jpg", "image/jpeg"); 
        }
        [MyAuthentication]
        public ActionResult GetUrlFromPictureOfTour(int pictureId, int tourID)
        {
            var picture = Storage.currentUser.Tours.FirstOrDefault(x => x.Id == tourID).Tour_PictureOfTour.FirstOrDefault(x => x.Id == pictureId);
            //var picture = Storage.currentUser.Tours.FirstOrDefault(x => x.Id == tourID).Tour_PictureOfTour.FirstOrDefault(x => x.Id == pictureId);


            if (picture != null)
                return File(picture.Picture, picture.ContentType);

            return File("pic01.jpg", "image/jpeg");
        }

        public ActionResult PictureForProfile(int userID)
        {
            DataManager manager = new DataManager();
            var user = manager.GetUser(userID);

            if (user != null && user.Photo != null && !string.IsNullOrEmpty(user.ContentType))
                return File(user.Photo, user.ContentType);
            else
            {
                var path = Path.Combine(Server.MapPath("~/images/Profile"), Path.GetFileName("no_Profile_Image.png"));
                
                var bytes = new byte[1668];

                using(FileStream fs = new FileStream(path, FileMode.Open)){
                    using (var read = new BinaryReader(fs))
                    {
                        bytes = read.ReadBytes((int)fs.Length);
                    }
                }
                return File(bytes , "image/png");
            }
        }


        #region Compression and change size (don't work)
        public static byte[] GetCroppedImage(byte[] originalBytes, ImageFormat format) // Size size
        {
            using (var streamOriginal = new MemoryStream(originalBytes))
            using (var imgOriginal = Image.FromStream(streamOriginal))
            {
                //get original width and height of the incoming image
                //var originalWidth = imgOriginal.Width; // 1000
                //var originalHeight = imgOriginal.Height; // 800
                var width = imgOriginal.Width; // 1000
                var height = imgOriginal.Height; // 800

                ////get the percentage difference in size of the dimension that will change the least
                //var percWidth = ((float)size.Width / (float)originalWidth); // 0.2
                //var percHeight = ((float)size.Height / (float)originalHeight); // 0.25
                //var percentage = Math.Max(percHeight, percWidth); // 0.25

                ////get the ideal width and height for the resize (to the next whole number)
                //var width = (int)Math.Max(originalWidth * percentage, size.Width); // 250
                //var height = (int)Math.Max(originalHeight * percentage, size.Height); // 200

                //actually resize it
                using (var resizedBmp = new Bitmap(width, height))
                {
                    using (var graphics = Graphics.FromImage((Image)resizedBmp))
                    {
                        graphics.InterpolationMode = InterpolationMode.Default;
                        graphics.DrawImage(imgOriginal, 0, 0, width, height);
                    }

                    //work out the coordinates of the top left pixel for cropping
                    //var x = (width - size.Width) / 2; // 25
                    //var y = (height - size.Height) / 2; // 0

                    //create the cropping rectangle
                    var rectangle = new Rectangle(0, 0, width, height); // 25, 0, 200, 200

                    //crop
                    using (var croppedBmp = resizedBmp.Clone(rectangle, resizedBmp.PixelFormat))
                    using (var ms = new MemoryStream())
                    {
                        //get the codec needed
                        var imgCodec = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == format.Guid);

                        //make a paramater to adjust quality
                        var codecParams = new EncoderParameters(1);

                        //reduce to quality of 80 (from range of 0 (max compression) to 100 (no compression))
                        codecParams.Param[0] = new EncoderParameter(Encoder.Quality, 50L);

                        //save to the memorystream - convert it to an array and send it back as a byte[]
                        croppedBmp.Save(ms, imgCodec, codecParams);
                        return ms.ToArray();
                    }
                }
            }
        }

        public static ImageFormat GetFormatImage(string p)
        {
            var format = ImageFormat.Jpeg;
            switch (p)
            {
                case "image/jpeg":
                    format = ImageFormat.Jpeg;
                    break;
                case "image/png":
                    format = ImageFormat.Png;
                    break;
                case "image/bmp":
                    format = ImageFormat.Bmp;
                    break;
                case "image/icon":
                    format = ImageFormat.Icon;
                    break;
                case "image/gif":
                    format = ImageFormat.Gif;
                    break;
                case "image/emf":
                    format = ImageFormat.Emf;
                    break;
                case "image/exif":
                    format = ImageFormat.Exif;
                    break;
                case "image/memorybmp":
                    format = ImageFormat.MemoryBmp;
                    break;
                case "image/tiff":
                    format = ImageFormat.Tiff;
                    break;
                case "image/wmf":
                    format = ImageFormat.Wmf;
                    break;
                default:
                    break;
            }

            return format;
        }
        #endregion
    }
}