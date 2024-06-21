using CorePackagesGeneral.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null)
        {
            using(RentCarContext rentCarContext = new RentCarContext())
            {
                var result = from c in rentCarContext.Cars
                             join b in rentCarContext.Brands
                             on c.BrandId equals b.Id
                             join co in rentCarContext.Colors
                             on c.ColorId equals co.Id

                             select new CarDetailsDto
                             {
                                 CarId = c.Id,
                                 ColorId = co.Id,
                                 BrandId = b.Id,
                                 BrandName = b.BrandName,
                                 CarName = c.CarName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 CarImages = (from ci in rentCarContext.CarImages where ci.CarId == c.Id select ci).ToList(),
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
