using Business.Abstract;
using Business.Aspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
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
    public class MovieVideoManager:IMovieVideoService
    {
        public IFileHelper _fileHelper;
        public IMovieVideoDal _movieVideoDal;
        public MovieVideoManager(IFileHelper fileHelper, IMovieVideoDal movieVideoDal) : this(movieVideoDal)
        {
            _fileHelper = fileHelper;
        }
        public MovieVideoManager(IMovieVideoDal movieVideoDal)
        {
            _movieVideoDal = movieVideoDal;
        }
        [SecuredOperation("admin")]
       
        public IResult Add(IFormFile formFile, MovieVideo movieVideo)
        {

            movieVideo.VideoPath = _fileHelper.Upload(formFile, Paths.MovieVideosPath);
            _movieVideoDal.Add(movieVideo);
            return new SuccessResult();
        }
        [CacheRemoveAspect("IMovieVideoService.Get")]
        public IResult Delete(MovieVideo movieVideo)
        {
            _fileHelper.Delete($"{ Paths.MovieVideosPath + movieVideo.VideoPath }");
            _movieVideoDal.Delete(movieVideo);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<MovieVideo>> GetAll()
        {
            return new SuccessDataResult<List<MovieVideo>>(_movieVideoDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<MovieVideo> GetById(int id)
        {
            return new SuccessDataResult<MovieVideo>(_movieVideoDal.Get(i => i.Id == id));
        }
        [CacheAspect]
        public IDataResult<List<MovieVideo>> GetVideoByMovieVideoId(int movieId)
        {
            return new SuccessDataResult<List<MovieVideo>>(_movieVideoDal.GetAll(m => m.MovieId == movieId));
        }
        [SecuredOperation("admin")]
        public IResult Update(IFormFile formFile, MovieVideo movieVideo)
        {
            movieVideo.VideoPath = _fileHelper.Update(formFile, $"{ Paths.MovieVideosPath + movieVideo.VideoPath }", Paths.MovieVideosPath);
            _movieVideoDal.Update(movieVideo);
            return new SuccessResult();
        }
    }
}
