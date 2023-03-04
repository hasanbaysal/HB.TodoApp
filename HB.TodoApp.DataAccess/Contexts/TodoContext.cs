using HB.TodoApp.DataAccess.Configurations;
using HB.TodoApp.Entities.Domains;
using Microsoft.EntityFrameworkCore;


namespace HB.TodoApp.DataAccess.Contexts
{
    public class TodoContext:DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options):base(options)
        {

        }
        
        public DbSet<Work>  Works { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkConfigurations());
        }
    }
}
