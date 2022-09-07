using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentSectionService
    {
        IResult Add(CommentSection commentSection);
        IResult Delete(CommentSection commentSection);
        IResult Update(CommentSection commentSection);
        IDataResult<List<CommentSection>> GetAll();
        IDataResult<CommentSection> GetById(int id);
       IDataResult<List<SectionCommentDetailDto>> GetSectionCommentDetail();
        IDataResult<List<SectionCommentDetailDto>> GetSectionCommentDetailById(int id);
        IDataResult<List<SectionCommentDetailDto>> GetSectionCommentDetailByUserId(int userId);
        IDataResult<List<SectionCommentDetailDto>> GetSectionCommentDetailBySectionId(int sectionId);
    }
}
