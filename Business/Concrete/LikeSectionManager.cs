using Business.Abstract;
using Business.Aspects.Autofac;
using Bussines.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LikeSectionManager : ILikeSectionService
    {
        ILikeSectionDal _likeSectionDal;
        public LikeSectionManager(ILikeSectionDal likeSectionDal)
        {
            _likeSectionDal= likeSectionDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(LikeSectionValidator))]
        [TransactionScopeAspect]
        [PerformanceAspect(5)]
       
        public IResult Add(LikeSection likeSection ,int id)
        {
            var sonuc = _likeSectionDal.Get(l => l.Id == id);
            likeSection.Like += 1;
            likeSection.Id = sonuc.Id;
            _likeSectionDal.Add(likeSection);
            return new SuccessResult();
        }
        [CacheRemoveAspect("ILikeSectionService.Get")]
        public IResult Delete(LikeSection likeSection,int id)
        {
            id = likeSection.Id;
            Console.WriteLine("id:" + id);
            var sonuc = _likeSectionDal.Get(l => l.Id == id);
            // int sonuc2 = _likeMovieDal.Get(l => l.Id == id).Like;
            if (sonuc.Like != 0 && sonuc.Like > 0)
            {
                likeSection.Id = sonuc.Id;
                likeSection.UserId = sonuc.UserId;
                likeSection.SectionId = sonuc.SectionId;
                sonuc.Like -= 1;
            }
            else
            {
                return new ErrorResult();
            }
            // _likeMovieDal.Delete(likeMovie);
            _likeSectionDal.Update(likeSection);
            return new SuccessResult();


        }
        [CacheAspect]
        public IDataResult<List<LikeSection>> GetAll()
        {
            return new SuccessDataResult<List<LikeSection>>(_likeSectionDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<LikeSection> GetById(int id)
        {
            return new SuccessDataResult<LikeSection>(_likeSectionDal.Get(l=>l.Id==id));
        }
        [CacheAspect]
        public IDataResult<List<SectionLikeDetailDto>> GetSectionLikeDetail()
        {
            throw new NotImplementedException();
        }
        [CacheAspect]
        public IDataResult<List<SectionLikeDetailDto>> GetSectionLikeDetailsById(int id)
        {
            throw new NotImplementedException();
        }
        [CacheAspect]
        public IDataResult<List<SectionLikeDetailDto>> GetSectionLikeDetailsByMovieId(int sectonId)
        {
            throw new NotImplementedException();
        }
        [CacheAspect]
        public IDataResult<List<SectionLikeDetailDto>> GetSectionLikeDetailsByUserId(int userId)
        {
            throw new NotImplementedException();
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(LikeSectionValidator))]
        public IResult Update(LikeSection likeSection)
        {
            _likeSectionDal.Update(likeSection);
            return new SuccessResult();
        }
    }
}
