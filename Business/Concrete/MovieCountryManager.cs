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
    public class MovieCountryManager : IMovieCountryService
    {
        IMovieCountryDal _movieCountryDal;
        public MovieCountryManager(IMovieCountryDal movieCountryDal)
        {
            _movieCountryDal=movieCountryDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(MovieCountryValidator))]
      
        public IResult Add(MovieCountry movieCountry)
        {
            _movieCountryDal.Add(movieCountry);
            return new SuccessResult();
        }
        [CacheRemoveAspect("IMovieCountryService.Get")]
        public IResult Delete(MovieCountry movieCountry)
        {
            _movieCountryDal.Delete(movieCountry);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<MovieCountry>> GetAll()
        {
            return new SuccessDataResult<List<MovieCountry>>(_movieCountryDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<MovieCountry> GetById(int id)
        {
            return new SuccessDataResult<MovieCountry>(_movieCountryDal.Get(m=>m.Id==id));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(MovieCountryValidator))]
        public IResult Update(MovieCountry movieCountry)
        {
            _movieCountryDal.Update(movieCountry);
            return new SuccessResult();
        }
    }
}
