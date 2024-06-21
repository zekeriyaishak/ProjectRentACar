using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation;
public class CreditCardValidator:AbstractValidator<CreditCard>
{
    public CreditCardValidator() { 
        RuleFor(x => x.CreditCardNumber).NotEmpty().NotNull().MaximumLength(16);
        RuleFor(x => x.SecurityCode).NotEmpty().NotNull().MaximumLength(3);
    }
}
