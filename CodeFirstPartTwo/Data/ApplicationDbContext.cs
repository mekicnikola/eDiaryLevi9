using CodeFirstPartTwo.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstPartTwo.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("name=CodeFirstPartTwoDb")
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<EngineType> EngineTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasRequired(c => c.Engine)
                .WithRequiredPrincipal(e => e.Car);

            modelBuilder.Entity<Engine>()
                .HasRequired<EngineType>(e => e.EngineType)
                .WithMany(et => et.Engines)
                .HasForeignKey(e => e.EngineTypeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
