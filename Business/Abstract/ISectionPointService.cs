using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISectionPointService
    {
        IResult Add(SectionPoint sectionPoint);
        IResult Delete(SectionPoint sectionPoint);
        IResult Update(SectionPoint sectionPoint);
        IDataResult<List<SectionPoint>> GetAll();
        IDataResult<SectionPoint> GetById(int id);
    }
}
