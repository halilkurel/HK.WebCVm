using DtoLayer.EducationDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules.EducationValidation
{
    public class EducationCreateValidation : AbstractValidator<EducationCreateDto>
    {
        public EducationCreateValidation()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("İsim alanı boş bırakılamaz")
            .MaximumLength(50).WithMessage("İsim alanı en fazla 50 karakter içermelidir");

            RuleFor(x => x.Major)
            .NotEmpty().WithMessage("İsim alanı boş bırakılamaz")
            .MaximumLength(50).WithMessage("İsim alanı en fazla 50 karakter içermelidir");

            RuleFor(x => x.StartingDate)
                .NotNull().WithMessage("Başlangıç tarihi boş bırakılamaz");


            RuleFor(x => x.EndDate)
                .NotNull().WithMessage("Bitiş tarihi boş bırakılamaz")
                .GreaterThan(x => x.StartingDate).WithMessage("Bitiş tarihi, başlangıç tarihinden sonra olmalıdır");

        }
    }
}
