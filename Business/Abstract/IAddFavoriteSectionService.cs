using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAddFavoriteSectionService
    {
        IResult Add(AddFavoriteSection addFavoriteSection);
        IResult Delete(AddFavoriteSection addFavoriteSection);
        IResult Update(AddFavoriteSection addFavoriteSection);
        IDataResult<List<AddFavoriteSection>> GetAll();
        IDataResult<AddFavoriteSection> GetById(int id);
    }
}
