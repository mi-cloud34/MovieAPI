using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ISectionDal : IEntityRepository<Section>
    {
        List<SectionDetailsDto> GetSectionDetail();
        List<SectionDetailsDto> GetSectionDetailsById(int id);
        List<SectionDetailsDto> GetSectionDetailsByPointId(int pointId);
        List<SectionDetailsDto> GetSectionDetailsByDirectorId(int directorId);
        List<SectionDetailsDto> GetSectionDetailGenreId(int genreId);
        List<SectionDetailsDto> GetSectionDetailsByLanguageId(int languageId);
        List<SectionDetailsDto> GetSectionDetailsByCountryId(int countryId);
    }
}
