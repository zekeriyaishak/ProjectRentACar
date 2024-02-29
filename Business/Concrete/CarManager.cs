using Business.Abstract;
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

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("Admin,Moderator")]
        public IResult AddCar(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [SecuredOperation("Admin,Moderator")]
        public IResult DeleteCar(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [SecuredOperation("Admin,Moderator,NormalUser")]
        public IDataResult<List<Car>> GetAll()
        {
            var cars = _carDal.GetAll();
            return new SuccessDataResult<List<Car>>(cars, Messages.CarListed);
        }

        [SecuredOperation("Admin,Moderator,NormalUser")]
        public IDataResult<List<Car>> GetAllByCarsId(int carId)
        {
            var car = _carDal.GetAll(x => x.Id == carId);
            return new SuccessDataResult<List<Car>>(car, Messages.CarListed);
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("Admin,Moderator")]
        public IResult UpdateCar(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
