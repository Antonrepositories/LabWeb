#nullable disable
using LabWeb.Models;

namespace LabWeb.ViewModel
{
	public class TableDetailsViewModel
	{
		public TableModel table { get; set; }
		public List<RowModel> rows { get; set; }
	}
}
