using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class SectionDirector:IEntity
    {
        public int Id { get; set; }
        public string DirectorName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
