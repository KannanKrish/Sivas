namespace Sivas.Controllers;

public class ProductsController : Controller
{
    private readonly SivasContext db = new();

    // GET: Products
    public ActionResult Index()
    {
        var items = new List<Products>();
        foreach (ProductCategory item in Enum.GetValues(typeof(ProductCategory)))
        {
            try
            {
                items.Add(db.Products.First(x => x.Category == item && x.Offer == true));
            }
            catch (InvalidOperationException) { }
        }
        return View(items.AsEnumerable());
    }

    // GET: Products
    public ActionResult Category(ProductCategory? category, int? page)
    {
        var items = new List<Products>();
        if (category != null)
        {
            items.AddRange(db.Products.Where(x => x.Category == category && x.Offer == true));
            items.AddRange(db.Products.Where(x => x.Category == category && x.Offer == false));
            return View(items.ToPagedList(page ?? 1, 6));
        }
        else
        {
            items.AddRange(db.Products.Where(x => x.Offer == true));
            items.AddRange(db.Products.Where(x => x.Offer == false));
            return View(items.ToPagedList(page ?? 1, 6));
        }
    }

    // GET: Products/Details/5
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        var products = db.Products.Find(id);
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
            var file = Request.Files["ImageData"];
            products.Image = file.ConvertToBytes();
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
        var products = db.Products.Find(id);
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
            var file = Request.Files["ImageData"];
            products.Image = file.ConvertToBytes();
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
        var products = db.Products.Find(id);
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
        var products = db.Products.Find(id);

        if (products == null) return RedirectToAction("Index");

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