using Business.Abstract;
using Business.Aspects.Autofac;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
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
    public class UserManager : IUserService
    {
        public IUserDal _userDal;
        public UserManager(IUserDal userDal) => _userDal = userDal;

        //[SecuredOperation("admin,user.admin,user.add")]
        //[ValidationAspect(typeof(UserValidator))]
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(UserValidator))]
       
       
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        //[SecuredOperation("admin,user.admin,user.delete")]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id.Equals(id)));
        }

        // [SecuredOperation("admin,user.admin,user.update")]
        // [ValidationAspect(typeof(UserValidator))]
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }
        [CacheAspect]
        public IDataResult<User> GetByMail(string emailAdress)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email.Equals(emailAdress)));
        }
    }
}


