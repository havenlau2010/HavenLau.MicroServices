using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class Sub
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "SubName")]
        public string SubName { get; set; }

        public Guid? MasterID { get; set; }

        [ForeignKey("MasterID")]
        public virtual Master Master { get; set; }
    }
}
