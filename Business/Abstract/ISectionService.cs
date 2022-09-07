using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISectionService
    {
        IResult Add(Section section);
        IResult Delete(Section section);
        IResult Update(Section section);
        IDataResult<List<Section>> GetAll();
        IDataResult<Section> GetById(int id);
       IDataResult<List<SectionDetailsDto>> GetSectionDetail();
        IDataResult<List<SectionDetailsDto>> GetSectionDetailsById(int id);
        IDataResult<List<SectionDetailsDto>> GetSectionDetailsByPointId(int pointId);
        IDataResult<List<SectionDetailsDto>> GetSectionDetailsByDirectorId(int directorId);
        IDataResult<List<SectionDetailsDto>> GetSectionDetailGenreId(int genreId);
        IDataResult<List<SectionDetailsDto>> GetSectionDetailsByLanguageId(int languageId);
        IDataResult<List<SectionDetailsDto>> GetSectionDetailsByCountryId(int countryId);
    }
}
