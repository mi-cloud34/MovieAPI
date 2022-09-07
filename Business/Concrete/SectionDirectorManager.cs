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
    public class SectionDirectorManager : ISectionDirectorService
    {
        ISectionDirectorDal _sectionDirectorDal;
        public SectionDirectorManager(ISectionDirectorDal sectionDirectorDal)
        {
            _sectionDirectorDal = sectionDirectorDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(SectionDirectorValidator))]
       
        public IResult Add(SectionDirector sectionDirector)
        {
           _sectionDirectorDal.Add(sectionDirector);
            return new SuccessResult();
        }
        [CacheRemoveAspect("ISectionDirectorService.Get")]
        public IResult Delete(SectionDirector sectionDirector)
        {
            _sectionDirectorDal.Delete(sectionDirector);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<SectionDirector>> GetAll()
        {
           return new SuccessDataResult<List<SectionDirector>>(_sectionDirectorDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<SectionDirector> GetById(int id)
        {
            return new SuccessDataResult<SectionDirector>(_sectionDirectorDal.Get(d=>d.Id==id));
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(SectionDirectorValidator))]
        public IResult Update(SectionDirector sectionDirector)
        {
           _sectionDirectorDal.Update(sectionDirector);
            return new SuccessResult();
        }
    }
}
