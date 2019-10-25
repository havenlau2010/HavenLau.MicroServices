using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;





namespace PD_HIDS_DataSync.Models {
    /// <summary>
    /// 
    /// </summary>
    [DisplayName( "" )]
    public partial class VW_UnDrugDetail  {
        /// <summary>
        /// 初始化
        /// </summary>
        public VW_UnDrugDetail()  {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">标识</param>
        public VW_UnDrugDetail( int id )  {
        }
        /// <summary>
        /// 主键
        /// </summary>
        [DisplayName("主键")]
        [Required(ErrorMessage = "主键不能为空")]
        public int Id { get; set; }
        /// <summary>
        /// 处方号处方号
        /// </summary>
        [DisplayName( "处方号处方号" )]
        [StringLength( 32 )]
        public string UniqueNo { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        [DisplayName( "患者姓名" )]
        [StringLength( 32 )]
        public string PatientName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        [DisplayName( "身份证号" )]
        [StringLength( 32 )]
        public string IdentityNo { get; set; }
        /// <summary>
        /// 医保类型
        /// </summary>
        [DisplayName( "医保类型" )]
        [StringLength( 32 )]
        public string InsuranceType { get; set; }
        /// <summary>
        /// 医保卡号
        /// </summary>
        [DisplayName( "医保卡号" )]
        [StringLength( 32 )]
        public string InsuranceNo { get; set; }
        /// <summary>
        /// 收费日期
        /// </summary>
        [DisplayName( "收费日期" )]
        public DateTime? OperDate { get; set; }
        /// <summary>
        /// 项目代码
        /// </summary>
        [DisplayName( "项目代码" )]
        [StringLength( 32 )]
        public string UndrugCode { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [DisplayName( "项目名称" )]
        [StringLength( 32 )]
        public string UndrugName { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [DisplayName( "单价" )]
        public decimal? UnitPrice { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [DisplayName( "数量" )]
        public int? Quantity { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [DisplayName( "金额" )]
        public decimal? OwnCost { get; set; }
        /// <summary>
        /// 基本单位
        /// </summary>
        [DisplayName( "基本单位" )]
        [StringLength( 32 )]
        public string Unit { get; set; }
        /// <summary>
        /// 执行科室代码
        /// </summary>
        [DisplayName( "执行科室代码" )]
        [StringLength( 32 )]
        public string DeptCode { get; set; }
        /// <summary>
        /// 执行科室名称
        /// </summary>
        [DisplayName( "执行科室名称" )]
        [StringLength( 32 )]
        public string DeptName { get; set; }
        
    }
}