using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserImageService
    {
        IResult Add(IFormFile formFile,UserImage userImage);
        IResult Delete(UserImage userImage);
        IResult Update(IFormFile formFile,UserImage userImage);
        IDataResult<List<UserImage>> GetAll();
        IDataResult<UserImage> GetById(int id);
        IDataResult<List<UserImage>> GetImagesByUserId(int userId);
    }
}
