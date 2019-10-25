using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;





namespace PD_HIDS_DataSync.Models {
    /// <summary>
    /// 
    /// </summary>
    [DisplayName( "" )]
    public partial class VW_OutPatientPDetail  {
        /// <summary>
        /// 初始化
        /// </summary>
        public VW_OutPatientPDetail()  {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">标识</param>
        public VW_OutPatientPDetail( int id )  {
        }
        /// <summary>
        /// 主键
        /// </summary>
        [DisplayName("主键")]
        [Required(ErrorMessage = "主键不能为空")]
        public int Id { get; set; }
        /// <summary>
        /// 明细号如：53199192
        /// </summary>
        [DisplayName( "明细号如：53199192" )]
        [StringLength( 32 )]
        public string DetailId { get; set; }
        /// <summary>
        /// 处方号(内码)如：22455978
        /// </summary>
        [DisplayName( "处方号(内码)如：22455978" )]
        [StringLength( 32 )]
        public string PrescriptionId { get; set; }
        /// <summary>
        /// 组别如：1
        /// </summary>
        [DisplayName( "组别如：1" )]
        [StringLength( 32 )]
        public string GroupId { get; set; }
        /// <summary>
        /// 项目名称如：复方嗜酸乳杆菌片
        /// </summary>
        [DisplayName( "项目名称如：复方嗜酸乳杆菌片" )]
        [StringLength( 32 )]
        public string ItemName { get; set; }
        /// <summary>
        /// 项目代码如：1234567
        /// </summary>
        [DisplayName( "项目代码如：1234567" )]
        [StringLength( 32 )]
        public string ItemCode { get; set; }
        /// <summary>
        /// 规格如：0.5g×18片
        /// </summary>
        [DisplayName( "规格如：0.5g×18片" )]
        [StringLength( 32 )]
        public string Specifications { get; set; }
        /// <summary>
        /// 总量如：2
        /// </summary>
        [DisplayName( "总量如：2" )]
        public int? Total { get; set; }
        /// <summary>
        /// 单位如：盒
        /// </summary>
        [DisplayName( "单位如：盒" )]
        [StringLength( 32 )]
        public string Uint { get; set; }
        /// <summary>
        /// 每次剂量如：1
        /// </summary>
        [DisplayName( "每次剂量如：1" )]
        public int? Dose { get; set; }
        /// <summary>
        /// 剂量单位如：g
        /// </summary>
        [DisplayName( "剂量单位如：g" )]
        [StringLength( 32 )]
        public string DoseUnit { get; set; }
        /// <summary>
        /// 次数如：3
        /// </summary>
        [DisplayName( "次数如：3" )]
        public int? Times { get; set; }
        /// <summary>
        /// 用法如：tid
        /// </summary>
        [DisplayName( "用法如：tid" )]
        [StringLength( 32 )]
        public string Useage { get; set; }
        /// <summary>
        /// 途径如：口服
        /// </summary>
        [DisplayName( "途径如：口服" )]
        [StringLength( 32 )]
        public string Route { get; set; }
        /// <summary>
        /// 天数如：3
        /// </summary>
        [DisplayName( "天数如：3" )]
        public int? Days { get; set; }
        /// <summary>
        /// 单价如：44.1
        /// </summary>
        [DisplayName( "单价如：44.1" )]
        public decimal? UnitPrice { get; set; }
        /// <summary>
        /// 金额如：88.2
        /// </summary>
        [DisplayName( "金额如：88.2" )]
        public decimal? Amount { get; set; }
        /// <summary>
        /// 药品产地如：通化金马集团
        /// </summary>
        [DisplayName( "药品产地如：通化金马集团" )]
        [StringLength( 32 )]
        public string Orgin { get; set; }
        /// <summary>
        /// 自付比例如：0.2
        /// </summary>
        [DisplayName( "自付比例如：0.2" )]
        public decimal? Pays { get; set; }
        /// <summary>
        /// 备注如：
        /// </summary>
        [DisplayName( "备注如：" )]
        [StringLength( 32 )]
        public string Comment { get; set; }
        /// <summary>
        /// 作废状态如：0-未作废，1-已作废
        /// </summary>
        [DisplayName( "作废状态如：0-未作废，1-已作废" )]
        public int? Canceled { get; set; }
        
    }
}