﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.Validation.FluentValidation;
using CorePackagesGeneral.Aspects.Autofac.Validation;
using CorePackagesGeneral.Utilities.Results.Abstract;
using CorePackagesGeneral.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class BrandManager : IBrandService
{
    IBrandDal _brandDal;

    public BrandManager(IBrandDal brandDal)
    {
        _brandDal = brandDal;
    }

    [ValidationAspect(typeof(BrandValidator))]
    [SecuredOperation("Admin,Moderator")]
    public IResult AddBrand(Brand brand)
    {
        _brandDal.Add(brand);
        return new SuccessResult(Messages.BrandAdded);
    }

    [SecuredOperation("Admin,Moderator")]
    public IResult DeleteBrand(Brand brand)
    {
        _brandDal.Delete(brand);
        return new SuccessResult(Messages.BrandDeleted);
    }

    [SecuredOperation("Admin,Moderator,NormalUser")]
    public IDataResult<List<Brand>> GetAll()
    {
        return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandListed);
    }

    [SecuredOperation("Admin,Moderator,NormalUser")]
    public IDataResult<List<Brand>> GetAllByBrandsId(int brandId)
    {
        return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(p => p.Id == brandId),Messages.BrandListed);
    }

    [ValidationAspect(typeof(BrandValidator))]
    [SecuredOperation("Admin,Moderator")]
    public IResult UpdateBrand(Brand brand)
    {
        _brandDal.Update(brand);
        return new SuccessResult(Messages.BrandUpdated);
    }
}