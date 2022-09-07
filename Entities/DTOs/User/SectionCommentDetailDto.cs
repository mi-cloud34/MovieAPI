using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.User
{
    public class SectionCommentDetailDto:IDto
    {
        public int CommentId { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public string FirstName { get; set; }
        public string SectionName { get; set; }
    }
}
