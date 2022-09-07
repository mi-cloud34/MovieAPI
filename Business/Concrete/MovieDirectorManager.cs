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
    public class MovieDirectorManager : IMovieDirectorService
    {
        IMovieDirectorDal _movieDirectorDal;
        public MovieDirectorManager(IMovieDirectorDal movieDirectorDal)
        {
            _movieDirectorDal = movieDirectorDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(MovieDirectorValidator))]
       
        public IResult Add(MovieDirector movieDirector)
        {
           _movieDirectorDal.Add(movieDirector);
            return new SuccessResult();
        }
        [CacheRemoveAspect("IMovieDirectorService.Get")]
        public IResult Delete(MovieDirector movieDirector)
        {
           _movieDirectorDal.Delete(movieDirector);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<MovieDirector>> GetAll()
        {
           return new SuccessDataResult<List<MovieDirector>>(_movieDirectorDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<MovieDirector> GetById(int id)
        {
            return new SuccessDataResult<MovieDirector>(_movieDirectorDal.Get(d=>d.Id==id));
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(MovieDirectorValidator))]
        public IResult Update(MovieDirector movieDirector)
        {
           _movieDirectorDal.Update(movieDirector);
            return new SuccessResult();
        }
    }
}
