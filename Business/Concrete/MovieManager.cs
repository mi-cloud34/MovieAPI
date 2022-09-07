using Business.Abstract;
using Business.Aspects.Autofac;
using Bussines.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MovieManager : IMovieService
    {
        IMovieDal _movieDal;
        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(MovieValidator))]
        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [CacheRemoveAspect("IMovieService.Get")]
        [CacheAspect]
        public IResult Add(Movie movie)
        {
            _movieDal.Add(movie);
            return new SuccessResult();
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Movie movie)
        {
          _movieDal.Delete(movie);
            return new SuccessResult();
        }

        public IDataResult<List<Movie>> GetAll()
        {
            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll());
        }

        public IDataResult<Movie> GetById(int id)
        {
            return new SuccessDataResult<Movie>(_movieDal.Get(m=>m.Id==id));
        }

        public IDataResult<List<MovieDetailsDto>> GetMovieDetail()
        {
            return new SuccessDataResult<List<MovieDetailsDto>>(_movieDal.GetMovieDetail());
        }

        public IDataResult<List<MovieDetailsDto>> GetMovieDetailGenreId(int genreId)
        {
            return new SuccessDataResult<List<MovieDetailsDto>>(_movieDal.GetMovieDetailGenreId(genreId));
        }

        public IDataResult<List<MovieDetailsDto>> GetMovieDetailsByCountryId(int countryId)
        {
            return new SuccessDataResult<List<MovieDetailsDto>>(_movieDal.GetMovieDetailsByCountryId(countryId));
        }

        public IDataResult<List<MovieDetailsDto>> GetMovieDetailsByDirectorId(int directorId)
        {
            return new SuccessDataResult<List<MovieDetailsDto>>(_movieDal.GetMovieDetailsByDirectorId(directorId));
        }

        public IDataResult<List<MovieDetailsDto>> GetMovieDetailsById(int id)
        {
            return new SuccessDataResult<List<MovieDetailsDto>>(_movieDal.GetMovieDetailsById(id));
        }

        public IDataResult<List<MovieDetailsDto>> GetMovieDetailsByLanguageId(int languageId)
        {
            return new SuccessDataResult<List<MovieDetailsDto>>(_movieDal.GetMovieDetailsByLanguageId(languageId));
        }

        public IDataResult<List<MovieDetailsDto>> GetMovieDetailsByPointId(int pointId)
        {
            return new SuccessDataResult<List<MovieDetailsDto>>(_movieDal.GetMovieDetailsByPointId(pointId));
        }
        [SecuredOperation("admin")]
        public IResult Update(Movie movie)
        {
            _movieDal.Update(movie);
            return new SuccessResult();
        }
    }
}
