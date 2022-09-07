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
    public class MovieGenreManager : IMovieGenreService
    {
        IMovieGenreDal _movieGenreDal;
        public MovieGenreManager(IMovieGenreDal movieGenreDal)
        {
            _movieGenreDal = movieGenreDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(MovieGenreValidator))]
      
        public IResult Add(MovieGenre movieGenre)
        {
            _movieGenreDal.Add(movieGenre);
            return new SuccessResult();
        }
        [CacheRemoveAspect("IMovieGenreService.Get")]
        public IResult Delete(MovieGenre movieGenre)
        {
           _movieGenreDal.Delete(movieGenre);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<MovieGenre>> GetAll()
        {
            return new SuccessDataResult<List<MovieGenre>>(_movieGenreDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<MovieGenre> GetById(int id)
        {
            return new SuccessDataResult<MovieGenre>(_movieGenreDal.Get(g=>g.Id==id));
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(MovieGenreValidator))]
        public IResult Update(MovieGenre movieGenre)
        {
            _movieGenreDal.Update(movieGenre);
            return new SuccessResult();
        }
    }
}
