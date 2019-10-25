using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;





namespace PD_HIDS_DataSync.Models {
    /// <summary>
    /// 
    /// </summary>
    [DisplayName( "" )]
    public partial class VW_OutPatientPrescription  {
        /// <summary>
        /// 初始化
        /// </summary>
        public VW_OutPatientPrescription()  {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">标识</param>
        public VW_OutPatientPrescription( int id )  {
        }
        /// <summary>
        /// 主键
        /// </summary>
        [DisplayName("主键")]
        [Required(ErrorMessage = "主键不能为空")]
        public int Id { get; set; }
        /// <summary>
        /// 处方号(内码)如：21407700
        /// </summary>
        [DisplayName( "处方号(内码)如：21407700" )]
        [StringLength( 32 )]
        public string PrescriptionId { get; set; }
        /// <summary>
        /// 处方号如：21407700
        /// </summary>
        [DisplayName( "处方号如：21407700" )]
        [StringLength( 32 )]
        public string PrescriptionNo { get; set; }
        /// <summary>
        /// 开方时间如：2013-02-13 11:01:37
        /// </summary>
        [DisplayName( "开方时间如：2013-02-13 11:01:37" )]
        public DateTime? PrescriptionDate { get; set; }
        /// <summary>
        /// 就诊科室如：肾内科
        /// </summary>
        [DisplayName( "就诊科室如：肾内科" )]
        [StringLength( 32 )]
        public string Department { get; set; }
        /// <summary>
        /// 就诊科室代码如：340
        /// </summary>
        [DisplayName( "就诊科室代码如：340" )]
        [StringLength( 32 )]
        public string DepartmentId { get; set; }
        /// <summary>
        /// 开方医生如：张三
        /// </summary>
        [DisplayName( "开方医生如：张三" )]
        [StringLength( 32 )]
        public string Doctor { get; set; }
        /// <summary>
        /// 医生工号如：001
        /// </summary>
        [DisplayName( "医生工号如：001" )]
        [StringLength( 32 )]
        public string DoctorId { get; set; }
        /// <summary>
        /// 诊断名称如：慢性肾炎
        /// </summary>
        [DisplayName( "诊断名称如：慢性肾炎" )]
        [StringLength( 32 )]
        public string Diagnosis { get; set; }
        /// <summary>
        /// 门诊号如：02993245
        /// </summary>
        [DisplayName( "门诊号如：02993245" )]
        [StringLength( 32 )]
        public string OutPatientNo { get; set; }
        /// <summary>
        /// 姓名如：李四
        /// </summary>
        [DisplayName( "姓名如：李四" )]
        [StringLength( 32 )]
        public string PatientName { get; set; }
        /// <summary>
        /// 医保类型如：医保
        /// </summary>
        [DisplayName( "医保类型如：医保" )]
        [StringLength( 32 )]
        public string InsuranceType { get; set; }
        /// <summary>
        /// 医保卡号如：8100003786
        /// </summary>
        [DisplayName( "医保卡号如：8100003786" )]
        [StringLength( 32 )]
        public string InsuranceNO { get; set; }
        /// <summary>
        /// 发票号如：16253334
        /// </summary>
        [DisplayName( "发票号如：16253334" )]
        [StringLength( 32 )]
        public string InvoiceId { get; set; }
        /// <summary>
        /// 作废状态如：0-未作废，1-已作废
        /// </summary>
        [DisplayName( "作废状态如：0-未作废，1-已作废" )]
        public int? Canceled { get; set; }
        /// <summary>
        /// 证件类型患者的证件类型
        /// </summary>
        [DisplayName( "证件类型患者的证件类型" )]
        [StringLength( 32 )]
        public string IdentificationType { get; set; }
        /// <summary>
        /// 证件号码患者的证件号码
        /// </summary>
        [DisplayName( "证件号码患者的证件号码" )]
        [StringLength( 32 )]
        public string IdentificationNo { get; set; }
        /// <summary>
        /// 医保类型患者医疗保险的类型
        /// </summary>
        [DisplayName( "医保类型患者医疗保险的类型" )]
        [StringLength( 32 )]
        public string MedicareType { get; set; }
        /// <summary>
        /// 医保卡号患者医疗保险卡的号码
        /// </summary>
        [DisplayName( "医保卡号患者医疗保险卡的号码" )]
        [StringLength( 32 )]
        public string MedicareCardNo { get; set; }
        /// <summary>
        /// 患者索引号患者所对应的唯一索引号，也可选用身份证号
        /// </summary>
        [DisplayName( "患者索引号患者所对应的唯一索引号，也可选用身份证号" )]
        [StringLength( 32 )]
        public string PatientNo { get; set; }
        
    }
}