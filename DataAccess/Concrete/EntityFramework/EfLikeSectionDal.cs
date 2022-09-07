using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLikeSectionDal : EfEntityRepositoryBase<LikeSection, MovieDbContext>, ILikeSectionDal
    {
        public List<SectionLikeDetailDto> GetSectionLikeDetail()
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from likeSection in context.LikeSections
                             join user in context.Users
                             on likeSection.UserId equals user.Id
                             join section in context.Sections
                             on likeSection.SectionId equals section.Id

                             select new SectionLikeDetailDto
                             {
                               LikeId= likeSection.Id,
                                Like=likeSection.Like,
                                 FirstName=user.FirstName,
                                 SectionName=section.SectionName,
                                 Date=likeSection.Date,
                             };
                return result.ToList();
            }


        }

        public List<SectionLikeDetailDto> GetSectionLikeDetailsById(int id)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from likeSection in context.LikeSections
                             join user in context.Users
                             on likeSection.UserId equals user.Id
                             join section in context.Sections
                             on likeSection.SectionId equals section.Id
                             where likeSection.Id == id
                             select new SectionLikeDetailDto
                             {
                                 LikeId = likeSection.Id,
                                 Like = likeSection.Like,
                                 FirstName = user.FirstName,
                                 SectionName = section.SectionName,
                                 Date = likeSection.Date,
                             };
                return result.ToList();
            }


        }

        public List<SectionLikeDetailDto> GetSectionLikeDetailsByMovieId(int sectionId)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from likeSection in context.LikeSections
                             join section in context.Sections
                             on likeSection.SectionId equals section.Id
                            where section.Id == sectionId
                             select new SectionLikeDetailDto
                             {
                                 LikeId = likeSection.Id,
                                 Like = likeSection.Like,
                                 SectionName = section.SectionName,
                                 Date = likeSection.Date,
                             };
                return result.ToList();
            }


        }

        public List<SectionLikeDetailDto> GetSectionLikeDetailsByUserId(int userId)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from likeSection in context.LikeSections
                             join user in context.Users
                             on likeSection.UserId equals user.Id
                            where user.Id == userId
                             select new SectionLikeDetailDto
                             {
                                 LikeId = likeSection.Id,
                                 Like = likeSection.Like,
                                 FirstName = user.FirstName,
                                 Date = likeSection.Date,
                             };
                return result.ToList();
            }


        }
    }
}
