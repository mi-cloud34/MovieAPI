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
    public class SectionActorManager:ISectionActorService
    {
        ISectionActorDal _sectionActorDal;
        public SectionActorManager(ISectionActorDal sectionActorDal)
        {
            _sectionActorDal =sectionActorDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(SectionActorValidator))]
      
        public IResult Add(SectionActor sectionActor)
        {
            _sectionActorDal.Add(sectionActor);
            return new SuccessResult();
        }
        [CacheRemoveAspect("ISectionActorService.Get")]
        public IResult Delete(SectionActor sectionActor)
        {
            _sectionActorDal.Delete(sectionActor);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<SectionActor>> GetAll()
        {
            return new SuccessDataResult<List<SectionActor>>(_sectionActorDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<SectionActor> GetById(int id)
        {
            return new SuccessDataResult<SectionActor>(_sectionActorDal.Get(s => s.Id == id));
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(SectionActorValidator))]
        public IResult Update(SectionActor sectionActor)
        {
            
            _sectionActorDal.Update(sectionActor);
            return new SuccessResult();
        }
    }
}
