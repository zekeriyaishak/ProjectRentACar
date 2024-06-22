using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
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
public class PaymentManager:IPaymentService
{
    IPaymentDal _paymentDal;

    public PaymentManager(IPaymentDal paymentDal)
    {
        _paymentDal = paymentDal;
    }
    [SecuredOperation("Admin,Moderator,NormalUser")]
    [PerformanceAspect(15)]
    [TransactionScopeAspect]
    public IResult Add(Payment payment)
    {
        _paymentDal.Add(payment);
        return new SuccessResult(Messages.PaymentAdded);
    }
    [SecuredOperation("Admin,Moderator,NormalUser")]
    [PerformanceAspect(15)]
    [TransactionScopeAspect]
    public IResult Delete(Payment payment)
    {
        _paymentDal.Delete(payment);
        return new SuccessResult(Messages.PaymentDeleted);
    }

    [SecuredOperation("Admin,Moderator,NormalUser")]
    [PerformanceAspect(15)]
    public IDataResult<List<Payment>> GetAll()
    {
        var getAll = _paymentDal.GetAll();
        return new SuccessDataResult<List<Payment>>(getAll,Messages.PaymentListed);
    }
    [SecuredOperation("Admin,Moderator,NormalUser")]
    [PerformanceAspect(15)]
    public IDataResult<Payment> GetByPaymentId(int paymentId)
    {
        var getPaymentId = _paymentDal.Get(x => x.Id == paymentId);
        return new SuccessDataResult<Payment>(getPaymentId,Messages.PaymentListed);
    }
    [SecuredOperation("Admin,Moderator,NormalUser")]
    [PerformanceAspect(15)]
    [TransactionScopeAspect]
    public IResult Update(Payment payment)
    {
        _paymentDal.Update(payment);
        return new SuccessResult(Messages.PaymentUpdate);
    }
}
