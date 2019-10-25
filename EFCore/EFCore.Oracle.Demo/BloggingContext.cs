using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess;
using OracleInternal.NetCore;
namespace EFCore.Oracle.Demo
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        //public int Rating { get; set; }
        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(@"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=180.101.204.17(PORT=8002))(CONNECT_DATA=(SERVICE_NAME=helowin)));Persist Security Info=True;User ID=system;Password=whlx8888;", b => b.UseOracleSQLCompatibility("11"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Posts");
                entity.Property(o => o.PostId).ForOracleUseSequenceHiLo("Posts_PostId_sq3");

            });
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blogs");
                entity.Property(o => o.BlogId).ForOracleUseSequenceHiLo("Blogs_BlogId_sq1");

            });
        }
    }

}
