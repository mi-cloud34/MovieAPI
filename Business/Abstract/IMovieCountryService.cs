using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMovieCountryService
    {
        IResult Add(MovieCountry movieCountry);
        IResult Delete(MovieCountry movieCountry);
        IResult Update(MovieCountry movieCountry);
        IDataResult<List<MovieCountry>> GetAll();
        IDataResult<MovieCountry> GetById(int id);
    }
}
