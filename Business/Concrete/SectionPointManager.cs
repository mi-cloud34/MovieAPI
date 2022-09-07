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
    public class SectionPointManager : ISectionPointService
    {
        ISectionPointDal _sectionPointDal;
        public SectionPointManager(ISectionPointDal sectionPointDal)
        {
            _sectionPointDal = sectionPointDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(SectionPointValidator))]
      
        public IResult Add(SectionPoint sectionPoint)
        {
            _sectionPointDal.Add(sectionPoint);
            return new SuccessResult();
        }
        [CacheRemoveAspect("ISectionPointService.Get")]
        public IResult Delete(SectionPoint sectionPoint)
        {
           _sectionPointDal.Delete(sectionPoint);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<SectionPoint>> GetAll()
        {
            return new SuccessDataResult<List<SectionPoint>>(_sectionPointDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<SectionPoint> GetById(int id)
        {
            return new SuccessDataResult<SectionPoint>(_sectionPointDal.Get(p=>p.Id==id));
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(SectionPointValidator))]
        public IResult Update(SectionPoint sectionPoint)
        {
           _sectionPointDal.Update(sectionPoint);
            return new SuccessResult();
        }
    }
}
