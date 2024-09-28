using LabWeb.Models;

namespace LabWeb.ViewModel
{
	public class DetailsViewModel
	{
		public DataBase dataBase { get; set; }
		public List<TableModel> Tables { get; set; }
	}
}
