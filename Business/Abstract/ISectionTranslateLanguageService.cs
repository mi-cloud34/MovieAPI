using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISectionTranslateLanguageService
    {
        IResult Add(SectionTranslateLanguage sectionTranslateLanguage);
        IResult Delete(SectionTranslateLanguage sectionTranslateLanguage);
        IResult Update(SectionTranslateLanguage sectionTranslateLanguage);
        IDataResult<List<SectionTranslateLanguage>> GetAll();
        IDataResult<SectionTranslateLanguage> GetById(int id);
    }
}
