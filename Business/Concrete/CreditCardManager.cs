using Business.Abstract;
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
public class CreditCardManager: ICreditCardService
{
    ICreditCardDal _creditCardDal;

    public CreditCardManager(ICreditCardDal creditCardDal)
    {
        _creditCardDal = creditCardDal;
    }

    [ValidationAspect(typeof(CreditCardValidator))]
    public IResult Add(CreditCard card)
    {
        _creditCardDal.Add(card);
        return new SuccessResult(Messages.CreditCardAdded);
    }

    [ValidationAspect(typeof(CreditCardValidator))]
    public IResult Delete(CreditCard card)
    {
        _creditCardDal.Delete(card);
        return new SuccessResult(Messages.CreditCardDeleted);
    }

    public IDataResult<List<CreditCard>> GetAll()
    {
        var getAllCreditCard = _creditCardDal.GetAll();
        return new SuccessDataResult<List<CreditCard>>(getAllCreditCard,Messages.CreditCardListed);
    }

    public IDataResult<CreditCard> GetByCarId(int carId)
    {
        var getByAllCreditCard = _creditCardDal.Get(x=>x.CarId == carId);
        return new SuccessDataResult<CreditCard>(getByAllCreditCard,Messages.CreditCardListed);
    }

    [ValidationAspect(typeof(CreditCardValidator))]
    public IResult Update(CreditCard card)
    {
        _creditCardDal.Update(card);
        return new SuccessResult(Messages.CreditCardUpdate);
    }
}
