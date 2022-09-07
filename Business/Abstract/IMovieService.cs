using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMovieService
    {
        IResult Add(Movie movie);
        IResult Delete(Movie movie);
        IResult Update(Movie movie);
        IDataResult<List<Movie>> GetAll();
        IDataResult<Movie> GetById(int id);
        IDataResult<List<MovieDetailsDto>> GetMovieDetail();
        IDataResult<List<MovieDetailsDto>> GetMovieDetailsById(int id);
        IDataResult<List<MovieDetailsDto>> GetMovieDetailsByPointId(int pointId);
        IDataResult<List<MovieDetailsDto>> GetMovieDetailsByDirectorId(int directorId);
        IDataResult<List<MovieDetailsDto>> GetMovieDetailGenreId(int genreId);
        IDataResult<List<MovieDetailsDto>> GetMovieDetailsByLanguageId(int languageId);
        IDataResult<List<MovieDetailsDto>> GetMovieDetailsByCountryId(int countryId);
    }
}
