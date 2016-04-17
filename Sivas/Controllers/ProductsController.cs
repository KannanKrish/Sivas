using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sivas.Models;
using Sivas.CustomMethods;
using PagedList.Mvc;
using PagedList;

namespace Sivas.Controllers
{
    public class ProductsController : Controller
    {
        private SivasContext db = new SivasContext();

        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        // GET: Products
        public ActionResult Category(ProductCategory? category, int? page)
        {
            if (category != null)
                return View(db.Products.Where(x => x.Category == category).ToList().ToPagedList(page ?? 1, 6));
            else
                return View(db.Products.ToList().ToPagedList(page ?? 1, 6));
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        [Authorize]

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Category,Company,Brand,Model,Image,Landscape,EnergyStar,Price,Offer,Color,Specification,Description")] Products products)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["ImageData"];
                products.Image = ReuseCode.ConvertToBytes(file);
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(products);
        }

        [Authorize]
        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Category,Company,Brand,Model,Image,Landscape,EnergyStar,Price,Offer,Color,Specification,Description")] Products products)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["ImageData"];
                products.Image = ReuseCode.ConvertToBytes(file);
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        // GET: Products/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
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
