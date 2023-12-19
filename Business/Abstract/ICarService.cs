using CorePackagesGeneral.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IResult AddCar(Car car);
        IResult UpdateCar(Car car);
        IResult DeleteCar(Car car);
        IDataResult<List<Car>> GetAllByCarsId(int carId);
        IDataResult<List<CarDetailsDTOs>> GetCarDetails();
        IDataResult<List<CarDetailsDTOs>> GetCarDetailsByCarId(int carId);
        IDataResult<List<CarDetailsDTOs>> GetCarDetailsByColorsAndBrand(int brandId, int colorId);
    }
}
