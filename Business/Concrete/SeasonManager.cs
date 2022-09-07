using Business.Abstract;
using Business.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
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
    public class SeasonManager : ISeasonService
    {
        ISeasonDal _seasonDal;
        public SeasonManager(ISeasonDal seasonDal)
        {
            _seasonDal = seasonDal;
        }
        [SecuredOperation("admin")]
      
        [TransactionScopeAspect]
        [PerformanceAspect(5)]
       
        public IResult Add(Season season)
        {
            _seasonDal.Add(season);
            return new SuccessResult();
        }
        [CacheRemoveAspect("ISeasonService.Get")]
        public IResult Delete(Season season)
        {
            _seasonDal.Delete(season);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<Season>> GetAll()
        {
           return new SuccessDataResult<List<Season>>(_seasonDal.GetAll());    
        }
        [CacheAspect]
        public IDataResult<Season> GetBuId(int id)
        {
            return new SuccessDataResult<Season>(_seasonDal.Get(s=>s.Id==id));
        }
        [SecuredOperation("admin")]
        public IResult Update(Season season)
        {
            _seasonDal.Update(season);
            return new SuccessResult();
        }
    }
}
