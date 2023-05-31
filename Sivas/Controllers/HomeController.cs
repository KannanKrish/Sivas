namespace Sivas.Controllers;

public class HomeController : Controller
{
    private readonly SivasContext db = new();

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
        //return View();
    }

    public ActionResult About()
    {
        ViewBag.Message = "About Us";

        return View();
    }

    public ActionResult Contact()
    {
        ViewBag.Message = "Contact Information";

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