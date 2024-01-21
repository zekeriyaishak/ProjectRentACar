using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator() { 
            RuleFor(c => c.CarName).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(c => c.BrandId).NotEmpty().NotNull();
            RuleFor(c => c.ColorId).NotEmpty().NotNull();
            RuleFor(c => c.ModelYear).NotEmpty().NotNull();
            RuleFor(c => c.DailyPrice).NotEmpty().NotNull();
            RuleFor(c => c.Description).NotEmpty().NotNull().MinimumLength(5);
        }
    }
}
