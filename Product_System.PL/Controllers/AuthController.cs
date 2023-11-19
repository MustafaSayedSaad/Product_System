using System.Collections.Generic;

namespace Product_System.PL.Controllers;
public class AuthController(IAuthService service) : Controller
{
    private readonly IAuthService _service = service;

    [HttpGet]
    public IActionResult LoginUser() => View();

    [HttpPost]
    public async Task<IActionResult> LoginUser(AuthLoginUserVM model)
    {
        var obj = await _service.LoginUserAsync(model);
        return View(obj);
    }
}