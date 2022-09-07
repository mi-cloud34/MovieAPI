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
    public interface ILikeSectionService
    {
        IResult Add(LikeSection likeSection,int id);
        IResult Delete(LikeSection likeSection,int id);
        IResult Update(LikeSection likeSection);
        IDataResult<List<LikeSection>> GetAll();
        IDataResult<LikeSection> GetById(int id);
       IDataResult<List<SectionLikeDetailDto>> GetSectionLikeDetail();
        IDataResult<List<SectionLikeDetailDto>> GetSectionLikeDetailsById(int id);
        IDataResult<List<SectionLikeDetailDto>> GetSectionLikeDetailsByUserId(int userId);
        IDataResult<List<SectionLikeDetailDto>> GetSectionLikeDetailsByMovieId(int sectonId);
    }
}
