using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISectionActorService
    {
        IResult Add(SectionActor sectionActor);
        IResult Delete(SectionActor sectionActor);
        IResult Update(SectionActor sectionActor);
        IDataResult<List<SectionActor>> GetAll();
        IDataResult<SectionActor> GetById(int id);
    }
}
