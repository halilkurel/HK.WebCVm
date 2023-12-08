using DtoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.SubscribeDtos
{
    public class SubscribeCreateDto : IDto
    {
        public string? Mail { get; set; }
    }
}
