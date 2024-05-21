using CorePackagesGeneral.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface INewsService
    {
        IDataResult<List<News>> GetAll();
        IResult AddNews(News news);
        IResult UpdateNews(News news);
        IResult DeleteNews(News news);
        IDataResult<List<News>> GetAllByNewsId(int newsId);
    }
}
