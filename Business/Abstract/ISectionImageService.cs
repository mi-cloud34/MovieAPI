using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISectionImageService
    {
        IResult Add(IFormFile formFile,SectionImage sectionImage );
        IResult Delete(SectionImage sectionImage);
        IResult Update(IFormFile formFile,SectionImage sectionImage);
        IDataResult<List<SectionImage>> GetAll();
        IDataResult<SectionImage> GetById(int id);
        IDataResult<List<SectionImage>> GetImagesBySectionId(int sectionId);
    }
}
