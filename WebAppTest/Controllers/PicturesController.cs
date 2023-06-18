using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppTest.Controllers
{
    public class PicturesController : Controller
    {
        // GET: Pictures
        public ActionResult Index()
        {
            List<string> list_pictures = new List<string>();
            //list_pictures.Add("Images/pictures/full_size_20160427203644.jpg");
            //list_pictures.Add("https://photos.app.goo.gl/o9dmjtrwrLgpRYEa7");
            for (int i = 0; i < 10; i++)
            {
                list_pictures.Add("https://unsplash.it/200/200");
                list_pictures.Add("https://unsplash.it/300/300");
                list_pictures.Add("https://unsplash.it/400/400");
                list_pictures.Add("https://unsplash.it/500/500");
                list_pictures.Add("https://unsplash.it/600/600");
                list_pictures.Add("https://unsplash.it/700/700");
                list_pictures.Add("https://unsplash.it/800/800");
                list_pictures.Add("https://unsplash.it/900/900");
            }

            return View(list_pictures);
        }
    }
}