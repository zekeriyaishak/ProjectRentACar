using Business.Abstract;
using Business.Constants.Messages;
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

        public IResult AddCar(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult DeleteCar(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            var cars = _carDal.GetAll();
            return new SuccessDataResult<List<Car>>(cars, Messages.CarListed);
        }

        public IDataResult<List<Car>> GetAllByCarsId(int carId)
        {
            var car = _carDal.GetAll(x => x.Id == carId);
            return new SuccessDataResult<List<Car>>(car, Messages.CarListed);
        }

        public IDataResult<List<CarDetailsDTOs>> GetCarDetails()
        {
            var carDetails = _carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDetailsDTOs>>(carDetails, Messages.CarListed);
        }

        public IDataResult<List<CarDetailsDTOs>> GetCarDetailsByCarId(int carId)
        {
            var car = _carDal.GetCarDetails(x=>x.CarId == carId);
            return new SuccessDataResult<List<CarDetailsDTOs>>(car, Messages.CarListed);
        }

        public IDataResult<List<CarDetailsDTOs>> GetCarDetailsByColorsAndBrand(int brandId, int colorId)
        {
            var car = _carDal.GetCarDetails(x => x.BrandId == brandId && x.ColorId == colorId);
            return new SuccessDataResult<List<CarDetailsDTOs>>(car, Messages.CarListed);
        }

        public IResult UpdateCar(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

    }
}
