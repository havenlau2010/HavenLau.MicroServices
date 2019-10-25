using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;





namespace PD_HIDS_DataSync.Models {
    /// <summary>
    /// 
    /// </summary>
    [DisplayName( "" )]
    public partial class VW_MedicalOrders  {
        /// <summary>
        /// 初始化
        /// </summary>
        public VW_MedicalOrders()  {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">标识</param>
        public VW_MedicalOrders( int id )  {
        }
        /// <summary>
        /// 主键
        /// </summary>
        [DisplayName("主键")]
        [Required(ErrorMessage = "主键不能为空")]
        public int Id { get; set; }
        /// <summary>
        /// 患者索引号
        /// </summary>
        [DisplayName( "患者索引号" )]
        [StringLength( 32 )]
        public string PatientNo { get; set; }
        /// <summary>
        /// 住院索引号
        /// </summary>
        [DisplayName( "住院索引号" )]
        [StringLength( 32 )]
        public string InPatientNo { get; set; }
        /// <summary>
        /// 就诊卡号
        /// </summary>
        [DisplayName( "就诊卡号" )]
        [StringLength( 32 )]
        public string PatientCardNo { get; set; }
        /// <summary>
        /// 病案号
        /// </summary>
        [DisplayName( "病案号" )]
        [StringLength( 32 )]
        public string EMRNo { get; set; }
        /// <summary>
        /// 住院次数
        /// </summary>
        [DisplayName( "住院次数" )]
        public int? InHospitalNum { get; set; }
        /// <summary>
        /// 医嘱号
        /// </summary>
        [DisplayName( "医嘱号" )]
        [StringLength( 32 )]
        public string OrderNo { get; set; }
        /// <summary>
        /// 医嘱分组号
        /// </summary>
        [DisplayName( "医嘱分组号" )]
        [StringLength( 64 )]
        public string OrderGroupNo { get; set; }
        /// <summary>
        /// 医嘱计划开始日期
        /// </summary>
        [DisplayName( "医嘱计划开始日期" )]
        public DateTime? OrderPlanBeginDate { get; set; }
        /// <summary>
        /// 医嘱计划结束日期
        /// </summary>
        [DisplayName( "医嘱计划结束日期" )]
        public DateTime? OrderPlanEndDate { get; set; }
        /// <summary>
        /// 医嘱开立日期
        /// </summary>
        [DisplayName( "医嘱开立日期" )]
        public DateTime? OrderDate { get; set; }
        /// <summary>
        /// 医嘱开始日期
        /// </summary>
        [DisplayName( "医嘱开始日期" )]
        public DateTime? OrderBeginDate { get; set; }
        /// <summary>
        /// 医嘱审核日期
        /// </summary>
        [DisplayName( "医嘱审核日期" )]
        public DateTime? OrderProofDate { get; set; }
        /// <summary>
        /// 医嘱取消日期
        /// </summary>
        [DisplayName( "医嘱取消日期" )]
        public DateTime? OrderCancelDate { get; set; }
        /// <summary>
        /// 医嘱停止日期
        /// </summary>
        [DisplayName( "医嘱停止日期" )]
        public DateTime? OrderStopDate { get; set; }
        /// <summary>
        /// 医嘱执行日期
        /// </summary>
        [DisplayName( "医嘱执行日期" )]
        public DateTime? OrderExcuteDate { get; set; }
        /// <summary>
        /// 医嘱结束日期
        /// </summary>
        [DisplayName( "医嘱结束日期" )]
        public DateTime? OrderEndDate { get; set; }
        /// <summary>
        /// 医嘱项目类型代码
        /// </summary>
        [DisplayName( "医嘱项目类型代码" )]
        [StringLength( 32 )]
        public string OrderItemTypeCode { get; set; }
        /// <summary>
        /// 医嘱项目类型名称
        /// </summary>
        [DisplayName( "医嘱项目类型名称" )]
        [StringLength( 32 )]
        public string OrderItemTypeName { get; set; }
        /// <summary>
        /// 医嘱类别代码
        /// </summary>
        [DisplayName( "医嘱类别代码" )]
        [StringLength( 32 )]
        public string OrderCategoryCode { get; set; }
        /// <summary>
        /// 医嘱类别名称
        /// </summary>
        [DisplayName( "医嘱类别名称" )]
        [StringLength( 32 )]
        public string OrderCategoryName { get; set; }
        /// <summary>
        /// 医嘱项目代码
        /// </summary>
        [DisplayName( "医嘱项目代码" )]
        [StringLength( 32 )]
        public string OrderItemCode { get; set; }
        /// <summary>
        /// 医嘱项目名称
        /// </summary>
        [DisplayName( "医嘱项目名称" )]
        [StringLength( 32 )]
        public string OrderItemName { get; set; }
        /// <summary>
        /// 药品规格
        /// </summary>
        [DisplayName( "药品规格" )]
        [StringLength( 255 )]
        public string DrugSpecification { get; set; }
        /// <summary>
        /// 用药途径代码
        /// </summary>
        [DisplayName( "用药途径代码" )]
        [StringLength( 32 )]
        public string DoseWayCode { get; set; }
        /// <summary>
        /// 用药途径名称
        /// </summary>
        [DisplayName( "用药途径名称" )]
        [StringLength( 32 )]
        public string DoseWayName { get; set; }
        /// <summary>
        /// 药品单次使用剂量
        /// </summary>
        [DisplayName( "药品单次使用剂量" )]
        public int? DrugUseOneDosage { get; set; }
        /// <summary>
        /// 药品单次使用剂量单位
        /// </summary>
        [DisplayName( "药品单次使用剂量单位" )]
        [StringLength( 32 )]
        public string DrugUseOneDosageUnit { get; set; }
        /// <summary>
        /// 药品使用频次代码
        /// </summary>
        [DisplayName( "药品使用频次代码" )]
        [StringLength( 32 )]
        public string DrugUseFrequencyCode { get; set; }
        /// <summary>
        /// 药品使用频次名称
        /// </summary>
        [DisplayName( "药品使用频次名称" )]
        [StringLength( 32 )]
        public string DrugUseFrequencyName { get; set; }
        /// <summary>
        /// 药品剂型代码
        /// </summary>
        [DisplayName( "药品剂型代码" )]
        [StringLength( 32 )]
        public string DrugFormCode { get; set; }
        /// <summary>
        /// 药品剂型名称
        /// </summary>
        [DisplayName( "药品剂型名称" )]
        [StringLength( 32 )]
        public string DrugFormName { get; set; }
        /// <summary>
        /// 药品单位
        /// </summary>
        [DisplayName( "药品单位" )]
        [StringLength( 32 )]
        public string DrugUnit { get; set; }
        /// <summary>
        /// 药品单价
        /// </summary>
        [DisplayName( "药品单价" )]
        public decimal? DrugUnitPrice { get; set; }
        /// <summary>
        /// 药品简称
        /// </summary>
        [DisplayName( "药品简称" )]
        [StringLength( 32 )]
        public string DrugAbbreviation { get; set; }
        /// <summary>
        /// 药品描述
        /// </summary>
        [DisplayName( "药品描述" )]
        [StringLength( 255 )]
        public string DrugDescription { get; set; }
        /// <summary>
        /// 药品数量
        /// </summary>
        [DisplayName( "药品数量" )]
        public int? DrugAmount { get; set; }
        /// <summary>
        /// 医嘱持续时间
        /// </summary>
        [DisplayName( "医嘱持续时间" )]
        [StringLength( 32 )]
        public string OrderDuration { get; set; }
        /// <summary>
        /// 医嘱持续时间单位
        /// </summary>
        [DisplayName( "医嘱持续时间单位" )]
        [StringLength( 32 )]
        public string OrderDurationUnit { get; set; }
        /// <summary>
        /// 医嘱执行状态代码
        /// </summary>
        [DisplayName( "医嘱执行状态代码" )]
        [StringLength( 32 )]
        public string OrderExecuteStatusCode { get; set; }
        /// <summary>
        /// 医嘱执行状态名称
        /// </summary>
        [DisplayName( "医嘱执行状态名称" )]
        [StringLength( 32 )]
        public string OrderExecuteStatusName { get; set; }
        /// <summary>
        /// 医嘱开立医生
        /// </summary>
        [DisplayName( "医嘱开立医生" )]
        [StringLength( 32 )]
        public string OrderOpenDoctor { get; set; }
        /// <summary>
        /// 医嘱审核医生
        /// </summary>
        [DisplayName( "医嘱审核医生" )]
        [StringLength( 32 )]
        public string OrderProofDoctor { get; set; }
        /// <summary>
        /// 医嘱取消医生
        /// </summary>
        [DisplayName( "医嘱取消医生" )]
        [StringLength( 32 )]
        public string OrderCancelDoctor { get; set; }
        /// <summary>
        /// 医嘱执行医生
        /// </summary>
        [DisplayName( "医嘱执行医生" )]
        [StringLength( 32 )]
        public string OrderExecuteDoctor { get; set; }
        /// <summary>
        /// 医嘱停止医生
        /// </summary>
        [DisplayName( "医嘱停止医生" )]
        [StringLength( 32 )]
        public string OrderStopDoctor { get; set; }
        /// <summary>
        /// 开医嘱校对护士
        /// </summary>
        [DisplayName( "开医嘱校对护士" )]
        [StringLength( 32 )]
        public string OpenAuditNurse { get; set; }
        /// <summary>
        /// 停医嘱校对护士
        /// </summary>
        [DisplayName( "停医嘱校对护士" )]
        [StringLength( 32 )]
        public string StopAuditNurse { get; set; }
        /// <summary>
        /// 执行结果
        /// </summary>
        [DisplayName( "执行结果" )]
        [StringLength( 255 )]
        public string PerformResult { get; set; }
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
        
        
    }
}