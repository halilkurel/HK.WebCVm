using DtoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.SkillDtos
{
    public class SkillListDto : IDto
    {
        public int Id { get; set; }
        public string? SkillName { get; set; }
        public int? Degree { get; set; }
    }
}
