using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMovieImageService
    {
        IResult Add(IFormFile formFile,MovieImage movieImage);
        IResult Delete(MovieImage movieImage);
        IResult Update(IFormFile formFile,MovieImage movieImage);
        IDataResult<MovieImage> GetById(int id);
        IDataResult<List<MovieImage>> GetAll();
        IDataResult<List<MovieImage>> GetImagesByMovieId(int movieId);
    }
}
