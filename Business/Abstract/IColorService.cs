using CorePackagesGeneral.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IResult AddColor(Color color);
        IResult UpdateColor(Color color);
        IResult DeleteColor(Color color);

        IDataResult<List<Color>> GetAllByColorsId(int colorId);
    }
}
