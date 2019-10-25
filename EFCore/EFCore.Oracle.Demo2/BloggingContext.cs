using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess;
using OracleInternal.NetCore;
using EFCore.Oracle.Demo2.Entity.Hids.His;

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

        public DbSet<SdfeyHisMedicineInLog> SdfeyHisMedicineInLogs { get; set; }

        public DbSet<SdfeyHisOutPatientInfo> SdfeyHisOutPatientInfos { get; set; }

        public DbSet<SdfeyHisPatientInfo> SdfeyHisPatientInfos { get; set; }

        public DbSet<SdfeyUnDrugDetail> SdfeyUnDrugDetails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseOracle(@"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=180.101.204.17(PORT=8002))(CONNECT_DATA=(SERVICE_NAME=helowin)));Persist Security Info=True;User ID=system;Password=whlx8888;", b => b.UseOracleSQLCompatibility("11"));
            // optionsBuilder.UseOracle(@"User Id=system;Password=whlx8888;Data Source=180.101.204.17:8002/helowin;", b => b.UseOracleSQLCompatibility("11"));

            optionsBuilder.UseOracle(@"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=180.101.204.17)(PORT=8002))(CONNECT_DATA=(SERVICE_NAME=helowin)));User ID=system;Password=whlx8888;", b => b.UseOracleSQLCompatibility("11"));
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
            modelBuilder.Entity<SdfeyHisMedicineInLog>(entity =>
            {
                entity.ToTable("SdfeyHisMedicineInLog");
                entity.Property(o => o.Id).ForOracleUseSequenceHiLo("SdfeyHisMedicineInLog_Id_sq1");

            });
            modelBuilder.Entity<SdfeyHisOutPatientInfo>(entity =>
            {
                entity.ToTable("SdfeyHisOutPatientInfo");
                entity.Property(o => o.Id).ForOracleUseSequenceHiLo("SdfeyHisOutPatientInfo_Id_sq1");

            });

            modelBuilder.Entity<SdfeyHisPatientInfo>(entity =>
            {
                entity.ToTable("SdfeyHisPatientInfo");
                entity.Property(o => o.Id).ForOracleUseSequenceHiLo("SdfeyHisPatientInfo_Id_sq1");

            });
            modelBuilder.Entity<SdfeyUnDrugDetail>(entity =>
            {
                entity.ToTable("SdfeyUnDrugDetail");
                entity.Property(o => o.Id).ForOracleUseSequenceHiLo("SdfeyUnDrugDetail_Id_sq1");

            });
        }
    }

}
