using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.Constants.PathConstant;
using CorePackagesGeneral.Aspects.Caching;
using CorePackagesGeneral.Aspects.Performance;
using CorePackagesGeneral.Aspects.Transaction;
using CorePackagesGeneral.Utilities.Business;
using CorePackagesGeneral.Utilities.Helpers.FileHelper.Abstract;
using CorePackagesGeneral.Utilities.Results.Abstract;
using CorePackagesGeneral.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager:ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        [SecuredOperation("Admin,Moderator")]
        [CacheRemoveAspect("ICarImageService.Get")]
        [PerformanceAspect(10)]
        [TransactionScopeAspect]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimit(carImage.CarId));
            if (result != null)
                return new ErrorResult(Messages.RentACarNotAvailable);
            
            carImage.ImagePath = _fileHelper.Upload(file, PathConstant.ImagesPath);
            carImage.CreatedDate = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        [SecuredOperation("Admin,Moderator")]
        [CacheRemoveAspect("ICarImageService.Get")]
        [PerformanceAspect(10)]
        [TransactionScopeAspect]
        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstant.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        [SecuredOperation("Admin,Moderator,NormalUser")]
        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        [SecuredOperation("Admin,Moderator,NormalUser")]
        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId));
        }

        [SecuredOperation("Admin,Moderator,NormalUser")]
        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<CarImage> GetImageByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId));
        }

        [SecuredOperation("Admin,Moderator")]
        [CacheRemoveAspect("ICarImageService.Get")]
        [PerformanceAspect(10)]
        [TransactionScopeAspect]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, PathConstant.ImagesPath + carImage.ImagePath, PathConstant.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckIfImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.Id == carId).Count;
            if (result >= 5)
                return new ErrorResult(Messages.CarImageLimitExceded);

            return new SuccessResult();
        }
        //for FE- If there is no photo of the car, let the default photo appear.
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>();
            carImages.Add(new CarImage { CarId = carId, CreatedDate = DateTime.Now, ImagePath = "IZACHRENTACAR.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImages);
        }

    }
}
