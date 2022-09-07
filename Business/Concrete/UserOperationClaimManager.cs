using Business.Abstract;
using Business.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Entities.Concrete;
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
    public class UserOperationClaimManager:IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;
        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal) => _userOperationClaimDal = userOperationClaimDal;

        // [ValidationAspect(typeof(UserOperationClaimValidator))]
        [SecuredOperation("admin")]
      
        public IResult Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(/*Messages.UserOperationClaimAdded*/);
        }
        [CacheRemoveAspect("IUserOperationClaimService.Get")]
        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult(/*Messages.UserOperationClaimDeleted*/);
        }
        [CacheAspect]
        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll()/*,Messages.UserOperationClaimsListed*/);
        }
        [CacheAspect]
        public IDataResult<UserOperationClaim> GetById(int id)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(u => u.Id.Equals(id))/*, Messages.UserOperationClaimListed*/);
        }
        [CacheAspect]
        public IDataResult<List<UserOperationClaim>> GetUserOperationClaimByOperationClaimId(int operationClaimId)
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll(u => u.OperationClaimId.Equals(operationClaimId)));
        }
        [CacheAspect]
        public IDataResult<List<UserOperationClaim>> GetUserOperationClaimByUserId(int userId)
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll(u => u.UserId.Equals(userId)));
        }

        // [ValidationAspect(typeof(UserOperationClaimValidator))]
        [SecuredOperation("admin")]
       
        public IResult Update(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult(/*Messages.UserOperationClaimUpdated*/);
        }
    }
}

