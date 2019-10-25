using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Oracle.Demo2.Migrations
{
    public partial class init_20191025 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "SdfeyHisMedicineInLog_Id_sq1",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "SdfeyHisOutPatientInfo_Id_sq1",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "SdfeyHisMedicineInLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    PatientId = table.Column<string>(nullable: true),
                    PatientName = table.Column<string>(nullable: true),
                    IdentityNo = table.Column<string>(nullable: true),
                    InsuranceType = table.Column<string>(nullable: true),
                    InsuranceNo = table.Column<string>(nullable: true),
                    OperDate = table.Column<DateTime>(nullable: true),
                    MedicineType = table.Column<string>(nullable: true),
                    MedicineName = table.Column<string>(nullable: true),
                    CommonName = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: true),
                    Amount = table.Column<decimal>(nullable: true),
                    CardNo = table.Column<string>(nullable: true),
                    DeptCode = table.Column<string>(nullable: true),
                    DeptName = table.Column<string>(nullable: true),
                    Stock_Code = table.Column<string>(nullable: true),
                    Stock_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SdfeyHisMedicineInLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SdfeyHisOutPatientInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    PatientId = table.Column<string>(nullable: true),
                    OutPatientNo = table.Column<string>(nullable: true),
                    PatientName = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    CertType = table.Column<string>(nullable: true),
                    CertNo = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Contatct = table.Column<string>(nullable: true),
                    RelationShip = table.Column<string>(nullable: true),
                    ContatctPhone = table.Column<string>(nullable: true),
                    ContatctMobile = table.Column<string>(nullable: true),
                    InsuranceType = table.Column<string>(nullable: true),
                    InsuranceNo = table.Column<string>(nullable: true),
                    OutPatientDepartment = table.Column<string>(nullable: true),
                    OutPatientDoctor = table.Column<string>(nullable: true),
                    SeeDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SdfeyHisOutPatientInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SdfeyHisMedicineInLog");

            migrationBuilder.DropTable(
                name: "SdfeyHisOutPatientInfo");

            migrationBuilder.DropSequence(
                name: "SdfeyHisMedicineInLog_Id_sq1");

            migrationBuilder.DropSequence(
                name: "SdfeyHisOutPatientInfo_Id_sq1");
        }
    }
}
