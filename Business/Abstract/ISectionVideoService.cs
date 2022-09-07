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
    public interface ISectionVideoService
    {
        IResult Add(IFormFile formFile, SectionVideo sectionVideo);
        IResult Delete(SectionVideo movieImage);
        IResult Update(IFormFile formFile, SectionVideo sectionVideo);
        IDataResult<SectionVideo> GetById(int id);
        IDataResult<List<SectionVideo>> GetAll();
        IDataResult<List<SectionVideo>> GetVideoBySectionVideoId(int sectionVideoId);
    }
}
