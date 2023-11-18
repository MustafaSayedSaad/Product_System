namespace Product_System.PL.Controllers;
public class ProductsController(IProductService service) : Controller
{
    private readonly IProductService _service = service;


    public async Task<IActionResult> IndexAsync(int productCategoryId)
    {
        var list = await _service.GetAllProductsAsync(productCategoryId);
        return View(list);
    }

    public async Task<IActionResult> DetailsAsync(int id)
    {
        var obj = await _service.GetProductByIdAsync(id);

        if (obj is null)
            return NotFound();

        return View(obj);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        SalCreateProductVM obj = new()
        {
            ProductsCategories = await _service.ListOfProductsCategoriesAsync()
        };

        return View(obj);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SalCreateProductVM model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _service.CreateProductAsync(model);

        return RedirectToAction(nameof(IndexAsync));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> EditAsync([FromRoute] int id)
    {
        var obj = await _service.GetProductByIdAsync(id);

        if (obj is null)
            return NotFound();
        return View(obj);
    }

    [HttpPost("{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromRoute] int id, SalUpdateProductVM model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var obj = await _service.UpdateProductAsync(id, model);

        if (obj is null)
            return BadRequest();

        return RedirectToAction(nameof(IndexAsync));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        bool isSucceded = await _service.DeleteProductAsync(id);

        return isSucceded ? Ok() : BadRequest();
    }
}