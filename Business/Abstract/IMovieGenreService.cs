using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMovieGenreService
    {
        IResult Add(MovieGenre movieGenre);
        IResult Delete(MovieGenre movieGenre );
        IResult Update(MovieGenre movieGenre);
        IDataResult<List<MovieGenre>> GetAll();
        IDataResult<MovieGenre> GetById(int id);
    }
}
