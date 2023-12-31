using CorePackagesGeneral.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework;

public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
{
    public List<RentalDetailsDto> GetRentalDetails()
    {
        using (RentCarContext rentCarContext = new RentCarContext())
        {
            var result = from ca in rentCarContext.Cars
                         join b in rentCarContext.Brands
                         on ca.BrandId equals b.Id
                         join re in rentCarContext.Rentals
                         on ca.Id equals re.Id
                         join co in rentCarContext.Colors
                         on ca.ColorId equals co.Id
                         from u in rentCarContext.Users
                         join cu in rentCarContext.Customers
                         on u.Id equals cu.UserId
                         select new RentalDetailsDto
                         {
                             Id = ca.Id,
                             ColorName = co.ColorName,
                             BrandName = b.BrandName,
                             ModelName = ca.Description,
                             RentDate = re.RentDate,
                             ReturnDate = re.ReturnDate,
                             UserName = u.FirstName,
                             UserLastname = u.LastName,
                             CreatedDate = re.CreatedDate

                         };
            return result.ToList();
        }

    }
}
