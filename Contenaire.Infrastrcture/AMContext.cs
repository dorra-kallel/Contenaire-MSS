/*using Microsoft.EntityFrameworkCore;

namespace Contenaire.Infrastrcture
{

    public class AMContext : DbContext 
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
              Initial Catalog=AirportManagementDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }


        public AMContext()
        {

        }

        public AMContext(DbContextOptions<AMContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {

        }



    }
}
*/