using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISectionLanguageService
    {
        IResult Add(SectionLanguage sectionLanguage);
        IResult Delete(SectionLanguage sectionLanguage);
        IResult Update(SectionLanguage sectionLanguage);
        IDataResult<List<SectionLanguage>> GetAll();
        IDataResult<SectionLanguage> GetById(int id);
    }
}
