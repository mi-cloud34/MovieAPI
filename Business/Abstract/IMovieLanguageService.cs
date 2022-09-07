using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMovieLanguageService
    {
        IResult Add(MovieLanguage movieLanguage);
        IResult Delete(MovieLanguage movieLanguage);
        IResult Update(MovieLanguage movieLanguage);
        IDataResult<List<MovieLanguage>> GetAll();
        IDataResult<MovieLanguage> GetById(int id);
    }
}
