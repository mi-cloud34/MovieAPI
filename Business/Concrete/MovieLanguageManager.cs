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
    public class MovieLanguageManager : IMovieLanguageService
    {
        IMovieLanguageDal _movieLanguageDal;
        public MovieLanguageManager(IMovieLanguageDal movieLanguageDal)
        {
            _movieLanguageDal=movieLanguageDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(MovieLanguageValidator))]
      
        public IResult Add(MovieLanguage movieLanguage)
        {
           _movieLanguageDal.Add(movieLanguage);
            return new SuccessResult();
        }
        [CacheRemoveAspect("IMovieLanguageService.Get")]
        public IResult Delete(MovieLanguage movieLanguage)
        {
           _movieLanguageDal.Delete(movieLanguage);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<MovieLanguage>> GetAll()
        {
            return new SuccessDataResult<List<MovieLanguage>>(_movieLanguageDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<MovieLanguage> GetById(int id)
        {
            return new SuccessDataResult<MovieLanguage>(_movieLanguageDal.Get(l=>l.Id==id));
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(MovieLanguageValidator))]
        public IResult Update(MovieLanguage movieLanguage)
        {
            _movieLanguageDal.Update(movieLanguage);
            return new SuccessResult();
        }
    }
}
