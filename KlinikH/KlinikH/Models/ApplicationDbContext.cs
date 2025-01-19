using Microsoft.EntityFrameworkCore;

namespace KlinikH.Models
{
    //NOTE: need to extend the public class with the DbContext
    public class ApplicationDbContext : DbContext
    {
        //NOTE: constructor needs to be defined
        public ApplicationDbContext(DbContextOptions options) : base (options)
        {

        }

        //NOTE: very important that whatever is defined here create a code schema
        public required DbSet<Transaction> Transactions { get; set; }
        public required DbSet<Category> Categories { get; set; }
    }

}
