using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Oracle.Demo2.Migrations
{
    public partial class init_201910251417 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "SdfeyHisPatientInfo_Id_sq1",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "SdfeyUnDrugDetail_Id_sq1",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "SdfeyHisPatientInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    PatientId = table.Column<string>(nullable: true),
                    InPatientNo = table.Column<string>(nullable: true),
                    CardNo = table.Column<string>(nullable: true),
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
                    InsuranceNO = table.Column<string>(nullable: true),
                    InpatientDepartment = table.Column<string>(nullable: true),
                    InpatientDoctor = table.Column<string>(nullable: true),
                    BedNO = table.Column<string>(nullable: true),
                    AdmissionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SdfeyHisPatientInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SdfeyUnDrugDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    PatientId = table.Column<string>(nullable: true),
                    UniqueNo = table.Column<string>(nullable: true),
                    PatientName = table.Column<string>(nullable: true),
                    IdentityNo = table.Column<string>(nullable: true),
                    InsuranceType = table.Column<string>(nullable: true),
                    InsuranceNo = table.Column<string>(nullable: true),
                    OperDate = table.Column<DateTime>(nullable: true),
                    UndrugCode = table.Column<string>(nullable: true),
                    UndrugName = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: true),
                    OwnCost = table.Column<decimal>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Sucessed = table.Column<string>(nullable: true),
                    CardNo = table.Column<string>(nullable: true),
                    DeptCode = table.Column<string>(nullable: true),
                    DeptName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SdfeyUnDrugDetail", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SdfeyHisPatientInfo");

            migrationBuilder.DropTable(
                name: "SdfeyUnDrugDetail");

            migrationBuilder.DropSequence(
                name: "SdfeyHisPatientInfo_Id_sq1");

            migrationBuilder.DropSequence(
                name: "SdfeyUnDrugDetail_Id_sq1");
        }
    }
}
