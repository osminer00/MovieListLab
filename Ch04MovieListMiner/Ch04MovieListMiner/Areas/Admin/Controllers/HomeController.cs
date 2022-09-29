using Ch04MovieListMiner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Ch04MovieList.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        [Route("[area]/[controller]s/Dummy1")]
        public IActionResult Dummy1() 
        {
            
            return View();
        }
        [Route("[area]/[controller]s/Dummy3")]
        public IActionResult Dummy2()
        {

            return View();
        }
        [Route("[area]/[controller]s/Dummy2")]
        public IActionResult Dummy3()
        {

            return View();
        }
    }
}
