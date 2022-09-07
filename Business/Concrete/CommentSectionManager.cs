using Business.Abstract;
using Business.Aspects.Autofac;
using Bussines.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
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
    public class CommentSectionManager : ICommentSectionService
    {
        ICommentSectionDal _commentSection;
        public CommentSectionManager(ICommentSectionDal commentSectionDal)
        {
            _commentSection = commentSectionDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CommentSectionValidator))]
       
        
        public IResult Add(CommentSection commentSection)
        {
           _commentSection.Add(commentSection);
            return new SuccessResult();
        }

        [CacheRemoveAspect("ICommentSectionService.Get")]
        public IResult Delete(CommentSection commentSection)
        {
           _commentSection.Delete(commentSection);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<CommentSection>> GetAll()
        {
            return new SuccessDataResult<List<CommentSection>>(_commentSection.GetAll());
        }
        [CacheAspect]
        public IDataResult<CommentSection> GetById(int id)
        {
            return new SuccessDataResult<CommentSection>(_commentSection.Get(s=>s.Id==id));
        }
        [CacheAspect]
        public IDataResult<List<SectionCommentDetailDto>> GetSectionCommentDetail()
        {
          return new SuccessDataResult<List<SectionCommentDetailDto>>(_commentSection.GetSectionCommentDetail());
        }
        [CacheAspect]
        public IDataResult<List<SectionCommentDetailDto>> GetSectionCommentDetailById(int id)
        {
          return new SuccessDataResult<List<SectionCommentDetailDto>>(_commentSection.GetSectionCommentDetailById(id));
        }
        [CacheAspect]
        public IDataResult<List<SectionCommentDetailDto>> GetSectionCommentDetailBySectionId(int sectionId)
        {
            return new SuccessDataResult<List<SectionCommentDetailDto>>(_commentSection.GetSectionCommentDetailBySectionId(sectionId));
        }
        [CacheAspect]
        public IDataResult<List<SectionCommentDetailDto>> GetSectionCommentDetailByUserId(int userId)
        {
           return new SuccessDataResult<List<SectionCommentDetailDto>>(_commentSection.GetSectionCommentDetailByUserId(userId));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CommentSectionValidator))]

        public IResult Update(CommentSection commentSection)
        {
            _commentSection.Update (commentSection);
            return new SuccessResult();
        }
    }
}
