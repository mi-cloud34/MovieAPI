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
    public class EfLikeMovieDal : EfEntityRepositoryBase<LikeMovie, MovieDbContext>, ILikeMovieDal
    {
        public List<MovieLikeDetailDto> GetMovieLikeDetail()
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from  likeMovie in context.LikeMovies
                             join user in context.Users
                             on likeMovie.UserId equals user.Id
                             join movie in context.Movies
                             on likeMovie.MovieId equals movie.Id

                             select new MovieLikeDetailDto
                             {
                                 LikeId = likeMovie.Id,
                                 Like =likeMovie.Like,
                                 FirstName = user.FirstName,
                                 MovieName=movie.MovieName,
                                 Date=likeMovie.Date,   
                             };
                return result.ToList();
            }


        }

        public List<MovieLikeDetailDto> GetMovieLikeDetailsById(int id)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from likeMovie in context.LikeMovies
                             join user in context.Users
                             on likeMovie.UserId equals user.Id
                             join movie in context.Movies
                             on likeMovie.MovieId equals movie.Id
                             where likeMovie.MovieId == id
                             select new MovieLikeDetailDto
                             {
                                 LikeId = likeMovie.Id,
                                 Like = likeMovie.Like,
                                 FirstName = user.FirstName,
                                 MovieName = movie.MovieName,
                                 Date = likeMovie.Date,
                             };
                return result.ToList();
            }


        }

        public List<MovieLikeDetailDto> GetMovieLikeDetailsByMovieId(int movieId)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from likeMovie in context.LikeMovies
                             join movie in context.Movies
                             on likeMovie.MovieId equals movie.Id
                             where movie.Id == movieId
                             select new MovieLikeDetailDto
                             {
                                 LikeId = likeMovie.Id,
                                 Like = likeMovie.Like,
                                 MovieName = movie.MovieName,
                                 Date = likeMovie.Date,
                             };
                return result.ToList();
            }


        }

        public List<MovieLikeDetailDto> GetMovieLikeDetailsByUserId(int userId)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from likeMovie in context.LikeMovies
                             join user in context.Users
                             on likeMovie.UserId equals user.Id
                            where user.Id == userId
                             select new MovieLikeDetailDto
                             {
                                 LikeId = likeMovie.Id,
                                 Like = likeMovie.Like,
                                 FirstName = user.FirstName,
                                 Date = likeMovie.Date,
                             };
                return result.ToList();
            }


        }
    }
}
