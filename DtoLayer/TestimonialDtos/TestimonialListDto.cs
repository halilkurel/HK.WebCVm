﻿using DtoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.TestimonialDtos
{
    public class TestimonialListDto :IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Comment { get; set; }
        public string? Image { get; set; }
    }
}
