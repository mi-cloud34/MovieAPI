using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILikeMovieService
    {
        IResult Add(LikeMovie likeMovie,int id);
        IResult Delete(LikeMovie likeMovie,int id);
        IResult Update(LikeMovie likeMovie);
        IDataResult<List<LikeMovie>> GetAll();
        IDataResult<LikeMovie> GetById(int id);
       IDataResult<List<MovieLikeDetailDto>> GetMovieLikeDetail();
        IDataResult<List<MovieLikeDetailDto>> GetMovieLikeDetailsById(int id);
        IDataResult<List<MovieLikeDetailDto>> GetMovieLikeDetailsByUserId(int userId);
        IDataResult<List<MovieLikeDetailDto>> GetMovieLikeDetailsByMovieId(int movieId);
    }
}
