namespace LabWeb.Models
{
    public class DataBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TableModel> Fields { get; set; } = new List<TableModel>();
    }
}
