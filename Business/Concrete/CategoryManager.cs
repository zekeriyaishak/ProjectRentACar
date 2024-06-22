using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [SecuredOperation("Admin,Moderator")]
        public IResult AddCategory(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        [SecuredOperation("Admin,Moderator")]
        public IResult DeleteCategory(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        [SecuredOperation("Admin,Moderator,NormalUser")]
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(),Messages.CategoryListed);
        }

        [SecuredOperation("Admin,Moderator,NormalUser")]
        public IDataResult<List<Category>> GetAllByCategoriesId(int categoryId)
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(x => x.Id == categoryId),Messages.CategoryGetWithId);
        }

        [SecuredOperation("Admin,Moderator")]
        public IResult UpdateCategory(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdate);
        }
    }
}
