using DtoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.PortfolioDtos
{
    public class PortfolioCreateDto : IDto
    {
        public string? Image { get; set; }
        public string? Url { get; set; }
        public string? Name { get; set; }
        public string? Architectural { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
