#nullable disable
using LabWeb.Models;

namespace LabWeb.ViewModel
{
	public class CreateRowViewModel
	{
		public TableModel TableModel { get; set; }
		public string RowData { get; set; }
		public int RowId { get; set; }
		public List<string> Row {  get; set; }
		public List<FieldModel> Fields { get; set; }
	}
}
