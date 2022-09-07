using Business.Abstract;
using Business.Aspects.Autofac;
using Business.Constants;
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
    public class SectionImageManager : ISectionImageService
    {
        public IFileHelper _fileHelper;
        public ISectionImageDal _sectionImageDal;
        public SectionImageManager(IFileHelper fileHelper, ISectionImageDal sectionImageDal) : this(sectionImageDal)
        {
            _fileHelper = fileHelper;
        }
        public SectionImageManager(ISectionImageDal sectionImageDal)
        {
           _sectionImageDal=sectionImageDal;
        }
        [SecuredOperation("admin")]
       
      
        public IResult Add(IFormFile formFile, SectionImage sectionImage)
        {
            sectionImage.ImagePath = _fileHelper.Upload(formFile,Paths.ImagesSectionPath);
            _sectionImageDal.Add(sectionImage);
            return new  SuccessResult();
        }
        [CacheRemoveAspect("ISectionImageService.Get")]
        public IResult Delete(SectionImage sectionImage)
        {
            _fileHelper.Delete($"{sectionImage.ImagePath+Paths.ImagesSectionPath}");
            _sectionImageDal.Delete(sectionImage);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<SectionImage>> GetAll()
        {
           return new SuccessDataResult<List<SectionImage>>(_sectionImageDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<SectionImage> GetById(int id)
        {
            return new SuccessDataResult<SectionImage>(_sectionImageDal.Get(s=>s.Id==id));
        }
        [CacheAspect]
        public IDataResult<List<SectionImage>> GetImagesBySectionId(int sectionId)
        {
            return new SuccessDataResult<List<SectionImage>>(_sectionImageDal.GetAll(i=>i.SectionId==sectionId));
        }
        [SecuredOperation("admin")]
        public IResult Update(IFormFile formFile, SectionImage sectionImage)
        {
            sectionImage.ImagePath = _fileHelper.Update(formFile, $"{ Paths.ImagesSectionPath + sectionImage.ImagePath }", Paths.ImagesSectionPath);
            _sectionImageDal.Update(sectionImage);
            return new SuccessResult();
        }
    }
}
