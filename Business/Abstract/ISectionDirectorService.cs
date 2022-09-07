using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISectionDirectorService
    {
        IResult Add(SectionDirector sectionDirector);
        IResult Delete(SectionDirector sectionDirector);
        IResult Update(SectionDirector sectionDirector);
        IDataResult<List<SectionDirector>> GetAll();
        IDataResult<SectionDirector> GetById(int id);
    }
}
