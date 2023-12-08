using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Domains
{
    public class Footer : BaseEntity
    {
        public string? Twitter { get; set; }
        public string? Instagram { get; set; }
        public string? Github { get; set; }
        public string? LinkendIn { get; set; }

    }
}
