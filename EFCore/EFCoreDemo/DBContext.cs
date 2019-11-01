using EFCoreDemo.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreDemo
{
    public class MiddleContext : DbContext
    {
        public DbSet<SdfeyHisMedicineInLog> SdfeyHisMedicineInLogs { get; set; }

        public DbSet<SdfeyHisOutPatientInfo> SdfeyHisOutPatientInfos { get; set; }

        public DbSet<SdfeyHisPatientInfo> SdfeyHisPatientInfos { get; set; }

        public DbSet<SdfeyUnDrugDetail> SdfeyUnDrugDetails { get; set; }

        public MiddleContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseOracle(@"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=180.101.204.17(PORT=8002))(CONNECT_DATA=(SERVICE_NAME=helowin)));Persist Security Info=True;User ID=system;Password=whlx8888;", b => b.UseOracleSQLCompatibility("11"));
            // optionsBuilder.UseOracle(@"User Id=system;Password=whlx8888;Data Source=180.101.204.17:8002/helowin;", b => b.UseOracleSQLCompatibility("11"));

            optionsBuilder.UseSqlServer(@"Server=192.168.88.101; Database=KidneyDisease_Manage; User=sa; Password =whlx8888;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SdfeyHisMedicineInLog>(entity =>
            {
                entity.ToTable("SdfeyHisMedicineInLog");
               //  entity.Property(o => o.Id);

            });
            modelBuilder.Entity<SdfeyHisOutPatientInfo>(entity =>
            {
                entity.ToTable("SdfeyHisOutPatientInfo");
            });

            modelBuilder.Entity<SdfeyHisPatientInfo>(entity =>
            {
                entity.ToTable("SdfeyHisPatientInfo");
            });
            modelBuilder.Entity<SdfeyUnDrugDetail>(entity =>
            {
                entity.ToTable("SdfeyUnDrugDetail");
            });
        }
    }
}