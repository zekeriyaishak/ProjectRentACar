﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using CorePackagesGeneral.Aspects.Caching;
using CorePackagesGeneral.Utilities.Results.Abstract;
using CorePackagesGeneral.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class NewsManager : INewsService
    {
        INewsDal _newsDal;

        public NewsManager(INewsDal newsDal)
        {
            _newsDal = newsDal;
        }

        [SecuredOperation("Admin,Moderator")]
        [CacheRemoveAspect("INewsService.Get")]
        public IResult AddNews(News news)
        {
            _newsDal.Add(news);
            return new SuccessResult(Messages.NewsAdded);
        }

        [SecuredOperation("Admin,Moderator")]
        [CacheRemoveAspect("INewsService.Get")]
        public IResult DeleteNews(News news)
        {
            _newsDal.Delete(news);
            return new SuccessResult(Messages.NewsDeleted);
        }

        [SecuredOperation("Admin,Moderator,NormalUser")]
        [CacheAspect]
        public IDataResult<List<News>> GetAll()
        {
            return new SuccessDataResult<List<News>>(_newsDal.GetAll(),Messages.NewsListed);
        }

        [SecuredOperation("Admin,Moderator,NormalUser")]
        [CacheAspect]
        public IDataResult<List<News>> GetAllByNewsId(int newsId)
        {
            return new SuccessDataResult<List<News>>(_newsDal.GetAll(p => p.Id == newsId));
        }

        [SecuredOperation("Admin,Moderator")]
        [CacheRemoveAspect("INewsService.Get")]
        public IResult UpdateNews(News news)
        {
            _newsDal.Update(news);
            return new SuccessResult(Messages.NewsUpdate);
        }
    }
}
