using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Domains
{
    public class Header : BaseEntity
    {
        public string? Image { get; set; }
        public string? Name { get; set; }
        public string? Title1 { get; set; }
        public string? Title2 { get; set; }
        public string? Title3 { get; set; }
        public string? Title4 { get; set; }
        public string? Twitter { get; set; }
        public string? Instagram { get; set; }
        public string? Github { get; set; }
        public string? Linkendln { get; set; }
    }
}
