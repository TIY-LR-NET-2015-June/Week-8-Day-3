namespace Week8Day3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PostDbContext : DbContext
    {
        public PostDbContext()
            : base("name=postdbcontext")
        {
            
        }

        public DbSet<post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
