using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookBookWebsite.Controllers
{
    public class HomeController : Controller
    {
        CookBookContext db = new CookBookContext();

        public ActionResult Index()
        {
            return View(db.Recipes.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}