using Microsoft.AspNetCore.Mvc;

namespace LabWeb.Controllers
{
	public class RowController : Controller
	{
		public IActionResult Create(int ? id)
		{
			return View();
		}
	}
}
