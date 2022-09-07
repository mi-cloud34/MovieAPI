using Business.Abstract;
using Business.Aspects.Autofac;
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
    internal class AddFavoriteMovieManager:IAddFavoriteMovieService
    {
        public IAddFavoriteMovieDal _addFavoriteMovieDal;
        public AddFavoriteMovieManager(IAddFavoriteMovieDal addFavoriteMovieDal)
        {
            _addFavoriteMovieDal = addFavoriteMovieDal;
        }
        [SecuredOperation("admin,user")]
       
       
        public IResult Add(AddFavoriteMovie addFavoriteMovie)
        {
            _addFavoriteMovieDal.Add(addFavoriteMovie);
            return new SuccessResult();
        }
        [CacheRemoveAspect("IAddFavoriteMovieService.Get")]
        public IResult Delete(AddFavoriteMovie addFavoriteMovie)
        {
            _addFavoriteMovieDal.Delete(addFavoriteMovie);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<AddFavoriteMovie>> GetAll()
        {
            return new SuccessDataResult<List<AddFavoriteMovie>>(_addFavoriteMovieDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<AddFavoriteMovie> GetById(int id)
        {
            return new SuccessDataResult<AddFavoriteMovie>(_addFavoriteMovieDal.Get(m => m.Id == id));
        }

        [SecuredOperation("admin")]
        public IResult Update(AddFavoriteMovie addFavoriteMovie)
        {
            _addFavoriteMovieDal.Update(addFavoriteMovie);
            return new SuccessResult();
        }
    }
}
