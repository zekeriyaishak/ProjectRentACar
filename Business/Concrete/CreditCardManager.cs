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
public class CreditCardManager: ICreditCardService
{
    ICreditCardDal _creditCardDal;

    public CreditCardManager(ICreditCardDal creditCardDal)
    {
        _creditCardDal = creditCardDal;
    }

    [ValidationAspect(typeof(CreditCardValidator))]
    [SecuredOperation("Admin,Moderator")]
    [CacheRemoveAspect("ICreditCardService.Get")]
    [PerformanceAspect(6)]
    [TransactionScopeAspect]
    public IResult Add(CreditCard card)
    {
        _creditCardDal.Add(card);
        return new SuccessResult(Messages.CreditCardAdded);
    }

    [ValidationAspect(typeof(CreditCardValidator))]
    [SecuredOperation("Admin,Moderator")]
    [CacheRemoveAspect("ICreditCardService.Get")]
    [PerformanceAspect(6)]
    [TransactionScopeAspect]
    public IResult Delete(CreditCard card)
    {
        _creditCardDal.Delete(card);
        return new SuccessResult(Messages.CreditCardDeleted);
    }

    [SecuredOperation("Admin,Moderator,NormalUser")]
    [CacheAspect]
    public IDataResult<List<CreditCard>> GetAll()
    {
        var getAllCreditCard = _creditCardDal.GetAll();
        return new SuccessDataResult<List<CreditCard>>(getAllCreditCard,Messages.CreditCardListed);
    }

    [SecuredOperation("Admin,Moderator,NormalUser")]
    [CacheAspect]
    public IDataResult<CreditCard> GetByCarId(int carId)
    {
        var getByAllCreditCard = _creditCardDal.Get(x=>x.CarId == carId);
        return new SuccessDataResult<CreditCard>(getByAllCreditCard,Messages.CreditCardListed);
    }

    [ValidationAspect(typeof(CreditCardValidator))]
    [SecuredOperation("Admin,Moderator")]
    [CacheRemoveAspect("ICreditCardService.Get")]
    [PerformanceAspect(6)]
    [TransactionScopeAspect]
    public IResult Update(CreditCard card)
    {
        _creditCardDal.Update(card);
        return new SuccessResult(Messages.CreditCardUpdate);
    }
}
