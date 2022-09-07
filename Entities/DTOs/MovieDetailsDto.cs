using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class MovieDetailsDto:IDto
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public String GenreName { get; set; }
        public String CategoryName { get; set; }
        public String ActorName { get; set; }
        public string LanguageName { get; set; }
        public string TranslateLanguageName { get; set; }
        public decimal Point { get; set; }
        public string DirectorName  { get; set; }
        public string CountryName { get; set; }

        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public decimal MovieBudget { get; set; }
        public List<String> ImagePath { get; set; }
      
        
    }
}
