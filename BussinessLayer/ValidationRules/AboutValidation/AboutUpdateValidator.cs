using DtoLayer.AboutDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules.AboutValidation
{
    public class AboutUpdateValidator : AbstractValidator<AboutUpdateDto>
    {
        public AboutUpdateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim alanı Boş Geçilemez")
                .MinimumLength(3).WithMessage("İsim alanı Minimum 3 karakterden oluşmalıdır")
                .MaximumLength(50).WithMessage("İsim alanı Maksimum 50 karakterden oluşmalıdır");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama alanı boş geçilemez")
                .MaximumLength(1500).WithMessage("Açıklama alanı maximum 1500 karakterden oluşabilir");

            RuleFor(x => x.Birthday)
                .Must(x => BeAValidBirthDate(x)).WithMessage("gün/ay/yıl şeklinde doğum tarihi giriniz");
            RuleFor(x => x.Degree)
            .MaximumLength(50).WithMessage("Derece alanı en fazla 50 karakter içermelidir");

            RuleFor(x => x.Experience)
                .MaximumLength(100).WithMessage("Deneyim alanı en fazla 100 karakter içermelidir");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon alanı boş bırakılamaz")
                .Matches(@"^[0-9]*$").WithMessage("Telefon alanı sadece sayı içermelidir");

            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage("Mail alanı boş bırakılamaz")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz");

            RuleFor(x => x.Address)
                .MaximumLength(150).WithMessage("Adres alanı en fazla 150 karakter içermelidir");

            RuleFor(x => x.Freelance)
                .MaximumLength(50).WithMessage("Freelance alanı en fazla 50 karakter içermelidir");

            RuleFor(x => x.Client)
                .MaximumLength(50).WithMessage("Müşteri alanı en fazla 50 karakter içermelidir");

            RuleFor(x => x.Prroject)
                .MaximumLength(50).WithMessage("Proje alanı en fazla 50 karakter içermelidir");
        }

        private bool BeAValidBirthDate(DateTime? date)
        {
            // Doğum tarihinin belirli bir tarihten önce olup olmadığını kontrol etmek için özel bir kural
            DateTime minimumBirthDate = new DateTime(1900, 1, 1); // Örnek: 1900-01-01

            return date.HasValue && date.Value >= minimumBirthDate;
        }
    }

}
