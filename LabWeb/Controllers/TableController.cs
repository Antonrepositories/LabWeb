using LabWeb.Models;
using LabWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LabWeb.Controllers
{
	public class TableController : Controller
	{

		private readonly Lab1Context _context;

		public TableController(Lab1Context context)
		{
			_context = context;
		}
		public IActionResult Create(int ? id)
		{
			CreateTableViewModel model = new CreateTableViewModel();
			var dataBase = _context.DataBases.FirstOrDefault(x => x.Id == id);
			model.BaseId = dataBase.Id;
			return View(model);
		}
		
		
		[HttpPost]
		public async Task<IActionResult> CreateTable(int baseId, string tableName, List<string> fieldNames, List<string> dataTypes)
		{
			var table = new TableModel
			{
				Name = tableName,
				Database = _context.DataBases.FirstOrDefault(b => b.Id == baseId)
			};

			for (int i = 0; i < fieldNames.Count; i++)
			{
				FieldModel field = new FieldModel
				{
					Name = fieldNames[i],
					DataType = dataTypes[i],
					Table = table
				};
				//table.Fields.Add(field);
				_context.Add(field);
			}
			_context.Add(table);
			await _context.SaveChangesAsync();
			for (int i = 0; i < fieldNames.Count; i++)
			{
				FieldModel field = new FieldModel
				{
					Name = fieldNames[i],
					DataType = dataTypes[i],
					Table = table
				};
				//table.Fields.Add(field);
				_context.Add(field);
			}


			return RedirectToAction("Index", "Data");
		}

	}
}
