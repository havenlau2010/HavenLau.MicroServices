using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;





namespace PD_HIDS_DataSync.Models {
    /// <summary>
    /// 
    /// </summary>
    [DisplayName( "" )]
    public partial class VW_OutPatientInfo  {
        /// <summary>
        /// 初始化
        /// </summary>
        public VW_OutPatientInfo()  {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">标识</param>
        public VW_OutPatientInfo( int id )  {
        }
        /// <summary>
        /// 主键
        /// </summary>
        [DisplayName("主键")]
        [Required(ErrorMessage = "主键不能为空")]
        public int Id { get; set; }
        /// <summary>
        /// 患者索引号患者所对应的唯一索引号，也可选用身份证号
        /// </summary>
        [DisplayName( "患者索引号患者所对应的唯一索引号，也可选用身份证号" )]
        [Required(ErrorMessage = "患者索引号患者所对应的唯一索引号，也可选用身份证号不能为空")]
        [StringLength( 32 )]
        public string PatientNo { get; set; }
        /// <summary>
        /// 门诊索引号本医疗机构为门诊患者设置的唯一性编码
        /// </summary>
        [DisplayName( "门诊索引号本医疗机构为门诊患者设置的唯一性编码" )]
        [StringLength( 32 )]
        public string OutPatientNo { get; set; }
        /// <summary>
        /// 就诊卡号本医疗机构为患者设置的就诊卡号或者市民卡号
        /// </summary>
        [DisplayName( "就诊卡号本医疗机构为患者设置的就诊卡号或者市民卡号" )]
        [StringLength( 32 )]
        public string PatientCardNo { get; set; }
        /// <summary>
        /// 病历号患者在医疗机构中的病历编号
        /// </summary>
        [DisplayName( "病历号患者在医疗机构中的病历编号" )]
        [StringLength( 33 )]
        public string AnamnesisNo { get; set; }
        /// <summary>
        /// 患者来源患者就诊的来源：1-门诊；2-急诊；3-住院；9其他
        /// </summary>
        [DisplayName( "患者来源患者就诊的来源：1-门诊；2-急诊；3-住院；9其他" )]
        [StringLength( 32 )]
        public string PatientSource { get; set; }
        /// <summary>
        /// 患者姓名患者本人在公安户籍管理部门正式登记注册的姓氏和名称
        /// </summary>
        [DisplayName( "患者姓名患者本人在公安户籍管理部门正式登记注册的姓氏和名称" )]
        [StringLength( 32 )]
        public string PatientName { get; set; }
        /// <summary>
        /// 患者性别患者的性别
        /// </summary>
        [DisplayName( "患者性别患者的性别" )]
        [StringLength( 4 )]
        public string PatientSex { get; set; }
        /// <summary>
        /// 出生日期患者的出生日期
        /// </summary>
        [DisplayName( "出生日期患者的出生日期" )]
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// 患者年龄患者的年龄
        /// </summary>
        [DisplayName( "患者年龄患者的年龄" )]
        public int? PatientAge { get; set; }
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
        /// 联系地址患者指定的用于联系本人的当前常驻地址或工作单位地址
        /// </summary>
        [DisplayName( "联系地址患者指定的用于联系本人的当前常驻地址或工作单位地址" )]
        [StringLength( 128 )]
        public string Address { get; set; }
        /// <summary>
        /// 联系电话患者指定的用于联系本人的当前常用电话号码
        /// </summary>
        [DisplayName( "联系电话患者指定的用于联系本人的当前常用电话号码" )]
        [StringLength( 32 )]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 联系人姓名联系人在公安户籍管理部门正式登记注册的姓氏和名称
        /// </summary>
        [DisplayName( "联系人姓名联系人在公安户籍管理部门正式登记注册的姓氏和名称" )]
        [StringLength( 32 )]
        public string ContactPerson { get; set; }
        /// <summary>
        /// 联系人关系联系人与患者之间的关系
        /// </summary>
        [DisplayName( "联系人关系联系人与患者之间的关系" )]
        [StringLength( 16 )]
        public string ContactRelationship { get; set; }
        /// <summary>
        /// 联系人地址联系人当前常驻地址
        /// </summary>
        [DisplayName( "联系人地址联系人当前常驻地址" )]
        [StringLength( 128 )]
        public string ContactAddress { get; set; }
        /// <summary>
        /// 联系人电话联系人的电话号码
        /// </summary>
        [DisplayName( "联系人电话联系人的电话号码" )]
        [StringLength( 32 )]
        public string ContactPhoneNumber { get; set; }
        /// <summary>
        /// 门诊科室代码患者在医疗机构就诊的科室代码
        /// </summary>
        [DisplayName( "门诊科室代码患者在医疗机构就诊的科室代码" )]
        [StringLength( 32 )]
        public string DepartmentId { get; set; }
        /// <summary>
        /// 门诊科室名称患者在医疗机构就诊的科室名称
        /// </summary>
        [DisplayName( "门诊科室名称患者在医疗机构就诊的科室名称" )]
        [StringLength( 32 )]
        public string DepartmentName { get; set; }
        /// <summary>
        /// 接诊医生工号负责患者入院接诊的医师的工号
        /// </summary>
        [DisplayName( "接诊医生工号负责患者入院接诊的医师的工号" )]
        [StringLength( 32 )]
        public string DoctorId { get; set; }
        /// <summary>
        /// 接诊医生姓名负责患者入院接诊的医师
        /// </summary>
        [DisplayName( "接诊医生姓名负责患者入院接诊的医师" )]
        [StringLength( 32 )]
        public string DoctorName { get; set; }
        /// <summary>
        /// 门诊诊断门诊诊断信息
        /// </summary>
        [DisplayName( "门诊诊断门诊诊断信息" )]
        [StringLength( 32 )]
        public string Diagnosis { get; set; }
        /// <summary>
        /// 就诊日期患者在门诊就诊的日期
        /// </summary>
        [DisplayName( "就诊日期患者在门诊就诊的日期" )]
        public DateTime? VisitDate { get; set; }
       
    }
}