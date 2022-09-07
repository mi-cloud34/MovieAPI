using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public  interface ISerieService
    {
        IResult Add(Serie serie);
        IResult Delete(Serie serie);
        IResult Update(Serie serie);
        IDataResult<List<Serie>> GetAll();
        IDataResult<Serie> GetById(int id);
    }
}
