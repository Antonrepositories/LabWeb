using LabWeb.Models;
using LabWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
		public IActionResult Details(int? id, string SearchString)
		{
			TableDetailsViewModel model = new TableDetailsViewModel();
			var table = _context.Tables.FirstOrDefault(x => x.Id == id);
			model.table = table;
			var rows = _context.Rows.Where(f => f.Table == table).ToList();
			if (!SearchString.IsNullOrEmpty())
			{
				rows = rows.Where(r => r.RowData.Contains(SearchString)).ToList();
			}
			model.rows = rows;
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
			var tables = _context.Tables.Where(t => t.Database.Id == baseId);
			var tabletest = tables.Where(t => t.Name == tableName).ToList();
			if (tabletest.Any())
			{
				return Problem("Table already exists");
			}

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

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Tables == null)
			{
				return NotFound();
			}

			var table = await _context.Tables.FirstOrDefaultAsync(i => i.Id == id);
			if (table == null)
			{
				return NotFound();
			}

			return View(table);
		}
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Tables == null)
			{
				return Problem("Entity set is null.");
			}
			var table = await _context.Tables.FindAsync(id);
			if (table != null)
			{
				_context.Tables.Remove(table);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction("Index", "Data");
		}
	}
}
