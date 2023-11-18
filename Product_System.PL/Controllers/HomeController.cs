namespace Product_System.PL.Controllers;
public class HomeController(IProductService service) : Controller
{
    private readonly IProductService _service = service;

    public IActionResult Index()
    {
        var list = _service.GetAllProductsAsync(1);
        return View(list);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
