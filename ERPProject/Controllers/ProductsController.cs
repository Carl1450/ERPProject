using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.Controllers;

[Authorize]
public class ProductsController : Controller
{
    public IActionResult Index()
    {
        return View("~/Views/Products/Index.cshtml");
}
}