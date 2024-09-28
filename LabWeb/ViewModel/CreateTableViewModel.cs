using LabWeb.Models;

namespace LabWeb.ViewModel
{
	public class CreateTableViewModel
	{
		public int BaseId { get; set; }
		public string TableName { get; set; }

		public List<FieldViewModel> Fields { get; set; } = new List<FieldViewModel>();
	}
	public class FieldViewModel
	{
		public string FieldName { get; set; }
		public string DataType { get; set; }
	}
}
