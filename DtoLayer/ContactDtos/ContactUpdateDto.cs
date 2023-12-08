using DtoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.ContactDtos
{
    public class ContactUpdateDto : IDto
    {
        public int Id { get; set; }
        public string? Status { get; set; }
    }
}
