using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class SectionImage : IEntity
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public string? ImagePath { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
