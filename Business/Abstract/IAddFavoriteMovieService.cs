using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAddFavoriteMovieService
    {
        IResult Add(AddFavoriteMovie addFavoriteMovie);
        IResult Delete(AddFavoriteMovie addFavoriteMovie);
        IResult Update(AddFavoriteMovie addFavoriteMovie);
        IDataResult<List<AddFavoriteMovie>> GetAll();
        IDataResult<AddFavoriteMovie> GetById(int id);
    }
}
