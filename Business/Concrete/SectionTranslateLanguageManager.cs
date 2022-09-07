using Business.Abstract;
using Business.Aspects.Autofac;
using Bussines.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SectionTranslateLanguageManager : ISectionTranslateLanguageService
    {
        ISectionTranslateLanguageDal _sectionTranslateLanguageDal;
        public SectionTranslateLanguageManager(ISectionTranslateLanguageDal sectionTranslateLanguageDal)
        {
            _sectionTranslateLanguageDal= sectionTranslateLanguageDal;

        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(SectionTranslateLanguageValidator))]
      
        public IResult Add(SectionTranslateLanguage sectionTranslateLanguage)
        {
            _sectionTranslateLanguageDal.Add(sectionTranslateLanguage);
            return new SuccessResult();
        }
        [CacheRemoveAspect("ISectionTranslateLanguageService.Get")]
        public IResult Delete(SectionTranslateLanguage sectionTranslateLanguage)
        {
           _sectionTranslateLanguageDal.Delete(sectionTranslateLanguage);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<SectionTranslateLanguage>> GetAll()
        {
            return new SuccessDataResult<List<SectionTranslateLanguage>>(_sectionTranslateLanguageDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<SectionTranslateLanguage> GetById(int id)
        {
            return new SuccessDataResult<SectionTranslateLanguage>(_sectionTranslateLanguageDal.Get(s=>s.Id==id));
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(SectionTranslateLanguageValidator))]
        public IResult Update(SectionTranslateLanguage sectionTranslateLanguage)
        {
           _sectionTranslateLanguageDal.Update(sectionTranslateLanguage);
            return new SuccessResult();
        }
    }
}
