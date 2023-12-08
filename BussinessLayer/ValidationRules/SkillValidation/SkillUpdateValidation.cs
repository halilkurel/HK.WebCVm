using DtoLayer.SkillDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules.SkillValidation
{
    public class SkillUpdateValidation : AbstractValidator<SkillUpdateDto>
    {
        public SkillUpdateValidation()
        {
            RuleFor(x => x.SkillName)
                        .NotEmpty().WithMessage("Yetenek adı boş bırakılamaz")
                        .MaximumLength(100).WithMessage("Yetenek adı en fazla 100 karakter içermelidir");

            RuleFor(x => x.Degree)
                .NotNull().WithMessage("Derece alanı boş bırakılamaz")
                .InclusiveBetween(0, 100).WithMessage("Derece 0 ile 100 arasında olmalıdır"); // Örnek sınırlar, ihtiyaca göre değiştirilebilir




        }
    }
}
