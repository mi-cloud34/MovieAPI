using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ILikeMovieDal:IEntityRepository<LikeMovie>
    {
        List<MovieLikeDetailDto> GetMovieLikeDetail();
        List<MovieLikeDetailDto> GetMovieLikeDetailsById(int id);
        List<MovieLikeDetailDto> GetMovieLikeDetailsByUserId(int userId);
        List<MovieLikeDetailDto> GetMovieLikeDetailsByMovieId(int movieId);

    }
}
