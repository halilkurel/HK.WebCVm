using DtoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.FooterDtos
{
    public class FooterListDto : IDto
    {
        public int Id { get; set; }
        public string? Twitter { get; set; }
        public string? Instagram { get; set; }
        public string? Github { get; set; }
        public string? LinkendIn { get; set; }
        public string? AdminUrl { get; set; }
    }
}
