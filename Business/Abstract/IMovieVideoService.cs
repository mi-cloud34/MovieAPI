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
    public interface IMovieVideoService
    {
        IResult Add(IFormFile formFile, MovieVideo movieVideo);
        IResult Delete(MovieVideo movieImage);
        IResult Update(IFormFile formFile, MovieVideo movieVideo);
        IDataResult<MovieVideo> GetById(int id);
        IDataResult<List<MovieVideo>> GetAll();
        IDataResult<List<MovieVideo>> GetVideoByMovieVideoId(int movieVideoId);
    }
}
