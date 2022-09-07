using Business.Abstract;
using Business.Aspects.Autofac;
using Bussines.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MoviePointManager : IMoviePointService
    {
        IMoviePointDal _moviePoint;
        public MoviePointManager(IMoviePointDal moviePointDaL)
        {
            _moviePoint = moviePointDaL;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(MoviePointValidator))]
       
        public IResult Add(MoviePoint moviePoint)
        {
            _moviePoint.Add(moviePoint);
            return new SuccessResult();
        }
        [CacheRemoveAspect("IMoviePointService.Get")]
        public IResult Delete(MoviePoint moviePoint)
        {
            _moviePoint.Delete(moviePoint);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<MoviePoint>> GetAll()
        {
           return new SuccessDataResult<List<MoviePoint>>(_moviePoint.GetAll());
        }
        [CacheAspect]
        public IDataResult<MoviePoint> GetById(int id)
        {
            return new SuccessDataResult<MoviePoint>(_moviePoint.Get(p=>p.Id==id));
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(MoviePointValidator))]

        public IResult Update(MoviePoint moviePoint)
        {
            _moviePoint.Update(moviePoint);
            return new SuccessResult();
        }
    }
}
