using System;

namespace EFCore.Oracle.Demo2.Entity.Hids.His
{
    public class SdfeyHisMedicineInLog
    {
        public int Id { get; set; }

        public string PatientId { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdentityNo { get; set; }

        /// <summary>
        /// 医保类型
        /// </summary>
        public string InsuranceType { get; set; }

        /// <summary>
        /// 医保卡号
        /// </summary>
        public string InsuranceNo { get; set; }

        /// <summary>
        /// 收费日期
        /// </summary>
        public DateTime? OperDate { get; set; }

        /// <summary>
        /// 药品种类
        /// </summary>
        public string MedicineType { get; set; }

        /// <summary>
        /// 药品名称
        /// </summary>
        public string MedicineName { get; set; }

        /// <summary>
        /// 通用名
        /// </summary>
        public string CommonName { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal? Quantity { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// 病历夹号
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 科室代码
        /// </summary>
        public string DeptCode { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 药房代码
        /// </summary>
        public string Stock_Code { get; set; }

        /// <summary>
        /// 药房名称
        /// </summary>
        public string Stock_Name { get; set; }
    }

    //public sealed class SdfeyHisMedicineInLogMapper : ClassMapper<SdfeyHisMedicineInLog>
    //{
    //    public SdfeyHisMedicineInLogMapper()
    //    {
    //        Table("HIS.VW_HIS_MEDICINEINLOG");
    //        Map(x => x.PatientId).Column("PatientId");
    //        Map(x => x.PatientName).Column("PatientName");
    //        Map(x => x.IdentityNo).Column("IdentityNo");
    //        Map(x => x.InsuranceType).Column("InsuranceType");
    //        Map(x => x.InsuranceNo).Column("InsuranceNo");
    //        Map(x => x.OperDate).Column("OperDate");
    //        Map(x => x.MedicineType).Column("MedicineType");
    //        Map(x => x.MedicineName).Column("MedicineName");
    //        Map(x => x.CommonName).Column("CommonName");
    //        Map(x => x.Unit).Column("Unit");
    //        Map(x => x.UnitPrice).Column("UnitPrice");
    //        Map(x => x.Quantity).Column("Quantity");
    //        Map(x => x.Amount).Column("Amount");
    //        Map(x => x.CardNo).Column("CardNo");
    //        Map(x => x.DeptCode).Column("DeptCode");
    //        Map(x => x.DeptName).Column("DeptName");
    //        Map(x => x.Stock_Code).Column("Stock_Code");
    //        Map(x => x.Stock_Name).Column("Stock_Name");
    //    }
    //}
}