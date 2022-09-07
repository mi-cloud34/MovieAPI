using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Movie:IEntity
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }=DateTime.Now;
        public decimal MovieBudget  { get; set; }
        public string Description { get; set; }
        public int   GenreId { get; set; }
        public int CategoryId { get; set; }
        public int ActorId { get; set; }
        public int LanguageId { get; set; }
        public int TranslateLanguageId { get; set; }
        public int CountryId { get; set; }
        public int PointId { get; set; }
        public int DirectorId { get; set; }
    }
}
