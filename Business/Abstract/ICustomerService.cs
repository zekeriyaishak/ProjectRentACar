﻿using CorePackagesGeneral.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IResult AddCustomer(Customer customer);
        IResult UpdateCustomer(Customer customer);
        IResult DeleteCustomer(Customer customer);
    }
}
