#nullable disable
namespace LabWeb.Models
{
    public class FieldModel
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string DataType { get; set; } 
        public TableModel Table { get; set; }
    }
}
