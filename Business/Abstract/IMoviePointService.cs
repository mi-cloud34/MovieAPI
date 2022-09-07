using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMoviePointService
    {
        IResult Add(MoviePoint moviePoint);
        IResult Delete(MoviePoint moviePoint);
        IResult Update(MoviePoint moviePoint);
        IDataResult<List<MoviePoint>> GetAll();
        IDataResult<MoviePoint> GetById(int id);
    }
}
