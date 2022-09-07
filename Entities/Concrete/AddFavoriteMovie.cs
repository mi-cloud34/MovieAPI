using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AddFavoriteMovie:IEntity
    {
        public int Id { get; set; }
        public List<Movie> MovieId { get; set; }
    }
}
