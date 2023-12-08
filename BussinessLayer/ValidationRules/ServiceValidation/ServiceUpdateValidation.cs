using DtoLayer.ServicesDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules.ServiceValidation
{
    public class ServiceUpdateValidation : AbstractValidator<ServiceUpdateDto>
    {
        public ServiceUpdateValidation()
        {
            RuleFor(x => x.Name)
                        .NotEmpty().WithMessage("İsim alanı boş bırakılamaz")
                        .MaximumLength(100).WithMessage("İsim alanı en fazla 100 karakter içermelidir");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama alanı boş bırakılamaz")
                .MaximumLength(500).WithMessage("Açıklama alanı en fazla 500 karakter içermelidir");

            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("İkon alanı boş bırakılamaz")
                .MaximumLength(50).WithMessage("İkon alanı en fazla 50 karakter içermelidir");


        }
    }
}
