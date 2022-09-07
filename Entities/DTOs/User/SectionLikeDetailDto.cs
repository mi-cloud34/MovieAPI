using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.User
{
    public class SectionLikeDetailDto:IDto
    {
        public int LikeId { get; set; }
        public int Like { get; set; }
        public DateTime Date { get; set; }
        public string FirstName { get; set; }
        public string SectionName { get; set; }
    }
}
