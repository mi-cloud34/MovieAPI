using Business.Abstract;
using Business.Aspects.Autofac;
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
    public class SectionCountryManager : ISectionCountryService
    {
        ISectionCountryDal _sectionCountryDal;
        public SectionCountryManager(ISectionCountryDal sectionCountryDal)
        {
             _sectionCountryDal = sectionCountryDal;
        }
        [SecuredOperation("admin")]
       
        public IResult Add(SectionCountry sectionCountry)
        {
           _sectionCountryDal.Add(sectionCountry);
            return new SuccessResult();
        }
        [CacheRemoveAspect("ISectionCountryService.Get")]
        public IResult Delete(SectionCountry sectionCountry)
        {
            _sectionCountryDal.Delete(sectionCountry);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<SectionCountry>> GetAll()
        {
            return new SuccessDataResult<List<SectionCountry>>(_sectionCountryDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<SectionCountry> GetById(int id)
        {
            return new SuccessDataResult<SectionCountry>(_sectionCountryDal.Get(c=>c.Id==id));
        }
        [SecuredOperation("admin")]
        public IResult Update(SectionCountry sectionCountry)
        {
           _sectionCountryDal.Update(sectionCountry);
            return new SuccessResult();
        }
    }
}
