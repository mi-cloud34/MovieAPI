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
    public class SectionLanguageManager : ISectionLanguageService
    {
        ISectionLanguageDal _sectionLanguageDal;
        public SectionLanguageManager(ISectionLanguageDal sectionLanguageDal)
        {
            _sectionLanguageDal = sectionLanguageDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(SectionLanguageValidator))]
       
      
        public IResult Add(SectionLanguage sectionLanguage)
        {
            _sectionLanguageDal.Add(sectionLanguage);
            return new SuccessResult();
        }
        [CacheRemoveAspect("ISectionLanguageService.Get")]
        public IResult Delete(SectionLanguage sectionLanguage)
        {
            _sectionLanguageDal.Delete(sectionLanguage);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<SectionLanguage>> GetAll()
        {
           return new SuccessDataResult<List<SectionLanguage>>(_sectionLanguageDal.GetAll());

        }
        [CacheAspect]
        public IDataResult<SectionLanguage> GetById(int id)
        {
            return new SuccessDataResult<SectionLanguage>(_sectionLanguageDal.Get(l=>l.Id==id));
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(SectionLanguageValidator))]
        public IResult Update(SectionLanguage sectionLanguage)
        {
            _sectionLanguageDal.Update(sectionLanguage);
            return new SuccessResult();
        }
    }
}
