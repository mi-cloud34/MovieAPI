using Business.Abstract;
using Business.Aspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MovieImageManager : IMovieImageService
    {
        public IFileHelper _fileHelper;
        public IMovieImageDal _movieImageDal;
        public MovieImageManager(IFileHelper fileHelper,IMovieImageDal movieImageDal):this(movieImageDal)
        {
         _fileHelper=fileHelper;
        }
        public MovieImageManager(IMovieImageDal movieImageDal)
        {
            _movieImageDal=movieImageDal;   
        }
        public IResult Add(IFormFile formFile, MovieImage movieImage)
        {
           
            movieImage.ImagePath = _fileHelper.Upload(formFile, Paths.ImagesMoviePath);
            _movieImageDal.Add(movieImage);
            return new SuccessResult();
        }
        [CacheRemoveAspect("IMovieImageServic.Get")]
        public IResult Delete(MovieImage movieImage)
        {
            _fileHelper.Delete($"{ Paths.ImagesMoviePath + movieImage.ImagePath }");
            _movieImageDal.Delete(movieImage);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<MovieImage>> GetAll()
        {
           return new SuccessDataResult<List<MovieImage>>(_movieImageDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<MovieImage> GetById(int id)
        {
            return new SuccessDataResult<MovieImage>(_movieImageDal.Get(i=>i.Id==id));
        }
        [CacheAspect]
        public IDataResult<List<MovieImage>> GetImagesByMovieId(int movieId)
        {
            return new SuccessDataResult<List<MovieImage>>(_movieImageDal.GetAll(m=>m.MovieId==movieId));
        }
        [SecuredOperation("admin")]
        public IResult Update(IFormFile formFile, MovieImage movieImage)
        {
            movieImage.ImagePath = _fileHelper.Update(formFile, $"{ Paths.ImagesMoviePath + movieImage.ImagePath }", Paths.ImagesMoviePath);
            _movieImageDal.Update(movieImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }
    }
}
