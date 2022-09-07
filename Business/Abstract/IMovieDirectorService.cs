using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMovieDirectorService
    {
        IResult Add(MovieDirector movieDirector);
        IResult Delete(MovieDirector movieDirector);
        IResult Update(MovieDirector movieDirector);
        IDataResult<List<MovieDirector>> GetAll();
        IDataResult<MovieDirector> GetById(int id);
    }
}
