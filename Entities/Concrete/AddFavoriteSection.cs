using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AddFavoriteSection:IEntity
    {
        public int Id { get; set; }
        public List<Section> SectionId { get; set; }
    }
}
