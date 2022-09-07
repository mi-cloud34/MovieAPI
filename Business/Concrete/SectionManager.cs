using Business.Abstract;
using Business.Aspects.Autofac;
using Bussines.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SectionManager : ISectionService
    {
        ISectionDal _sectionDal;
        public SectionManager(ISectionDal sectionDal)
        {
            _sectionDal=sectionDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(SectionValidator))]
       
        public IResult Add(Section section)
        {
           _sectionDal.Add(section);
            return new SuccessResult();
        }
        [CacheRemoveAspect("ISectionService.Get")]
        public IResult Delete(Section section)
        {
            _sectionDal.Delete(section);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<Section>> GetAll()
        {
            return new SuccessDataResult<List<Section>>(_sectionDal.GetAll());

        }
        [CacheAspect]
        public IDataResult<Section> GetById(int id)
        {
            return new SuccessDataResult<Section>(_sectionDal.Get(s=>s.Id==id));
        }
        [CacheAspect]
        public IDataResult<List<SectionDetailsDto>> GetSectionDetail()
        {
            return new SuccessDataResult<List<SectionDetailsDto>>(_sectionDal.GetSectionDetail());
        }
        [CacheAspect]
        public IDataResult<List<SectionDetailsDto>> GetSectionDetailGenreId(int genreId)
        {
            return new SuccessDataResult<List<SectionDetailsDto>>(_sectionDal.GetSectionDetailGenreId(genreId));
        }
        [CacheAspect]
        public IDataResult<List<SectionDetailsDto>> GetSectionDetailsByCountryId(int countryId)
        {
            return new SuccessDataResult<List<SectionDetailsDto>>(_sectionDal.GetSectionDetailsByCountryId(countryId));
        }
        [CacheAspect]
        public IDataResult<List<SectionDetailsDto>> GetSectionDetailsByDirectorId(int directorId)
        {
            return new SuccessDataResult<List<SectionDetailsDto>>(_sectionDal.GetSectionDetailsByDirectorId(directorId));
        }
        [CacheAspect]
        public IDataResult<List<SectionDetailsDto>> GetSectionDetailsById(int id)
        {
            return new SuccessDataResult<List<SectionDetailsDto>>(_sectionDal.GetSectionDetailsById(id));
        }
        [CacheAspect]
        public IDataResult<List<SectionDetailsDto>> GetSectionDetailsByLanguageId(int languageId)
        {
            return new SuccessDataResult<List<SectionDetailsDto>>(_sectionDal.GetSectionDetailsByLanguageId(languageId));
        }
        [CacheAspect]
        public IDataResult<List<SectionDetailsDto>> GetSectionDetailsByPointId(int pointId)
        {
            return new SuccessDataResult<List<SectionDetailsDto>>(_sectionDal.GetSectionDetailsByPointId(pointId));
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(SectionValidator))]
        public IResult Update(Section section)
        {
            _sectionDal.Update(section);
            return new SuccessResult();
        }
    }
}
