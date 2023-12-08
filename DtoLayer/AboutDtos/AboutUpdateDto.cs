using DtoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.AboutDtos
{
    public class AboutUpdateDto : IDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Degree { get; set; }
        public string? Experience { get; set; }
        public string? Phone { get; set; }
        public string? Mail { get; set; }
        public string? Address { get; set; }
        public string? Freelance { get; set; }
        public string? Client { get; set; }
        public string? Prroject { get; set; }
    }
}
