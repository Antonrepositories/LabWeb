#nullable disable

namespace LabWeb.Models
{
    public class TableModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int DatabaseId { get; set; }
        public DataBase Database { get; set; }
        public List<FieldModel> Fields { get; set; } = new List<FieldModel>();
        public List<RowModel> Rows { get; set; } = new List<RowModel>();

    }

}
