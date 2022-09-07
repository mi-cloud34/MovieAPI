using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMovieDal : EfEntityRepositoryBase<Movie, MovieDbContext>, IMovieDal
    {
        public List<MovieDetailsDto> GetMovieDetail()
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from movie in context.Movies
                             join genre in context.MovieGenres
                             on movie.GenreId equals genre.Id
                             join director in context.MovieDirectors
                             on movie.DirectorId equals director.Id
                             join language in context.MovieLanguages
                             on movie.LanguageId equals language.Id
                             join point in context.MoviePoints
                             on movie.PointId equals point.Id
                             join actor in context.MovieActors
                             on movie.ActorId equals actor.Id
                             join translateLanguage in context.MovieTranslateLanguages
                             on movie.TranslateLanguageId equals translateLanguage.Id
                             join category in context.Categories
                             on movie.CategoryId equals category.Id
                             join country in context.MovieCountrys
                             on movie.CountryId equals country.Id
                             select new MovieDetailsDto
                             {
                                 MovieId = movie.Id,
                                 MovieName = movie.MovieName,
                                 GenreName = genre.GenreName,
                                 MovieBudget = Convert.ToDecimal(movie.MovieBudget),
                                 Description = movie.Description,
                                 ActorName = actor.ActorName,
                                 CategoryName = category.CategoryName,
                                 CountryName = country.CountryName,
                                 DirectorName = director.DirectorName,
                                 LanguageName = language.LanguageName,
                                 Point = Convert.ToDecimal(point.Point),
                                 ReleaseDate = Convert.ToDateTime(movie.ReleaseDate),
                                 TranslateLanguageName = translateLanguage.TranslateLanguageName,
                                 ImagePath = (from image in context.MovieImages where image.MovieId.Equals(movie.Id) select image.ImagePath ?? new String('-', 20)).ToList()




                             };
                return result.ToList();
            }

        }
        public List<MovieDetailsDto> GetMovieDetailGenreId(int genreId)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from movie in context.Movies
                             join genre in context.MovieGenres
                             on movie.GenreId equals genre.Id
                             where genre.Id == genreId
                             select new MovieDetailsDto
                             {
                                 MovieId = movie.Id,
                                 MovieName = movie.MovieName,
                                 GenreName = genre.GenreName,
                                 MovieBudget = Convert.ToDecimal(movie.MovieBudget),
                                 Description = movie.Description,
                                 ReleaseDate = Convert.ToDateTime(movie.ReleaseDate),
                                 ImagePath = (from image in context.MovieImages where image.MovieId.Equals(movie.Id) select image.ImagePath ?? new String('-', 20)).ToList()
                             };
                return result.ToList();
            }


        }

        public List<MovieDetailsDto> GetMovieDetailsByCountryId(int countryId)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from movie in context.Movies
                             join country in context.MovieCountrys
                             on movie.CountryId equals country.Id
                             where country.Id == countryId
                             select new MovieDetailsDto
                             {
                                 MovieId = movie.Id,
                                 MovieName = movie.MovieName,
                                 MovieBudget = Convert.ToDecimal(movie.MovieBudget),
                                 Description = movie.Description,
                                 ReleaseDate = Convert.ToDateTime(movie.ReleaseDate),
                                 ImagePath = (from image in context.MovieImages where image.MovieId.Equals(movie.Id) select image.ImagePath ?? new String('-', 20)).ToList()
                             };

                return result.ToList();
            }


        }

        public List<MovieDetailsDto> GetMovieDetailsByDirectorId(int directorId)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from movie in context.Movies
                             join director in context.MovieDirectors
                             on movie.DirectorId equals director.Id
                             where director.Id == directorId
                             select new MovieDetailsDto
                             {
                                 MovieId = movie.Id,
                                 MovieName = movie.MovieName,
                                 MovieBudget = Convert.ToDecimal(movie.MovieBudget),
                                 Description = movie.Description,
                                 DirectorName = director.DirectorName,
                                 ReleaseDate = Convert.ToDateTime(movie.ReleaseDate),
                                 ImagePath = (from image in context.MovieImages where image.MovieId.Equals(movie.Id) select image.ImagePath ?? new String('-', 20)).ToList()
                             };

                return result.ToList();
            }

        }


        public List<MovieDetailsDto> GetMovieDetailsById(int id)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from movie in context.Movies
                             join genre in context.MovieGenres
                             on movie.GenreId equals genre.Id
                             join director in context.MovieDirectors
                             on movie.DirectorId equals director.Id
                             join language in context.MovieLanguages
                             on movie.LanguageId equals language.Id
                             join point in context.MoviePoints
                             on movie.PointId equals point.Id
                             join actor in context.MovieActors
                             on movie.ActorId equals actor.Id
                             join translateLanguage in context.MovieTranslateLanguages
                             on movie.TranslateLanguageId equals translateLanguage.Id
                             join category in context.Categories
                             on movie.CategoryId equals category.Id
                             join country in context.MovieCountrys
                             on movie.CountryId equals country.Id
                             where movie.Id == id
                             select new MovieDetailsDto
                             {
                                 MovieId = movie.Id,
                                 MovieName = movie.MovieName,
                                 GenreName = genre.GenreName,
                                 MovieBudget = Convert.ToDecimal(movie.MovieBudget),
                                 Description = movie.Description,
                                 ActorName = actor.ActorName,
                                 CategoryName = category.CategoryName,
                                 CountryName = country.CountryName,
                                 DirectorName = director.DirectorName,
                                 LanguageName = language.LanguageName,
                                 Point = Convert.ToDecimal(point.Point),
                                 ReleaseDate = Convert.ToDateTime(movie.ReleaseDate),
                                 TranslateLanguageName = translateLanguage.TranslateLanguageName,
                                 ImagePath = (from image in context.MovieImages where image.MovieId.Equals(movie.Id) select image.ImagePath ?? new String('-', 20)).ToList()
                             };

                return result.ToList();
            }


        }

        public List<MovieDetailsDto> GetMovieDetailsByLanguageId(int languageId)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from movie in context.Movies
                             join language in context.MovieLanguages
                             on movie.LanguageId equals language.Id
                             where language.Id == languageId
                             select new MovieDetailsDto
                             {
                                 MovieId = movie.Id,
                                 MovieName = movie.MovieName,
                                 MovieBudget = Convert.ToDecimal(movie.MovieBudget),
                                 Description = movie.Description,
                                 LanguageName = language.LanguageName,
                                 ReleaseDate = Convert.ToDateTime(movie.ReleaseDate),
                                 ImagePath = (from image in context.MovieImages where image.MovieId.Equals(movie.Id) select image.ImagePath ?? new String('-', 20)).ToList()
                             };

                return result.ToList();
            }


        }

        public List<MovieDetailsDto> GetMovieDetailsByPointId(int pointId)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from movie in context.Movies
                             join point in context.MoviePoints
                             on movie.PointId equals point.Id
                             where point.Id == pointId
                             select new MovieDetailsDto
                             {
                                 MovieId = movie.Id,
                                 MovieName = movie.MovieName,
                                 MovieBudget = Convert.ToDecimal(movie.MovieBudget),
                                 Description = movie.Description,
                                 Point = Convert.ToDecimal(point.Point),
                                 ReleaseDate = Convert.ToDateTime(movie.ReleaseDate),
                                 ImagePath = (from image in context.MovieImages where image.MovieId.Equals(movie.Id) select image.ImagePath ?? new String('-', 20)).ToList()
                             };

                return result.ToList();
            }


        }
    }
}

