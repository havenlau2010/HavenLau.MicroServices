using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;





namespace PD_HIDS_DataSync.Models {
    /// <summary>
    /// 
    /// </summary>
    [DisplayName( "" )]
    public partial class VW_Material  {
        /// <summary>
        /// 初始化
        /// </summary>
        public VW_Material() {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">标识</param>
        public VW_Material( int id )  {
        }
        /// <summary>
        /// 主键
        /// </summary>
        [DisplayName("主键")]
        [Required(ErrorMessage = "主键不能为空")]
        public int Id { get; set; }

        /// <summary>
        /// 耗材编号耗材唯一标识如：53199192
        /// </summary>
        [DisplayName( "耗材编号耗材唯一标识如：53199192" )]
        [StringLength( 32 )]
        public string MaterialNo { get; set; }
        /// <summary>
        /// 耗材项目登记日期格式：YYYY-MM-DD
        /// </summary>
        [DisplayName( "耗材项目登记日期格式：YYYY-MM-DD" )]
        public DateTime? LogDate { get; set; }
        /// <summary>
        /// 耗材类别如：血路管
        /// </summary>
        [DisplayName( "耗材类别如：血路管" )]
        [StringLength( 32 )]
        public string MaterialType { get; set; }
        /// <summary>
        /// 耗材名称如：血路
        /// </summary>
        [DisplayName( "耗材名称如：血路" )]
        [StringLength( 32 )]
        public string MaterialName { get; set; }
        /// <summary>
        /// 规格型号如：艾贝尔血路管3
        /// </summary>
        [DisplayName( "规格型号如：艾贝尔血路管3" )]
        [StringLength( 32 )]
        public string MaterialModel { get; set; }
        /// <summary>
        /// 生产厂家如：艾贝尔
        /// </summary>
        [DisplayName( "生产厂家如：艾贝尔" )]
        [StringLength( 32 )]
        public string Manufacturer { get; set; }
        /// <summary>
        /// 耗材换算率如：2
        /// </summary>
        [DisplayName( "耗材换算率如：2" )]
        public decimal? UnitConversion { get; set; }
        /// <summary>
        /// 一级单位如：盒
        /// </summary>
        [DisplayName( "一级单位如：盒" )]
        [StringLength( 32 )]
        public string Unit1 { get; set; }
        /// <summary>
        /// 基本单位如：支
        /// </summary>
        [DisplayName( "基本单位如：支" )]
        [StringLength( 32 )]
        public string Unit { get; set; }
        /// <summary>
        /// 售价如：30
        /// </summary>
        [DisplayName( "售价如：30" )]
        public decimal? UnitSalesPrice { get; set; }
        
    }
}