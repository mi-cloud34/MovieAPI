using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMovieTranslateLanguageService
    {
        IResult Add(MovieTranslateLanguage movieTranslateLanguage);
        IResult Delete(MovieTranslateLanguage movieTranslateLanguage);
        IResult Update(MovieTranslateLanguage movieTranslateLanguage);
        IDataResult<List<MovieTranslateLanguage>> GetAll();
        IDataResult<MovieTranslateLanguage> GetById(int id);
    }
}
