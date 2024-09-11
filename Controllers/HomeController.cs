using Microsoft.AspNetCore.Mvc;
using Multi_Page_WebApp_Contacts.Models;
using Microsoft.EntityFrameworkCore;

namespace Multi_Page_WebApp_Contacts.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext context { get; set; }
    public HomeController(ContactContext ctx) => context = ctx;
    public IActionResult Index()
    {
        var movies = context.Contacts.OrderBy(m => m.Name).ToList();
        return View(movies);

    }
}
}
