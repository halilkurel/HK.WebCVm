using DtoLayer.TestimonialDtos;
using DtoLayer.ToDoListDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules.ToDoListValidation
{
    public class ToDoListUpdateValidation : AbstractValidator<UpdateToDoListDto>
    {
        public ToDoListUpdateValidation()
        {
            
        }
    }
}
