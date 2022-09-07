using Business.Abstract;
using Business.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
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
    public class AddFavoriteSectionManager : IAddFavoriteSectionService
    {
        public IAddFavoriteSectionDal _addFavoriteSectionDal;
        public AddFavoriteSectionManager(IAddFavoriteSectionDal addFavoriteSectionDal)
        {
            _addFavoriteSectionDal = addFavoriteSectionDal;
        }
        [SecuredOperation("admin")]
      

        public IResult Add(AddFavoriteSection addFavoriteSection)
        {
            _addFavoriteSectionDal.Add(addFavoriteSection);
            return new SuccessResult();
        }
        [CacheRemoveAspect("IAddFavoriteSectionService.Get")]
        public IResult Delete(AddFavoriteSection addFavoriteSection)
        {
            _addFavoriteSectionDal.Delete(addFavoriteSection);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<AddFavoriteSection>> GetAll()
        {
            return new SuccessDataResult<List<AddFavoriteSection>>(_addFavoriteSectionDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<AddFavoriteSection> GetById(int id)
        {
            return new SuccessDataResult<AddFavoriteSection>(_addFavoriteSectionDal.Get(m => m.Id == id));
        }
        [SecuredOperation("admin,")]
        public IResult Update(AddFavoriteSection addFavoriteSection)
        {
            _addFavoriteSectionDal.Update(addFavoriteSection);
            return new SuccessResult();
        }
    }
}
