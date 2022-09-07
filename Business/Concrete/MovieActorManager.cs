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
    public class MovieActorManager : IMovieActorService
    {
      public  IMovieActorDal _movieActor;
            public MovieActorManager(IMovieActorDal movieActorDal)
        {
                    _movieActor=movieActorDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(MovieActorValidator))]
     
        public IResult Add(MovieActor movieActor)
        {
            _movieActor.Add(movieActor);
            return new SuccessResult();
        }
        [CacheRemoveAspect("IMovieActorService.Get")]
        public IResult Delete(MovieActor movieActor)
        {
            _movieActor.Delete(movieActor);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<MovieActor>> GetAll()
        {
           return new SuccessDataResult<List<MovieActor>>(_movieActor.GetAll());
        }
        [CacheAspect]
        public IDataResult<MovieActor> GetById(int id)
        {
            return new SuccessDataResult<MovieActor>(_movieActor.Get(m=>m.Id==id));
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(MovieActorValidator))]
        public IResult Update(MovieActor movieActor)
        {
            _movieActor.Update(movieActor);
            return new SuccessResult();
        }
    }
}
