using DtoLayer.ServicesDtos;
using DtoLayer.SubscribeDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules.SubscribeValidation
{
    public class SubscribeCreateValidation : AbstractValidator<SubscribeCreateDto>
    {
        public SubscribeCreateValidation()
        {
            RuleFor(x => x.Mail)
                        .NotEmpty().WithMessage("E-posta alanı boş bırakılamaz")
                        .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz")
                        .MaximumLength(100).WithMessage("E-posta alanı en fazla 100 karakter içermelidir");




        }
    }
}
