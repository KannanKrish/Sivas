using Sivas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sivas.Controllers
{
    public class HomeController : Controller
    {
        private SivasContext db = new SivasContext();
        public ActionResult Index()
        {
            List<Products> items = new List<Products>();
            foreach (ProductCategory item in Enum.GetValues(typeof(ProductCategory)))
            {
                try
                {
                    items.Add(db.Products.First(x => x.Category == item && x.Offer == true));
                }
                catch (InvalidOperationException) { }
            }
            return View(items.AsEnumerable());
            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Us";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Informations";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}