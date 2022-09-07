using Business.Abstract;
using Business.Aspects.Autofac;
using Bussines.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MovieTranslateLanguageManager : IMovieTranslateLanguageService
    {
        IMovieTranslateLanguageDal _movieTranslateLanguageDal;
        public MovieTranslateLanguageManager(IMovieTranslateLanguageDal movieTranslateLanguageDal)
        {
            _movieTranslateLanguageDal= movieTranslateLanguageDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(MovieTranslateLanguageValidator))]
      
        public IResult Add(MovieTranslateLanguage movieTranslateLanguage)
        {
           _movieTranslateLanguageDal.Add(movieTranslateLanguage);
            return new SuccessResult();
        }
        [CacheRemoveAspect("IMovieTranslateLanguageService.Get")]
        public IResult Delete(MovieTranslateLanguage movieTranslateLanguage)
        {
           _movieTranslateLanguageDal.Delete(movieTranslateLanguage);
            return new SuccessResult();
        }

        public IDataResult<List<MovieTranslateLanguage>> GetAll()
        {
           return new SuccessDataResult<List<MovieTranslateLanguage>>(_movieTranslateLanguageDal.GetAll());
        }

        public IDataResult<MovieTranslateLanguage> GetById(int id)
        {
            return new SuccessDataResult<MovieTranslateLanguage>(_movieTranslateLanguageDal.Get(t=>t.Id==id));
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(MovieTranslateLanguageValidator))]
        public IResult Update(MovieTranslateLanguage movieTranslateLanguage)
        {
           _movieTranslateLanguageDal.Update(movieTranslateLanguage);
            return new SuccessResult();
        }
    }
}
