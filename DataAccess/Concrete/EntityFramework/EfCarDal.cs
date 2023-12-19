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
        public List<CarDetailsDTOs> GetCarDetails(Expression<Func<CarDetailsDTOs, bool>> filter = null)
        {
            using(RentCarContext rentCarContext = new RentCarContext())
            {
                var result = from c in rentCarContext.Cars
                             join b in rentCarContext.Brands
                             on c.BrandId equals b.Id
                             join k in rentCarContext.Colors
                             on c.ColorId equals k.Id

                             select new CarDetailsDTOs
                             {
                                 BrandId = b.Id,
                                 ColorId = k.Id,
                                 CarId = c.Id,
                                 BrandName = b.BrandName,
                                 CarName = c.CarName,
                                 ColorName = k.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                             };
                return filter == null ? result.ToList(): result.Where(filter).ToList();
            }
        }
    }
}
