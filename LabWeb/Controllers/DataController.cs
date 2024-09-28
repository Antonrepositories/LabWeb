using LabWeb.Models;
using LabWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabWeb.Controllers
{
    public class DataController : Controller
    {
        private readonly Lab1Context _context;

        public DataController(Lab1Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var databases = _context.DataBases.ToList();
            return View(databases);
        }
		public async Task<IActionResult> Details(int? id)
		{
			var dataBase = await _context.DataBases.FirstOrDefaultAsync(m => m.Id == id);
			if (dataBase == null)
			{
				return NotFound();
			}
			var tables = _context.Tables.Where(t => t.Database.Id == id).ToList();
			DetailsViewModel viewModel = new DetailsViewModel();
			viewModel.Tables = tables;
			viewModel.dataBase = dataBase;

			return View(viewModel);
		}
		public IActionResult Create()
		{
			//var databases = _context.DataBases.ToList();
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name")] DataBase dataBase)
		{
			if (ModelState.IsValid)
			{
				_context.Add(dataBase);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(dataBase);
		}
	}
}
