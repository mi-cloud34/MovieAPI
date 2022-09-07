using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class MovieDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=DESKTOP-DMF3LQD;Database=MovieDB;Trusted_Connection=True;");
           // optionsBuilder.UseSqlServer("Data Source=DESKTOP-DMF3LQD;Initial Catalog=MovieDB;Integrated Security=True");
        }
        public DbSet<AddFavoriteMovie> AddFavoriteMovies { get; set; }
        public DbSet<AddFavoriteSection> AddFavoriteSections { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CommentSection> CommentSections { get; set; }
        public DbSet<CommentMovie> CommentMovies { get; set; }
        public DbSet<LikeMovie> LikeMovies { get; set; }
        public DbSet<LikeSection> LikeSections { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieCountry> MovieCountrys { get; set; }
        public DbSet<MovieDirector> MovieDirectors { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieImage> MovieImages { get; set; }
        public DbSet<MovieLanguage> MovieLanguages { get; set; }
        public DbSet<MoviePoint> MoviePoints { get; set; }
        public DbSet<MovieTranslateLanguage> MovieTranslateLanguages { get; set; }
        public DbSet<MovieVideo> MovieVideos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<SectionImage> SectionImages { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionActor> SectionActors { get; set; }
        public DbSet<SectionCountry> SectionCountrys { get; set; }
        public DbSet<SectionDirector> SectionDirectors { get; set; }
        public DbSet<SectionGenre> SectionGenres { get; set; }
        public DbSet<SectionLanguage> SectionLanguages { get; set; }
        public DbSet<SectionPoint> SectionPoints { get; set; }
        public DbSet<UserImage> UserImages { get; set; }    
        public DbSet<SectionTranslateLanguage>SectionTranslateLanguages { get; set; }
        public DbSet<SectionVideo> SectionVideos { get; set; }
       
    }
}
