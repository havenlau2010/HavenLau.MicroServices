using System;


namespace EFCore.Oracle.Demo2.Entity.Hids.His
{
    /// <summary>
    /// 苏大附二医门诊患者表
    /// </summary>
    public class SdfeyHisOutPatientInfo
    {
        public int Id { get; set; }
        /// <summary>
        /// 就诊卡号
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// 门诊号
        /// </summary>
        public string OutPatientNo { get; set; }


        /// <summary>
        /// 患者姓名
        /// </summary>
        public  string PatientName { get; set; }


        /// <summary>
        /// 性别
        /// </summary>
        public  string Sex { get; set; }


        /// <summary>
        /// 生日
        /// </summary>
        public  DateTime Birthday { get; set; }


        /// <summary>
        /// 证件类型
        /// </summary>
        public  string CertType { get; set; }


        /// <summary>
        /// 证件号
        /// </summary>
        public  string CertNo { get; set; }


        /// <summary>
        /// 联系地址
        /// </summary>
        public  string Address { get; set; }


        /// <summary>
        /// 联系人
        /// </summary>
        public  string Contatct { get; set; }


        /// <summary>
        /// 与联系人关系
        /// </summary>
        public  string RelationShip { get; set; }


        /// <summary>
        /// 联系号码
        /// </summary>
        public  string ContatctPhone { get; set; }


        /// <summary>
        /// 联系人手机
        /// </summary>
        public  string ContatctMobile { get; set; }


        /// <summary>
        /// 合同单位名称
        /// </summary>
        public string InsuranceType { get; set; }


        /// <summary>
        /// 医疗证号
        /// </summary>
        public string InsuranceNo { get; set; }


        /// <summary>
        /// 科室名称
        /// </summary>
        public string OutPatientDepartment { get; set; }


        /// <summary>
        /// 医师姓名
        /// </summary>
        public string OutPatientDoctor { get; set; }


        /// <summary>
        /// 看诊日期
        /// </summary>
        public DateTime SeeDate { get; set; }
    }


    //public sealed class SdfeyHisOutPatientInfoMapper : ClassMapper<SdfeyHisOutPatientInfo>
    //{
    //    public SdfeyHisOutPatientInfoMapper()
    //    {
    //        Table("HIS.GETHISOUTPATIENTINFO");
    //        Map(x => x.PatientId).Column("PatientId");
    //        Map(x => x.OutPatientNo).Column("OutPatientNo");
    //        Map(x => x.PatientName).Column("PatientName");
    //        Map(x => x.Sex).Column("Sex");
    //        Map(x => x.Birthday).Column("Birthday");
    //        Map(x => x.CertType).Column("CertType");
    //        Map(x => x.CertNo).Column("CertNo");
    //        Map(x => x.Address).Column("Address");
    //        Map(x => x.Contatct).Column("Contatct");
    //        Map(x => x.RelationShip).Column("RelationShip");
    //        Map(x => x.ContatctPhone).Column("ContatctPhone");
    //        Map(x => x.ContatctMobile).Column("ContatctMobile");
    //        Map(x => x.InsuranceType).Column("InsuranceType");
    //        Map(x => x.InsuranceNo).Column("InsuranceNo");
    //        Map(x => x.OutPatientDepartment).Column("OutPatientDepartment");
    //        Map(x => x.OutPatientDoctor).Column("OutPatientDoctor");
    //        Map(x => x.SeeDate).Column("SeeDate");
    //    }
    //}
}