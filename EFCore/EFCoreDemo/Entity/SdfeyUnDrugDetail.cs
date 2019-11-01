using System;


namespace EFCoreDemo.Entity
{
    public class SdfeyUnDrugDetail : BaseEntity
    {
        public string PatientId { get; set; }

        /// <summary>
        /// 处方号
        /// </summary>
        public string UniqueNo { get; set; }

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
        /// 项目代码
        /// </summary>
        public string UndrugCode { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string UndrugName { get; set; }

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
        public decimal? OwnCost { get; set; }

        /// <summary>
        /// 状态--0未确认，1确认
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 是否成功--0未作废，1作废
        /// </summary>
        public string Sucessed { get; set; }

        /// <summary>
        /// 病历卡号
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
    }


    //public sealed class SdfeyUnDrugDetailMapper : ClassMapper<SdfeyUnDrugDetail>
    //{
    //    public SdfeyUnDrugDetailMapper()
    //    {
    //        Table("HIS.VW_HIS_UNDRUGDETAIL");

    //        Map(x => x.PatientId).Column("PatientId");
    //        Map(x => x.UniqueNo).Column("UniqueNo");
    //        Map(x => x.PatientName).Column("PatientName");
    //        Map(x => x.IdentityNo).Column("IdentityNo");
    //        Map(x => x.InsuranceType).Column("InsuranceType");
    //        Map(x => x.InsuranceNo).Column("InsuranceNo");
    //        Map(x => x.OperDate).Column("OperDate");
    //        Map(x => x.UndrugCode).Column("UndrugCode");
    //        Map(x => x.UndrugName).Column("UndrugName");
    //        Map(x => x.UnitPrice).Column("UnitPrice");
    //        Map(x => x.Quantity).Column("Quantity");
    //        Map(x => x.OwnCost).Column("OwnCost");
    //        Map(x => x.Status).Column("Status");
    //        Map(x => x.Sucessed).Column("Sucessed");
    //        Map(x => x.CardNo).Column("CardNo");
    //        Map(x => x.DeptCode).Column("DeptCode");
    //        Map(x => x.DeptName).Column("DeptName");
    //    }
    //}
}