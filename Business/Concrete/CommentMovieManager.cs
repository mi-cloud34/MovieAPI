using Business.Abstract;
using Business.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentMovieManager : ICommentMovieService
    {
        ICommentMovieDal _commentMovieDal;
        public CommentMovieManager(ICommentMovieDal commentMovieDal)
        {
            _commentMovieDal= commentMovieDal;
        }
        [SecuredOperation("admin")]
       
       
       
        public IResult Add(CommentMovie commentMovie)
        {
           _commentMovieDal.Add(commentMovie);
            return new SuccessResult();
        }
        [CacheRemoveAspect("ICommentMovieService.Get")]
        public IResult Delete(CommentMovie commentMovie)
        {
            _commentMovieDal.Delete(commentMovie);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<CommentMovie>> GetAll()
        {
            return new SuccessDataResult<List<CommentMovie>>(_commentMovieDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<CommentMovie> GetById(int id)
        {
            return new SuccessDataResult<CommentMovie>(_commentMovieDal.Get(m=>m.Id==id));
        }
        [CacheAspect]
        public IDataResult<List<MovieCommentDetailDto>> GetMovieCommentDetailsById(int id)
        {
           return new SuccessDataResult<List<MovieCommentDetailDto>>(_commentMovieDal.GetMovieCommentDetailsById(id));
        }
        [CacheAspect]
        public IDataResult<List<MovieCommentDetailDto>> GetMovieCommentDetailsByMovieId(int movieId)
        {
            return new SuccessDataResult<List<MovieCommentDetailDto>>(_commentMovieDal.GetMovieCommentDetailsByMovieId(movieId));
        }
        [CacheAspect]
        public IDataResult<List<MovieCommentDetailDto>> GetMovieCommentDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<MovieCommentDetailDto>>(_commentMovieDal.GetMovieCommentDetailsByUserId(userId));
        }
        [CacheAspect]
        public IDataResult<List<MovieCommentDetailDto>> GetMovieCommmentDetail()
        {
            return new SuccessDataResult<List<MovieCommentDetailDto>>(_commentMovieDal.GetMovieCommmentDetail());
        }
        [SecuredOperation("admin")]
        public IResult Update(CommentMovie commentMovie)
        {
            _commentMovieDal.Update(commentMovie);
            return new SuccessResult();
        }
    }
}
