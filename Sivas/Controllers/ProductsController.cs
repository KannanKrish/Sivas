namespace Sivas.Controllers;

public class ProductsController : Controller
{
    // GET: Products
    public ActionResult Index() => View(UnitOfWork.Product.GetAll(s => s.Offer)
        .OrderBy(s => s.Category).ToList());

    // GET: Products
    public ActionResult Category(ProductCategory? category, int? page)
    {
        if (category != null)
            return View(UnitOfWork.Product.GetAll(x => x.Category == category).ToPagedList());

        return View(UnitOfWork.Product
            .GetPagedResult(page ?? 1, 6).Results
            .ToPagedList());
    }

    // GET: Products/Details/5
    public ActionResult Details(Guid? id)
    {
        if (id == null)
            return new StatusCodeResult((int)HttpStatusCode.BadRequest);

        var products = UnitOfWork.Product.FirstOrDefault(s => s.Id == id);

        if (products == null)
            return NotFound();

        return View(products);
    }

    [Authorize]
    // GET: Products/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Products/Create
    // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<ActionResult> Create([Bind("Id,Category,Company,Brand,Model,Image,Landscape,EnergyStar,Price,Offer,Color,Specification,Description")] Product product)
    {
        if (ModelState.IsValid)
        {
            var file = Request.Form.Files["ImageData"];

            if (file != null)
            {
                product.Image = await file.ConvertToBytes();
                UnitOfWork.Add(product);
                await UnitOfWork.CompleteAsync();
                return RedirectToAction("Index");
            }
        }

        return View(product);
    }

    [Authorize]
    // GET: Products/Edit/5
    public ActionResult Edit(Guid? id)
    {
        if (id == null)
            return new StatusCodeResult((int)HttpStatusCode.BadRequest);

        var products = UnitOfWork.Product.FirstOrDefault(s => s.Id == id);

        if (products == null)
            return NotFound();

        return View(products);
    }

    // POST: Products/Edit/5
    // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<ActionResult> Edit([Bind("Id,Category,Company,Brand,Model,Image,Landscape,EnergyStar,Price,Offer,Color,Specification,Description")] Product product)
    {
        if (ModelState.IsValid)
        {
            var file = Request.Form.Files["ImageData"];

            if (file != null)
            {
                product.Image = await file.ConvertToBytes();

                UnitOfWork.Update(product);
                await UnitOfWork.CompleteAsync();

                return RedirectToAction("Index");
            }
        }
        return View(product);
    }

    // GET: Products/Delete/5
    [Authorize]
    public ActionResult Delete(Guid? id)
    {
        if (id == null)
            return new StatusCodeResult((int)HttpStatusCode.BadRequest);

        var products = UnitOfWork.Product.FirstOrDefault(s => s.Id == id);
        if (products == null)
            return NotFound();

        return View(products);
    }

    // POST: Products/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(Guid id)
    {
        var products = UnitOfWork.Product.FirstOrDefault(s => s.Id == id);

        if (products == null) return RedirectToAction("Index");

        UnitOfWork.Remove(products);
        UnitOfWork.CompleteAsync();

        return RedirectToAction("Index");
    }
}