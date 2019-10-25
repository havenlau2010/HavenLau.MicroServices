using System;


namespace EFCore.Oracle.Demo2.Entity.Hids.His
{
    
    /// <summary>
    /// 苏大附二医住院患者表
    /// </summary>
    public class SdfeyHisPatientInfo
    {
        public int Id { get; set; }
        /// <summary>
        /// 住院号
        /// </summary>
        public string PatientId { get; set; }


        /// <summary>
        /// 住院流水号
        /// </summary>
        public string InPatientNo { get; set; }


        /// <summary>
        /// 病历号
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string PatientName { get; set; }



        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }


        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime Birthday { get; set; }


        /// <summary>
        /// 证件类型
        /// </summary>
        public  string CertType { get; set; }


        /// <summary>
        /// 证件号
        /// </summary>
        public  string CertNo { get; set; }


        /// <summary>
        /// 地址
        /// </summary>
        public  string Address { get; set; }


        /// <summary>
        /// 联系人
        /// </summary>
        public  string Contatct { get; set; }


        /// <summary>
        /// 联系人关系
        /// </summary>
        public  string RelationShip { get; set; }


        /// <summary>
        /// 联系人号码
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
        public string InsuranceNO { get; set; }


        /// <summary>
        /// 科室名称
        /// </summary>
        public string InpatientDepartment { get; set; }


        /// <summary>
        /// 医师姓名(住院)
        /// </summary>
        public string InpatientDoctor { get; set; }


        /// <summary>
        /// 病床号
        /// </summary>
        public string BedNO { get; set; }


        /// <summary>
        /// 入院日期
        /// </summary>
        public DateTime AdmissionDate { get; set; }
    }


    //public sealed class SdfeyHisPatientInfoMapper : ClassMapper<SdfeyHisPatientInfo>
    //{
    //    public SdfeyHisPatientInfoMapper()
    //    {
    //        Table("HIS.GETHISPATIENTINFO");
    //        Map(x => x.PatientId).Column("PatientId");
    //        Map(x => x.InPatientNo).Column("InPatientNo");
    //        Map(x => x.CardNo).Column("CardNo");
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
    //        Map(x => x.InsuranceNO).Column("InsuranceNO");
    //        Map(x => x.InpatientDepartment).Column("InpatientDepartment");
    //        Map(x => x.InpatientDoctor).Column("InpatientDoctor");
    //        Map(x => x.BedNO).Column("BedNO");
    //        Map(x => x.AdmissionDate).Column("AdmissionDate");
    //    }
    //}
}