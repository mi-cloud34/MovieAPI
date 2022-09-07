using Business.Abstract;
using Business.Aspects.Autofac;
using Bussines.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SectionGenreManager : ISectionGenreService
    {
        ISectionGenreDal _sectionGenreDal;
        public SectionGenreManager(ISectionGenreDal sectionGenreDal)
        {
            _sectionGenreDal = sectionGenreDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(SectionGenreValidator))]
        
        public IResult Add(SectionGenre sectionGenre)
        {
            _sectionGenreDal.Add(sectionGenre);
            return new  SuccessResult();
        }
        [CacheRemoveAspect("ISectionGenreService.Get")]
        public IResult Delete(SectionGenre sectionGenre)
        {
           _sectionGenreDal.Delete(sectionGenre);
            return new  SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<SectionGenre>> GetAll()
        {
            return new SuccessDataResult<List<SectionGenre>>(_sectionGenreDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<SectionGenre> GetById(int id)
        {
            return new SuccessDataResult<SectionGenre>(_sectionGenreDal.Get(g=>g.Id==id));
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(SectionGenreValidator))]
        public IResult Update(SectionGenre sectionGenre)
        {
            _sectionGenreDal.Update(sectionGenre);
            return new SuccessResult();
        }
    }
}
