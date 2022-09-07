using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Section:IEntity
    {
        public int Id { get; set; }
        public string SectionName { get; set; }
        public string ReleaseDate { get; set; }
        public double SectionBudget { get; set; }
        public string Description { get; set; }
        public int GenreId { get; set; }
        public int CategoryId { get; set; }
        public int ActorId  { get; set; }
        public int LanguageId { get; set; }
        public int TranslateLanguageId { get; set; }
        public int CountryId { get; set; }
        public int PointId { get; set; }
        public int DirectorId { get; set; }
    }
}
