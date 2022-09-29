using Ch04MovieListMiner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Ch04MovieList.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext context { get; set; }
        public HomeController(MovieContext ctx)
        {
            context = ctx;
        }
        [Route("[controller]s/{id?}")]
        public IActionResult Dummy1() //custom routing
        {
            
            return View();
        }
        [Route("Dummy2")] //attribute routing
        public IActionResult Dummy2()
        {

            return View();
        }
        [Route("/")] //default routing
        public IActionResult Dummy3()
        {

            return View();
        }

        public IActionResult Index()
        {
            var movies = context.Movies.Include(m => m.Genre).OrderBy(m => m.Name).ToList();
            return View(movies);
        }
    }
}
