using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISeasonService
    {
        IResult Add(Season season);
        IResult Update(Season season);
        IResult Delete(Season season);
        IDataResult<List<Season>> GetAll();
        IDataResult<Season> GetBuId(int id);
    }
}
