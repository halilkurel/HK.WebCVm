using DtoLayer.FooterDtos;
using DtoLayer.HeaderDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules.HeaderValidation
{
    public class HeaderUpdateValidation : AbstractValidator<HeaderUpdateDto>
    {
        public HeaderUpdateValidation()
        {
            RuleFor(x => x.Image)
                        .MaximumLength(255).WithMessage("Resim alanı en fazla 255 karakter içermelidir");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim alanı boş bırakılamaz")
                .MaximumLength(100).WithMessage("İsim alanı en fazla 100 karakter içermelidir");

            RuleFor(x => x.Title1)
                .MaximumLength(100).WithMessage("Başlık 1 alanı en fazla 100 karakter içermelidir");

            RuleFor(x => x.Title2)
                .MaximumLength(100).WithMessage("Başlık 2 alanı en fazla 100 karakter içermelidir");

            RuleFor(x => x.Title3)
                .MaximumLength(100).WithMessage("Başlık 3 alanı en fazla 100 karakter içermelidir");

            RuleFor(x => x.Title4)
                .MaximumLength(100).WithMessage("Başlık 4 alanı en fazla 100 karakter içermelidir");

            RuleFor(x => x.Twitter)
                .MaximumLength(100).WithMessage("Twitter alanı en fazla 100 karakter içermelidir");

            RuleFor(x => x.Instagram)
                .MaximumLength(100).WithMessage("Instagram alanı en fazla 100 karakter içermelidir");

            RuleFor(x => x.Github)
                .MaximumLength(100).WithMessage("Github alanı en fazla 100 karakter içermelidir");

            RuleFor(x => x.Linkendln)
                .MaximumLength(100).WithMessage("LinkedIn alanı en fazla 100 karakter içermelidir");



        }
    }
}
