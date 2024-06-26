﻿using CorePackagesGeneral.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IBrandService
{
    IDataResult<List<Brand>> GetAll();
    IResult AddBrand(Brand brand);
    IResult UpdateBrand(Brand brand);
    IResult DeleteBrand(Brand brand);

    IDataResult<List<Brand>> GetAllByBrandsId(int brandId);
    IResult AddTransactionalBrand(Brand brand);
}
