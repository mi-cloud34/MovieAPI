using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{

    public class CommentMovie : IEntity
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
