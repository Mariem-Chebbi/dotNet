using Microsoft.EntityFrameworkCore;

namespace TE.Data
{
    public class TEContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog = MyDB; 
                                        Integrated Security = true");
        }

    }
}