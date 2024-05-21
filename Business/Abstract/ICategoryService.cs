using CorePackagesGeneral.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IResult AddCategory(Category category);
        IResult UpdateCategory(Category category);
        IResult DeleteCategory(Category category);
        IDataResult<List<Category>> GetAllByCategoriesId(int categoryId);
    }
}
