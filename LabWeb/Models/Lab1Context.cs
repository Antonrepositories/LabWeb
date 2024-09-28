using Microsoft.EntityFrameworkCore;

namespace LabWeb.Models
{
    public class Lab1Context : DbContext
    {
        public Lab1Context(DbContextOptions<Lab1Context> options) : base(options)
        {
        }
        public DbSet<DataBase> DataBases { get; set; }
        public DbSet<TableModel> Tables { get; set; }
        public DbSet<RowModel> Rows { get; set; }
        public DbSet<FieldModel> Fields { get; set; }

    }
}
