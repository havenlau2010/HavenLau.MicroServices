using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Dtos
{
    public class SubDto
    {
        public Guid? ID { get; set; }
        public string SubName { get; set; }

        public Guid MasterID { get; set; }

        public virtual MasterDto Master { get; set; }
    }
}
