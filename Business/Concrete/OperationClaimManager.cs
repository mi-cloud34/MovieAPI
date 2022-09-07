using Business.Abstract;
using Business.Aspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OperationClaimManager:IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;
        public OperationClaimManager(IOperationClaimDal operationClaimDal) => _operationClaimDal = operationClaimDal;

        //[SecuredOperation("operationClaims.add")]
        // [ValidationAspect(typeof(OperationClaimValidator))]
        [SecuredOperation("admin")]
       
        public IResult Add(OperationClaim operationClaim)
        {
            IResult? result = BusinessRules.Run(CheckIfOperationClaimNameExists(operationClaim.Name));
            if (result != null)
            {
                return result;
            }
            _operationClaimDal.Add(operationClaim);
            return new SuccessResult(/*Messages.OperationClaimAdded*/);
        }

        // [SecuredOperation("operationClaims.delete")]
        [CacheRemoveAspect("IOperationClaimService.Get")]
        public IResult Delete(OperationClaim operationClaim)
        {
            _operationClaimDal.Delete(operationClaim);
            return new SuccessResult(/*Messages.OperationClaimDeleted)*/);
        }
        [CacheAspect]
        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll()/*,Messages.OperationClaimListed*/);
        }
        [CacheAspect]
        public IDataResult<OperationClaim> GetById(int id)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(u => u.Id.Equals(id))/*,Messages.OperationClaimListed*/);
        }

       
        [SecuredOperation("admin")]
       
        public IResult Update(OperationClaim operationClaim)
        {
            IResult? result = BusinessRules.Run(CheckIfOperationClaimNameExists(operationClaim.Name));
            if (result != null)
            {
                return result;
            }
            _operationClaimDal.Update(operationClaim);
            return new SuccessResult(/*Messages.OperationClaimUpdated*/);
        }

        private IResult CheckIfOperationClaimNameExists(string operationClaimName)
        {
            return _operationClaimDal.GetAll(o => o.Name.Equals(operationClaimName)).Any() ?
                new ErrorResult() :
                new SuccessResult();
        }
    }
}
