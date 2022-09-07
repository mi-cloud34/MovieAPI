using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IMovieDal:IEntityRepository<Movie>
    {
        List<MovieDetailsDto> GetMovieDetail();
        List<MovieDetailsDto> GetMovieDetailsById(int id);
        List<MovieDetailsDto> GetMovieDetailsByPointId(int pointId);
        List<MovieDetailsDto> GetMovieDetailsByDirectorId(int directorId);
        List<MovieDetailsDto> GetMovieDetailGenreId(int genreId);
        List<MovieDetailsDto> GetMovieDetailsByLanguageId(int languageId);
        List<MovieDetailsDto> GetMovieDetailsByCountryId(int countryId);
      
    }
}
