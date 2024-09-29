using LabWeb.Models;
using LabWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabWeb.Controllers
{
	public class RowController : Controller
	{
		private readonly Lab1Context _context;

		public RowController(Lab1Context context)
		{
			_context = context;
		}
		public IActionResult Create(int ? id)
		{
			var table = _context.Tables.FirstOrDefault(t => t.Id == id);
			CreateRowViewModel model = new CreateRowViewModel();
			model.TableModel = table;
			var fields = _context.Fields.Where(f=> f.Table == table).ToList();
			model.Fields = fields;
			model.Row = new List<string>(new string[fields.Count]);
			return View(model);
		}
        [HttpPost]
        public IActionResult Create(CreateRowViewModel model)
        {
            if (model.TableModel == null || model.TableModel.Id == 0)
            {
                return BadRequest("Table information is missing.");
            }

            var table = _context.Tables.FirstOrDefault(t => t.Id == model.TableModel.Id);
            model.Fields = _context.Fields.Where(f => f.Table == table).ToList();

            if (table == null)
            {
                return NotFound("Table not found.");
            }

            // Perform validation as before
            // ...
            for (var i = 0; i < model.Fields.Count; i++)
            {
                Console.WriteLine(model.Fields[i].Name + ">>>>>>>>>>>>>>");
            }
            for (var i = 0; i < model.Row.Count; i++)
            {
                Console.WriteLine(model.Row[i] + ">>>>>>>>>>>>>>");
            }

            if (!ModelState.IsValid)
            {
                model.Fields = table.Fields.ToList();
                return View(model);
            }

            string rowData = string.Join("|", model.Row);

            var newRow = new RowModel
            {
                Table = table,
                RowData = rowData
            };
            //_context.Rows.Add(newRow);
            //_context.SaveChanges();

            return RedirectToAction("Index", "Data");
        }




    }
}

