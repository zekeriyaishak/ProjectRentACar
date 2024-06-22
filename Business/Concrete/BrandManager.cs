using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.Validation.FluentValidation;
using CorePackagesGeneral.Aspects.Autofac.Validation;
using CorePackagesGeneral.Aspects.Caching;
using CorePackagesGeneral.Aspects.Performance;
using CorePackagesGeneral.Aspects.Transaction;
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
    [CacheRemoveAspect("IBrandService.Get")]
    [PerformanceAspect(5)]
    public IResult AddBrand(Brand brand)
    {
        _brandDal.Add(brand);
        return new SuccessResult(Messages.BrandAdded);
    }
    //Burası Transaction için test metodu.
    [TransactionScopeAspect]
    public IResult AddTransactionalBrand(Brand brand)
    {
        _brandDal.Add(brand);
        if (brand.BrandName.Length > 3)
        {
            throw new Exception(" 3 ten büyük!");
        }
        _brandDal.Add(brand);
        return new SuccessResult(Messages.BrandAdded);
    }

    [SecuredOperation("Admin,Moderator")]
    [CacheRemoveAspect("IBrandService.Get")]
    public IResult DeleteBrand(Brand brand)
    {
        _brandDal.Delete(brand);
        return new SuccessResult(Messages.BrandDeleted);
    }

    [SecuredOperation("Admin,Moderator,NormalUser")]
    [CacheAspect]
    [PerformanceAspect(5)]
    public IDataResult<List<Brand>> GetAll()
    {
        return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandListed);
    }

    [SecuredOperation("Admin,Moderator,NormalUser")]
    [CacheAspect]
    public IDataResult<List<Brand>> GetAllByBrandsId(int brandId)
    {
        return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(p => p.Id == brandId),Messages.BrandListed);
    }

    [ValidationAspect(typeof(BrandValidator))]
    [SecuredOperation("Admin,Moderator")]
    [CacheRemoveAspect("IBrandService.Get")]
    public IResult UpdateBrand(Brand brand)
    {
        _brandDal.Update(brand);
        return new SuccessResult(Messages.BrandUpdated);
    }
}