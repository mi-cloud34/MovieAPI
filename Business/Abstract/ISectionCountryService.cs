using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISectionCountryService
    {
        IResult Add(SectionCountry sectionCountry);
        IResult Delete(SectionCountry sectionCountry);
        IResult Update(SectionCountry sectionCountry);
        IDataResult<List<SectionCountry>> GetAll();
        IDataResult<SectionCountry> GetById(int id);
    }
}
