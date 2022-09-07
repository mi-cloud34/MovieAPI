using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICommentSectionDal:IEntityRepository<CommentSection>
    {
        List<SectionCommentDetailDto> GetSectionCommentDetail();
        List<SectionCommentDetailDto> GetSectionCommentDetailById(int id);
        List<SectionCommentDetailDto> GetSectionCommentDetailByUserId(int userId);
        List<SectionCommentDetailDto> GetSectionCommentDetailBySectionId(int sectionId);

    }
}
