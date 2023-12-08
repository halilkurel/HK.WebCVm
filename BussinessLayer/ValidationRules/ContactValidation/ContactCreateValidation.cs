using DtoLayer.AboutDtos;
using DtoLayer.ContactDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules.ContactValidation
{
    public class ContactCreateValidation : AbstractValidator<ContactCreateDto>
    {
        public ContactCreateValidation()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("İsim alanı boş bırakılamaz")
            .MaximumLength(50).WithMessage("İsim alanı en fazla 50 karakter içermelidir");

            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage("E-posta alanı boş bırakılamaz")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz")
                .MaximumLength(100).WithMessage("E-posta alanı en fazla 100 karakter içermelidir");

            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Konu alanı boş bırakılamaz")
                .MaximumLength(100).WithMessage("Konu alanı en fazla 100 karakter içermelidir");

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Mesaj alanı boş bırakılamaz")
                .MaximumLength(1000).WithMessage("Mesaj alanı en fazla 1000 karakter içermelidir");

        }
    }
}
