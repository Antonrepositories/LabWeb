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

            for (var i = 0; i < model.Fields.Count; i++)
            {
                Console.WriteLine(model.Fields[i].Name + ">>>>>>>>>>>>>>");
            }
            for (var i = 0; i < model.Row.Count; i++)
            {
                Console.WriteLine(model.Row[i] + ">>>>>>>>>>>>>>");
            }
            for (var i = 0; i < model.Fields.Count; i++)
            {
                var field = model.Fields[i];
                var fieldValue = model.Row[i];

                if (string.IsNullOrEmpty(fieldValue))
                {
                    ModelState.AddModelError($"Row[{i}]", $"{field.Name} cannot be empty.");
                    continue;
                }

                if (field.DataType == "datelnvl")
                {
                    var dates = fieldValue.Split(" - ");
                    if (dates.Length != 2 ||
                        !DateTime.TryParse(dates[0], out var startDate) ||
                        !DateTime.TryParse(dates[1], out var endDate) ||
                        startDate >= endDate)
                    {
                        Console.WriteLine("INVALID DATA LNVL ++++++++++++++++++++++++++++++++++");
                        ModelState.AddModelError($"Row[{i}]", $"{field.Name} should be a valid date interval in the format YYYY-MM-DD - YYYY-MM-DD, with the first date before the second.");
                    }
                }
                if (field.DataType == "date")
                {
                    if (!DateTime.TryParse(fieldValue, out var date))
                    {
                        Console.WriteLine("INVALID DATA ++++++++++++++++++++++++++++++++");
                        ModelState.AddModelError($"Row[{i}]", $"{field.Name} should be a valid date");
                    }
                }
            }
            string rowData = string.Join("|", model.Row);
            Console.WriteLine(rowData + "+++++++++++++++++++++++++");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
                Console.WriteLine(errors + "----------------------------------");
                //Console.WriteLine("INVALID DATA ++++++++++++++++++++++++++++++++");
                model.Fields = table.Fields.ToList();
                return View(model);
            }

            //string rowData = string.Join("|", model.Row);
            //Console.WriteLine(rowData + "+++++++++++++++++++++++++");
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

