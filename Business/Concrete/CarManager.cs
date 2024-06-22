using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.Validation.FluentValidation;
using CorePackagesGeneral.Aspects.Autofac.Validation;
using CorePackagesGeneral.Aspects.Caching;
using CorePackagesGeneral.Utilities.Results.Abstract;
using CorePackagesGeneral.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        [CacheRemoveAspect("ICarService.Get")]
        public IResult AddCar(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [SecuredOperation("Admin,Moderator")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult DeleteCar(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [SecuredOperation("Admin,Moderator,NormalUser")]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            var cars = _carDal.GetAll();
            return new SuccessDataResult<List<Car>>(cars, Messages.CarListed);
        }

        [SecuredOperation("Admin,Moderator,NormalUser")]
        [CacheAspect]
        public IDataResult<List<Car>> GetAllByCarsId(int carId)
        {
            var car = _carDal.GetAll(x => x.Id == carId);
            return new SuccessDataResult<List<Car>>(car, Messages.CarListed);
        }

        [SecuredOperation("Admin,Moderator,NormalUser")]
        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetCarDetailByCarId(int carId)
        {
            var carDetailsByCarId = _carDal.GetCarDetails(x => x.CarId == carId);
            return new SuccessDataResult<List<CarDetailsDto>>(carDetailsByCarId, Messages.CarDetailsSuccessMessage);
        }

        [SecuredOperation("Admin,Moderator,NormalUser")]
        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            var carDetails = _carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDetailsDto>>(carDetails, Messages.CarDetailsSuccessMessage);
        }

        [SecuredOperation("Admin,Moderator,NormalUser")]
        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetCarDetailsByColorAndByBrand(int colorId, int brandId)
        {
            var carDetailsByColorAndBrandId = _carDal.GetCarDetails(x => x.BrandId == brandId && x.ColorId == colorId);
            return new SuccessDataResult<List<CarDetailsDto>>(carDetailsByColorAndBrandId, Messages.CarDetailsSuccessMessage);
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("Admin,Moderator")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult UpdateCar(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
