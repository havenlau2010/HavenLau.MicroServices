using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBase.Data
{
    public class MenuItem
    {
        public string MenuHref { get; set; }

        public string MenuIcon { get; set; }

        public string MatchTagret { get; set; }

        public string MenuText { get; set; }

        public int OrderNumber{ get; set; }
    }
}
