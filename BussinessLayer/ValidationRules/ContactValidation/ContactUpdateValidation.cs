using DtoLayer.ContactDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules.ContactValidation
{
    public class ContactUpdateValidation : AbstractValidator<ContactUpdateDto>
    {
        public ContactUpdateValidation()
        {

        }
    }
}
