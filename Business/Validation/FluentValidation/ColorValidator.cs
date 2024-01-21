using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class ColorValidator:AbstractValidator<Color>
    {
        public ColorValidator() { 
            RuleFor(b => b.ColorName).NotEmpty().NotNull().MinimumLength(1);
        }
    }
}
