using Business.Abstract;
using Business.Aspects.Autofac;
using Business.Constants;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserImageManager : IUserImageService
    {
        IFileHelper _fileHelper;
        IUserImageDal _userImageDal;
        public UserImageManager(IUserImageDal userImageDal,IFileHelper fileHelper):this(userImageDal)
        {
            _fileHelper=fileHelper;
        }
        public UserImageManager(IUserImageDal userImageDal)
        {
        _userImageDal=userImageDal;
        }
        [SecuredOperation("admin")]
       
      
        public IResult Add(IFormFile formFile, UserImage userImage)
        {
            userImage.ImagePath = _fileHelper.Upload(formFile,Paths.ImagesUserPath);
            _userImageDal.Add(userImage);
            return new SuccessResult();
        }
        [CacheRemoveAspect("IUserImageService.Get")]
        public IResult Delete(UserImage userImage)
        {
            _fileHelper.Delete($"{ Paths.ImagesUserPath + userImage.ImagePath }");
            _userImageDal.Delete(userImage);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<UserImage>> GetAll()
        {
           return new SuccessDataResult<List<UserImage>>(_userImageDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<UserImage> GetById(int id)
        {
            return new SuccessDataResult<UserImage>(_userImageDal.Get(i=>i.UserId==id));
        }
        [CacheAspect]
        public IDataResult<List<UserImage>> GetImagesByUserId(int userId)
        {
            return new SuccessDataResult<List<UserImage>>(_userImageDal.GetAll(m=>m.UserId==userId));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(IFormFile formFile, UserImage userImage)
        {
            userImage.ImagePath = _fileHelper.Update(formFile, $"{ Paths.ImagesUserPath + userImage.ImagePath }", Paths.ImagesUserPath);
            _userImageDal.Update(userImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }
    }
}
