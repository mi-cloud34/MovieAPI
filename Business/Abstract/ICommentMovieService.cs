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
    public interface ICommentMovieService
    {
        IResult Add(CommentMovie commentMovie);
        IResult Delete(CommentMovie commentMovie);
        IResult Update(CommentMovie commentMovie);
        IDataResult<List<CommentMovie>> GetAll();
        IDataResult<CommentMovie> GetById(int id);
       IDataResult<List<MovieCommentDetailDto>> GetMovieCommmentDetail();
        IDataResult<List<MovieCommentDetailDto>> GetMovieCommentDetailsById(int id);
        IDataResult<List<MovieCommentDetailDto>>  GetMovieCommentDetailsByUserId(int userId);
        IDataResult<List<MovieCommentDetailDto>> GetMovieCommentDetailsByMovieId(int movieId);
    }
}
