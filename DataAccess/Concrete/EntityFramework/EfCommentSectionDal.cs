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
    public class EfCommentSectionDal : EfEntityRepositoryBase<CommentSection, MovieDbContext>, ICommentSectionDal
    {
        public List<SectionCommentDetailDto> GetSectionCommentDetail()
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from commentSection in context.CommentSections
                             join user in context.Users
                             on commentSection.UserId equals user.Id
                             join section in context.Sections
                             on commentSection.SectionId equals section.Id

                             select new SectionCommentDetailDto
                             {
                                  CommentId = commentSection.Id,
                                  Comment = commentSection.Comment,
                                 FirstName = user.FirstName,
                                  SectionName = section.SectionName,
                                 Date = commentSection.Date,
                             };
                return result.ToList();
            }


        }

        public List<SectionCommentDetailDto> GetSectionCommentDetailById(int id)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from commentSection in context.CommentSections
                             join user in context.Users
                             on commentSection.UserId equals user.Id
                             join section in context.Sections
                             on commentSection.SectionId equals section.Id
                             where commentSection.Id == id
                             select new SectionCommentDetailDto
                             {
                                 CommentId = commentSection.Id,
                                 Comment = commentSection.Comment,
                                 FirstName = user.FirstName,
                                 SectionName = section.SectionName,
                                 Date = commentSection.Date,
                             };
                return result.ToList();
            }


        }

        public List<SectionCommentDetailDto> GetSectionCommentDetailBySectionId(int sectionId)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from commentSection in context.CommentSections
                             join section in context.Sections
                             on commentSection.SectionId equals section.Id
                             where section.Id == sectionId   
                             select new SectionCommentDetailDto
                             {
                                 CommentId = commentSection.Id,
                                 Comment = commentSection.Comment,
                                 SectionName = section.SectionName,
                                 Date = commentSection.Date,
                             };
                return result.ToList();
            }


        }

        public List<SectionCommentDetailDto> GetSectionCommentDetailByUserId(int userId)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from commentSection in context.CommentSections
                             join user in context.Users
                             on commentSection.UserId equals user.Id
                             where user.Id == userId
                             select new SectionCommentDetailDto
                             {
                                 CommentId = commentSection.Id,
                                 Comment = commentSection.Comment,
                                 FirstName = user.FirstName,
                                 Date = commentSection.Date,
                             };
                return result.ToList();
            }


        }
    }
}
