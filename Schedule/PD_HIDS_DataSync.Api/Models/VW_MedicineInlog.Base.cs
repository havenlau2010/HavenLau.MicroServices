using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;





namespace PD_HIDS_DataSync.Models {
    /// <summary>
    /// 
    /// </summary>
    [DisplayName( "" )]
    public partial class VW_MedicineInlog  {
        /// <summary>
        /// 初始化
        /// </summary>
        public VW_MedicineInlog()  {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">标识</param>
        public VW_MedicineInlog( int id )  {
        }
        /// <summary>
        /// 主键
        /// </summary>
        [DisplayName("主键")]
        [Required(ErrorMessage = "主键不能为空")]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        [StringLength( 32 )]
        public string PatientName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        [StringLength( 32 )]
        public string IdentityNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        [StringLength( 32 )]
        public string InsuranceType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        [StringLength( 32 )]
        public string InsuranceNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        public DateTime? OperDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        [StringLength( 32 )]
        public string MedicineType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        [StringLength( 32 )]
        public string MedicineName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        [StringLength( 32 )]
        public string CommonName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        [StringLength( 32 )]
        public string Unit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        public decimal? UnitPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        public int? Quantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        public decimal? Amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        [StringLength( 32 )]
        public string DeptCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        [StringLength( 32 )]
        public string DeptName { get; set; }
        
        
    }
}