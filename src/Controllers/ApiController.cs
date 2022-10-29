using Microsoft.AspNetCore.Mvc;

namespace IYLTDSU.Api.Controllers;

[Route("api/[controller]")]
public class ApiController : Controller
{
    public IActionResult Index()
    {
        return RedirectPermanent("/swagger");
    }
}
