using Business.Abstract;
using Business.Aspects.Autofac;
using Business.Constants;
using Bussines.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
    public class LikeMovieManager : ILikeMovieService
    {
        ILikeMovieDal _likeMovieDal;
        public LikeMovieManager(ILikeMovieDal likeMovieDal)
        {
            _likeMovieDal=likeMovieDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(LikeMovieValidator))]
        [TransactionScopeAspect]
        [PerformanceAspect(5)]
       
        public IResult Add(LikeMovie likeMovie,int id)
        {
            var sonuc = _likeMovieDal.Get(l => l.Id == id);
            likeMovie.Like += 1;
            likeMovie.Id= sonuc.Id;
           _likeMovieDal.Add(likeMovie);
            return new SuccessResult();
        }
        [CacheRemoveAspect("ILikeMovieService.Get")]
        public IResult Delete(LikeMovie likeMovie,int id)
        {
            id = likeMovie.Id;
            Console.WriteLine("id:"+id);
            var sonuc =_likeMovieDal.Get(l => l.Id == id);
           // int sonuc2 = _likeMovieDal.Get(l => l.Id == id).Like;
            if (sonuc.Like != 0 && sonuc.Like > 0)
            {
                likeMovie.Id = sonuc.Id;
                likeMovie.UserId = sonuc.UserId;
                likeMovie.MovieId = sonuc.MovieId;
                sonuc.Like -= 1;
            }
            else
            {
                return new ErrorResult(Messages.LikeCountError);
            }
            // _likeMovieDal.Delete(likeMovie);
            _likeMovieDal.Update(likeMovie);
            return new SuccessResult();









             /*var count= BusinessRules.Run(CheckCountLike(likeMovie));
              if (count.Success)
              {
                  _likeMovieDal.Delete(likeMovie);
                  return new SuccessResult();
              }
             else return new ErrorResult(Messages.LikeCountError);*/

        }
        [CacheAspect]
        public IDataResult<List<LikeMovie>> GetAll()
        {
            return new SuccessDataResult<List<LikeMovie>>(_likeMovieDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<LikeMovie> GetById(int id)
        {
            return new SuccessDataResult<LikeMovie>(_likeMovieDal.Get(l=>l.Id==id));
        }
        [CacheAspect]
        public IDataResult<List<MovieLikeDetailDto>> GetMovieLikeDetail()
        {
           return new SuccessDataResult<List<MovieLikeDetailDto>>(_likeMovieDal.GetMovieLikeDetail());
        }
        [CacheAspect]
        public IDataResult<List<MovieLikeDetailDto>> GetMovieLikeDetailsById(int id)
        {
            return new SuccessDataResult<List<MovieLikeDetailDto>>(_likeMovieDal.GetMovieLikeDetailsByMovieId(id));
        }
        [CacheAspect]
        public IDataResult<List<MovieLikeDetailDto>> GetMovieLikeDetailsByMovieId(int movieId)
        {
            return new SuccessDataResult<List<MovieLikeDetailDto>>(_likeMovieDal.GetMovieLikeDetailsByMovieId(movieId));
        }
        [CacheAspect]
        public IDataResult<List<MovieLikeDetailDto>> GetMovieLikeDetailsByUserId(int userId)
        {
           return new SuccessDataResult<List<MovieLikeDetailDto>>(_likeMovieDal.GetMovieLikeDetailsByUserId(userId));
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(LikeMovieValidator))]
        public IResult Update(LikeMovie likeMovie)
        {
            _likeMovieDal.Update(likeMovie);
            return new  SuccessResult();
        }
        private IResult CheckCountLike(LikeMovie likeMovie)
        {
            var result = likeMovie.Like != 0 && likeMovie.Like > 0;
            return result!=null ? new SuccessResult() : new ErrorResult();
            /*if (likeMovie.Like != 0 && likeMovie.Like > 0)
            {
                likeMovie.Like -= 1;
            }
            else
            {
                return new ErrorResult(Messages.LikeCountError);
            }*/
        }
    }
   
}
