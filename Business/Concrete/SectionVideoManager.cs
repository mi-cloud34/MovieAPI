using Business.Abstract;
using Business.Aspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
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
    public class SectionVideoManager:ISectionVideoService
    {
        public IFileHelper _fileHelper;
        public ISectionVideoDal _sectionVideoDal;
        public SectionVideoManager(IFileHelper fileHelper, ISectionVideoDal sectionVideoDal) : this(sectionVideoDal)
        {
            _fileHelper = fileHelper;
        }
        public SectionVideoManager(ISectionVideoDal sectionVideoDal)
        {
            _sectionVideoDal = sectionVideoDal;
        }
        [SecuredOperation("admin")]
        public IResult Add(IFormFile formFile, SectionVideo sectionVideo)
        {

            sectionVideo.VideoPath = _fileHelper.Upload(formFile, Paths.SectionVideosPath);
            _sectionVideoDal.Add(sectionVideo);
            return new SuccessResult();
        }
        [CacheRemoveAspect("ISectionVideoService.Get")]
        public IResult Delete(SectionVideo sectionVideo)
        {
            _fileHelper.Delete($"{ Paths.SectionVideosPath + sectionVideo.VideoPath }");
            _sectionVideoDal.Delete(sectionVideo);
            return new SuccessResult();
        }

        public IDataResult<List<SectionVideo>> GetAll()
        {
            return new SuccessDataResult<List<SectionVideo>>(_sectionVideoDal.GetAll());
        }

        public IDataResult<SectionVideo> GetById(int id)
        {
            return new SuccessDataResult<SectionVideo>(_sectionVideoDal.Get(i => i.Id == id));
        }

        public IDataResult<List<SectionVideo>> GetVideoBySectionVideoId(int sectionVideoId)
        {
            return new SuccessDataResult<List<SectionVideo>>(_sectionVideoDal.GetAll(m => m.SectionId == sectionVideoId));
        }

        public IResult Update(IFormFile formFile, SectionVideo sectionVideo)
        {
            sectionVideo.VideoPath = _fileHelper.Update(formFile, $"{ Paths.SectionVideosPath + sectionVideo.VideoPath }", Paths.SectionVideosPath);
            _sectionVideoDal.Update(sectionVideo);
            return new SuccessResult();
        }

      
    }
}
