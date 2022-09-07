using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMovieActorService
    {
        IResult Add(MovieActor movieActor);
        IResult Delete(MovieActor movieActor);
        IResult Update(MovieActor movieActor);
        IDataResult<List<MovieActor>> GetAll();
        IDataResult<MovieActor> GetById(int id);
    }
}
