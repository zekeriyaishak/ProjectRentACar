﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class BrandValidator:AbstractValidator<Brand>
    {
        public BrandValidator() { 
            RuleFor(b => b.BrandName).NotEmpty().NotNull().MinimumLength(1);
        }
    }
}
