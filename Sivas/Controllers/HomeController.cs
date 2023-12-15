namespace Sivas.Controllers;

public class HomeController : Controller
{
    public ActionResult Index() => View(UnitOfWork.Product.GetAll(s => s.Offer == true)
            .OrderBy(s => s.Category)
            .ToList());

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
}