using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Domains
{
    public class Skill : BaseEntity
    {
        public string? SkillName { get; set; }
        public int? Degree { get; set; }

    }
}
