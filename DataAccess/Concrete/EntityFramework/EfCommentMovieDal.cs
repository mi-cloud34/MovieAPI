using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCommentMovieDal : EfEntityRepositoryBase<CommentMovie, MovieDbContext>, ICommentMovieDal
    {
        public List<MovieCommentDetailDto> GetMovieCommentDetailsById(int id)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from commentMovie in context.CommentMovies
                             join user in context.Users
                             on commentMovie.UserId equals user.Id
                             join movie in context.Movies
                             on commentMovie.MovieId equals movie.Id
                             where commentMovie.Id == id 
                             select new MovieCommentDetailDto
                             {
                                 CommentId  = commentMovie.Id,
                                  Comment = commentMovie.Comment,
                                 FirstName = user.FirstName,
                                 MovieName = movie.MovieName,
                                 Date = commentMovie.Date,
                             };
                return result.ToList();
            }


        }

        public List<MovieCommentDetailDto> GetMovieCommentDetailsByMovieId(int movieId)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from commentMovie in context.CommentMovies
                             join movie in context.Movies
                             on commentMovie.MovieId equals movie.Id
                             where movie.Id == movieId
                             select new MovieCommentDetailDto
                             {
                                 CommentId = commentMovie.Id,
                                 Comment = commentMovie.Comment,
                                 MovieName = movie.MovieName,
                                 Date = commentMovie.Date,
                             };
                return result.ToList();
            }


        }

        public List<MovieCommentDetailDto> GetMovieCommentDetailsByUserId(int userId)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from commentMovie in context.CommentMovies
                             join user in context.Users
                             on commentMovie.UserId equals user.Id
                             where user.Id == userId   
                             select new MovieCommentDetailDto
                             {
                                 CommentId = commentMovie.Id,
                                 Comment = commentMovie.Comment,
                                 FirstName = user.FirstName,
                                Date = commentMovie.Date,
                             };
                return result.ToList();
            }


        }

        public List<MovieCommentDetailDto> GetMovieCommmentDetail()
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from commentMovie in context.CommentMovies
                             join user in context.Users
                             on commentMovie.UserId equals user.Id
                             join movie in context.Movies
                             on commentMovie.MovieId equals movie.Id

                             select new MovieCommentDetailDto
                             {
                                 CommentId = commentMovie.Id,
                                 Comment = commentMovie.Comment,
                                 FirstName = user.FirstName,
                                 MovieName = movie.MovieName,
                                 Date = commentMovie.Date,
                             };
                return result.ToList();
            }


        }
    }
}
