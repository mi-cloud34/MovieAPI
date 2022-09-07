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
    public interface ICommentMovieDal:IEntityRepository<CommentMovie>
    {
        List<MovieCommentDetailDto> GetMovieCommmentDetail();
        List<MovieCommentDetailDto> GetMovieCommentDetailsById(int id);
        List<MovieCommentDetailDto> GetMovieCommentDetailsByUserId(int userId);
        List<MovieCommentDetailDto> GetMovieCommentDetailsByMovieId(int movieId);
      
    }
}
