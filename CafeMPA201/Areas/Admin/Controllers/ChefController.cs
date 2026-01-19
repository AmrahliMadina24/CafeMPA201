using CafeMPA201.Contexts;
using CafeMPA201.ViewModels.ChefViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CafeMPA201.Areas.Admin.Controllers
{
    public class ChefController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _enviroment;
        private readonly string _folderPath;

        public ChefController(AppDbContext context,IWebHostEnvironment enviroment)
        {
            _context = context;
            _enviroment = enviroment;
            _folderPath = Path.Combine(_enviroment.WebRootPath, "images");

            
        }
        public async Task<IActionResult> Index()
        {
            var chefs = await _context.Chefs.Select(chef => new ChefGetVM()
            {
                Id = chef.Id,
                FullName=chef.FullName,
                ImagePath=chef.ImagePath,
               
                PositionName=chef.Position.Name

            }).ToListAsync();
            return View(chefs);
        }


        private async Task SendPositionsWithViewBag()
        {
            var positions = await _context.Positions.ToListAsync();
            ViewBag.Positions = positions;
        }

    }
}
