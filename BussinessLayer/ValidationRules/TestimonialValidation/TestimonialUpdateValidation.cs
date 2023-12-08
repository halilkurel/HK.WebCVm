using DtoLayer.TestimonialDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules.TestimonialValidation
{
    public class TestimonialUpdateValidation : AbstractValidator<TestimonialUpdateDto>
    {
        public TestimonialUpdateValidation()
        {
            RuleFor(x => x.Name)
                        .NotEmpty().WithMessage("İsim alanı boş bırakılamaz")
                        .MaximumLength(100).WithMessage("İsim alanı en fazla 100 karakter içermelidir");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık alanı boş bırakılamaz")
                .MaximumLength(100).WithMessage("Başlık alanı en fazla 100 karakter içermelidir");

            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Yorum alanı boş bırakılamaz")
                .MaximumLength(500).WithMessage("Yorum alanı en fazla 500 karakter içermelidir");

            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("Resim alanı boş bırakılamaz")
                .MaximumLength(255).WithMessage("Resim alanı en fazla 255 karakter içermelidir");
        }




    }
    
}
