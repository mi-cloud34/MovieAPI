using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISectionGenreService
    {
        IResult Add(SectionGenre sectionGenre);
        IResult Delete(SectionGenre sectionGenre);
        IResult Update(SectionGenre sectionGenre);
        IDataResult<List<SectionGenre>> GetAll();
        IDataResult<SectionGenre> GetById(int id);
    }
}
