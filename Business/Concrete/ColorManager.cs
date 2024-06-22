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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        [ValidationAspect(typeof(ColorValidator))]
        [SecuredOperation("Admin,Moderator")]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult AddColor(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        [SecuredOperation("Admin,Moderator")]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult DeleteColor(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        [SecuredOperation("Admin,Moderator,NormalUser")]
        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        [SecuredOperation("Admin,Moderator,NormalUser")]
        [CacheAspect]
        public IDataResult<List<Color>> GetAllByColorsId(int colorId)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(p=>p.Id==colorId));
        }

        [ValidationAspect(typeof(ColorValidator))]
        [SecuredOperation("Admin,Moderator")]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult UpdateColor(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
