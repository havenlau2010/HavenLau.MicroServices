using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;





namespace PD_HIDS_DataSync.Models {
    /// <summary>
    /// 
    /// </summary>
    [DisplayName( "" )]
    public partial class VW_MedicineDictionary  {
        /// <summary>
        /// 初始化
        /// </summary>
        public VW_MedicineDictionary()  {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">标识</param>
        public VW_MedicineDictionary( int id )  {
        }
        /// <summary>
        /// 主键
        /// </summary>
        [DisplayName("主键")]
        [Required(ErrorMessage = "主键不能为空")]
        public int Id { get; set; }
        /// <summary>
        /// 药品信息药品唯一标识如：53199192
        /// </summary>
        [DisplayName( "药品信息药品唯一标识如：53199192" )]
        [StringLength( 32 )]
        public string MedicineNo { get; set; }
        /// <summary>
        /// 药品种类如：促红素
        /// </summary>
        [DisplayName( "药品种类如：促红素" )]
        [StringLength( 32 )]
        public string MedicineType { get; set; }
        /// <summary>
        /// 药品名称如：促红素
        /// </summary>
        [DisplayName( "药品名称如：促红素" )]
        [StringLength( 32 )]
        public string MedicineName { get; set; }
        /// <summary>
        /// 通用名如：EPO
        /// </summary>
        [DisplayName( "通用名如：EPO" )]
        [StringLength( 32 )]
        public string CommonName { get; set; }
        /// <summary>
        /// 规格型号如：艾贝尔血路管3
        /// </summary>
        [DisplayName( "规格型号如：艾贝尔血路管3" )]
        [StringLength( 32 )]
        public string MedicineModel { get; set; }
        /// <summary>
        /// 产地如：中国
        /// </summary>
        [DisplayName( "产地如：中国" )]
        [StringLength( 32 )]
        public string Orgin { get; set; }
        /// <summary>
        /// 换算率如：2
        /// </summary>
        [DisplayName( "换算率如：2" )]
        public decimal? UnitConversion { get; set; }
        /// <summary>
        /// 一级单位如：g
        /// </summary>
        [DisplayName( "一级单位如：g" )]
        [StringLength( 32 )]
        public string Unit1 { get; set; }
        /// <summary>
        /// 基本单位如：g
        /// </summary>
        [DisplayName( "基本单位如：g" )]
        [StringLength( 32 )]
        public string Unit { get; set; }
        /// <summary>
        /// 售价如：30
        /// </summary>
        [DisplayName( "售价如：30" )]
        public decimal? UnitSalesPrice { get; set; }
        
        
    }
}