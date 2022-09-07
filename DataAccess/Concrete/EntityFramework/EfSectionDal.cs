using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSectionDal : EfEntityRepositoryBase<Section,MovieDbContext>, ISectionDal
    {
        public List<SectionDetailsDto> GetSectionDetail()
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from section in context.Sections
                             join genre in context.SectionGenres
                             on section.GenreId equals genre.Id
                             join director in context.SectionDirectors
                             on section.DirectorId equals director.Id
                             join language in context.SectionLanguages
                             on section.LanguageId equals language.Id
                             join point in context.SectionPoints
                             on section.PointId equals point.Id
                             join actor in context.SectionActors
                             on section.ActorId equals actor.Id
                             join translateLanguage in context.SectionTranslateLanguages
                             on section.TranslateLanguageId equals translateLanguage.Id
                             join category in context.Categories
                             on section.CategoryId equals category.Id
                             join country in context.SectionCountrys
                             on section.CountryId equals country.Id
                             select new SectionDetailsDto
                             {
                                 SectionId = section.Id,
                                 SectionName = section.SectionName,
                                 GenreName = genre.GenreName,
                                 SectionBudget = section.SectionBudget,
                                 Description = section.Description,
                                 ActorName = actor.ActorName,
                                 CategoryName = category.CategoryName,
                                 CountryName = country.CountryName,
                                 DirectorName = director.DirectorName,
                                 LanguageName = language.LanguageName,
                                 Point = Convert.ToDecimal(point.Point),
                                 ReleaseDate = Convert.ToDateTime(section.ReleaseDate),
                                 TranslateLanguageName = translateLanguage.TranslateLanguageName,
                                 ImagePath = (from image in context.SectionImages where image.SectionId.Equals(section.Id) select image.ImagePath ?? new String('-', 20)).ToList()




                             };
                return result.ToList();
            }


        }

        public List<SectionDetailsDto> GetSectionDetailGenreId(int genreId)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from section in context.Sections
                             join genre in context.SectionGenres
                             on section.GenreId equals genre.Id
                             where genre.Id == genreId
                             select new SectionDetailsDto
                             {
                                 SectionId = section.Id,
                                 SectionName = section.SectionName,
                                 GenreName = genre.GenreName,
                                 SectionBudget = section.SectionBudget,
                                 Description = section.Description,
                                 ReleaseDate = Convert.ToDateTime(section.ReleaseDate),
                                ImagePath = (from image in context.SectionImages where image.SectionId.Equals(section.Id) select image.ImagePath ?? new String('-', 20)).ToList()




                             };
                return result.ToList();
            }


        }

        public List<SectionDetailsDto> GetSectionDetailsByCountryId(int countryId)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from section in context.Sections
                             join country in context.SectionCountrys
                             on section.CountryId equals country.Id
                             where country.Id == countryId
                             select new SectionDetailsDto
                             {
                                 SectionId = section.Id,
                                 SectionName = section.SectionName,
                                 SectionBudget = section.SectionBudget,
                                 Description = section.Description,
                                 CountryName = country.CountryName,
                                 ReleaseDate = Convert.ToDateTime(section.ReleaseDate),
                                 ImagePath = (from image in context.SectionImages where image.SectionId.Equals(section.Id) select image.ImagePath ?? new String('-', 20)).ToList()




                             };
                return result.ToList();
            }


        }

        public List<SectionDetailsDto> GetSectionDetailsByDirectorId(int directorId)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from section in context.Sections
                             join director in context.SectionDirectors
                             on section.DirectorId equals director.Id
                             select new SectionDetailsDto
                             {
                                 SectionId = section.Id,
                                 SectionName = section.SectionName,
                                 SectionBudget = section.SectionBudget,
                                 Description = section.Description,
                                 DirectorName = director.DirectorName,
                                 ReleaseDate = Convert.ToDateTime(section.ReleaseDate),
                                 ImagePath = (from image in context.SectionImages where image.SectionId.Equals(section.Id) select image.ImagePath ?? new String('-', 20)).ToList()

                       };
                return result.ToList();
            }


        }

        public List<SectionDetailsDto> GetSectionDetailsById(int id)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from section in context.Sections
                             join genre in context.SectionGenres
                             on section.GenreId equals genre.Id
                             join director in context.SectionDirectors
                             on section.DirectorId equals director.Id
                             join language in context.SectionLanguages
                             on section.LanguageId equals language.Id
                             join point in context.SectionPoints
                             on section.PointId equals point.Id
                             join actor in context.SectionActors
                             on section.ActorId equals  actor.Id 
                             join translateLanguage in context.SectionTranslateLanguages
                             on section.TranslateLanguageId equals translateLanguage.Id
                             join category in context.Categories
                             on section.CategoryId equals category.Id
                             join country in context.SectionCountrys
                             on section.CountryId equals country.Id
                             where section.Id == id
                             select new SectionDetailsDto
                             {
                                 SectionId = section.Id,
                                 SectionName = section.SectionName,
                                 GenreName = genre.GenreName,
                                 SectionBudget = section.SectionBudget,
                                 Description = section.Description,
                                 ActorName = actor.ActorName,
                                 CategoryName = category.CategoryName,
                                 CountryName = country.CountryName,
                                 DirectorName = director.DirectorName,
                                 LanguageName = language.LanguageName,
                                 Point = Convert.ToDecimal(point.Point),
                                 ReleaseDate = Convert.ToDateTime(section.ReleaseDate),
                                 TranslateLanguageName = translateLanguage.TranslateLanguageName,
                                 ImagePath = (from image in context.SectionImages where image.SectionId.Equals(section.Id) select image.ImagePath ?? new String('-', 20)).ToList()




                             };
                return result.ToList();
            }


        }

        public List<SectionDetailsDto> GetSectionDetailsByLanguageId(int languageId)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from section in context.Sections
                             join language in context.SectionLanguages
                             on section.LanguageId equals language.Id
                             where language.Id == languageId
                             select new SectionDetailsDto
                             {
                                 SectionId = section.Id,
                                 SectionName = section.SectionName,
                                 SectionBudget = section.SectionBudget,
                                 Description = section.Description,
                                 LanguageName = language.LanguageName,
                                 ReleaseDate = Convert.ToDateTime(section.ReleaseDate),
                                  ImagePath = (from image in context.SectionImages where image.SectionId.Equals(section.Id) select image.ImagePath ?? new String('-', 20)).ToList()




                             };
                return result.ToList();
            }


        }

        public List<SectionDetailsDto> GetSectionDetailsByPointId(int pointId)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from section in context.Sections
                            join point in context.SectionPoints
                             on section.PointId equals point.Id
                             where point.Id == pointId
                             select new SectionDetailsDto
                             {
                                 SectionId = section.Id,
                                 SectionName = section.SectionName,
                                SectionBudget = section.SectionBudget,
                                 Description = section.Description,
                                 Point = Convert.ToDecimal(point.Point),
                                 ReleaseDate = Convert.ToDateTime(section.ReleaseDate),
                                 ImagePath = (from image in context.SectionImages where image.SectionId.Equals(section.Id) select image.ImagePath ?? new String('-', 20)).ToList()




                             };
                return result.ToList();
            }


        }
    }
}
