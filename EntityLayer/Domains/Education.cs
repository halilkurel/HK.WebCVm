using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Domains
{
    public class Education : BaseEntity
    {
        public string? Name { get; set; }
        public string? Major { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
