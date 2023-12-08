using DtoLayer.HeaderDtos;
using DtoLayer.PortfolioDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules.PortfolioValidation
{
    public class PortfolioCreateValidation : AbstractValidator<PortfolioCreateDto>
    {
        public PortfolioCreateValidation()
        {
            RuleFor(x => x.Image)
                        .MaximumLength(255).WithMessage("Resim alanı en fazla 255 karakter içermelidir");

            RuleFor(x => x.Url)
                .NotEmpty().WithMessage("URL alanı boş bırakılamaz")
                .MaximumLength(255).WithMessage("URL alanı en fazla 255 karakter içermelidir")
                .Matches(@"^(http|https)://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,}(?:[/\w\-\./?%&=]*)?$")
                .WithMessage("Geçerli bir URL formatı giriniz");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim alanı boş bırakılamaz")
                .MaximumLength(100).WithMessage("İsim alanı en fazla 100 karakter içermelidir");



        }
    }
}
