using DtoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.SubscribeDtos
{
    public class SubscribeListDto : IDto
    {
        public int Id { get; set; }
        public string? Mail { get; set; }
    }
}
