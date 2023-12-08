using DtoLayer.ContactDtos;
using DtoLayer.FooterDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules.FooterValidation
{
    public class FooterUpdateValidation : AbstractValidator<FooterUpdateDto>
    {
        public FooterUpdateValidation()
        {
            RuleFor(x => x.Twitter)
            .MaximumLength(100).WithMessage("Twitter alanı en fazla 100 karakter içermelidir");

            RuleFor(x => x.Instagram)
                .MaximumLength(100).WithMessage("Instagram alanı en fazla 100 karakter içermelidir");

            RuleFor(x => x.Github)
                .MaximumLength(100).WithMessage("Github alanı en fazla 100 karakter içermelidir");

            RuleFor(x => x.LinkendIn)
                .MaximumLength(100).WithMessage("LinkedIn alanı en fazla 100 karakter içermelidir");




        }
    }
}
