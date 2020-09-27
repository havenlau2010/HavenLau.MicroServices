using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Dtos
{
    public class MasterDto
    {
        public Guid? ID { get; set; }
        public string MasterName { get; set; }
        public virtual IList<SubDto> Subs { get; set; }
    }
}
