using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolver.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AddFavoriteMovieManager>().As<IAddFavoriteMovieService>().SingleInstance();
            builder.RegisterType<EfAddFavoriteMovieDal>().As<IAddFavoriteMovieDal>().SingleInstance();

            builder.RegisterType<AddFavoriteSectionManager>().As<IAddFavoriteMovieService>().SingleInstance();
            builder.RegisterType<EfAddFavoriteSectionDal>().As<IAddFavoriteSectionDal>().SingleInstance();

            builder.RegisterType<MovieManager>().As<IMovieService>().SingleInstance();
            builder.RegisterType<EfMovieDal>().As<IMovieDal>().SingleInstance();

            builder.RegisterType<CommentMovieManager>().As<ICommentMovieService>().SingleInstance();
            builder.RegisterType<EfCommentMovieDal>().As<ICommentMovieDal>().SingleInstance();

            builder.RegisterType<LikeMovieManager>().As<LikeMovieManager>().SingleInstance();
            builder.RegisterType<EfLikeMovieDal>().As<ILikeMovieDal>().SingleInstance();

            builder.RegisterType<SectionManager>().As<ISectionService>().SingleInstance();
            builder.RegisterType<EfSectionDal>().As<ISectionDal>().SingleInstance();

            builder.RegisterType<CommentSectionManager>().As<ICommentSectionService>().SingleInstance();
            builder.RegisterType<EfCommentSectionDal>().As<ICommentSectionDal>().SingleInstance();

            builder.RegisterType<LikeSectionManager>().As<LikeSectionManager>().SingleInstance();
            builder.RegisterType<EfLikeSectionDal>().As<ILikeSectionDal>().SingleInstance();

            builder.RegisterType<MovieActorManager>().As<IMovieActorService>().SingleInstance();
            builder.RegisterType<EfMovieActorDal>().As<IMovieActorDal>().SingleInstance();

            builder.RegisterType<MovieCountryManager>().As<IMovieCountryService>().SingleInstance();
            builder.RegisterType<EfMovieCountryDal>().As<IMovieCountryDal>().SingleInstance();

            builder.RegisterType<MovieGenreManager>().As<IMovieGenreService>().SingleInstance();
            builder.RegisterType<EfMovieGenreDal>().As<IMovieGenreDal>().SingleInstance();

            builder.RegisterType<MoviePointManager>().As<IMoviePointService>().SingleInstance();
            builder.RegisterType<EfMoviePointDal>().As<IMoviePointDal>().SingleInstance();

            builder.RegisterType<MovieDirectorManager>().As<IMovieDirectorService>().SingleInstance();
            builder.RegisterType<EfMovieDirectorDal>().As<IMovieDirectorDal>().SingleInstance();

            builder.RegisterType<MovieImageManager>().As<IMovieImageService>().SingleInstance();
            builder.RegisterType<EfMovieImageDal>().As<IMovieImageDal>().SingleInstance();

            builder.RegisterType<MovieVideoManager>().As<IMovieVideoService>().SingleInstance();
            builder.RegisterType<EfMovieVideoDal>().As<IMovieVideoDal>().SingleInstance();

            builder.RegisterType<MovieTranslateLanguageManager>().As<IMovieTranslateLanguageService>().SingleInstance();
            builder.RegisterType<EfMovieTranslateLanguageDal>().As<IMovieTranslateLanguageDal>().SingleInstance();



            builder.RegisterType<SectionActorManager>().As<ISectionActorService>().SingleInstance();
            builder.RegisterType<EfSectionActorDal>().As<ISectionActorDal>().SingleInstance();

            builder.RegisterType<SectionCountryManager>().As<ISectionCountryService>().SingleInstance();
            builder.RegisterType<EfSectionCountryDal>().As<ISectionCountryDal>().SingleInstance();

            builder.RegisterType<SectionGenreManager>().As<ISectionGenreService>().SingleInstance();
            builder.RegisterType<EfSectionGenreDal>().As<ISectionGenreDal>().SingleInstance();

            builder.RegisterType<SectionPointManager>().As<ISectionPointService>().SingleInstance();
            builder.RegisterType<EfSectionPointDal>().As<ISectionPointDal>().SingleInstance();

            builder.RegisterType<SectionDirectorManager>().As<ISectionDirectorService>().SingleInstance();
            builder.RegisterType<EfSectionDirectorDal>().As<ISectionDirectorDal>().SingleInstance();

            builder.RegisterType<SectionImageManager>().As<ISectionImageService>().SingleInstance();
            builder.RegisterType<EfSectionImageDal>().As<ISectionImageDal>().SingleInstance();

            builder.RegisterType<SectionVideoManager>().As<ISectionVideoService>().SingleInstance();
            builder.RegisterType<EfSectionVideoDal>().As<ISectionVideoDal>().SingleInstance();

            builder.RegisterType<SectionTranslateLanguageManager>().As<ISectionTranslateLanguageService>().SingleInstance();
            builder.RegisterType<EfSectionTranslateLanguageDal>().As<ISectionTranslateLanguageDal>().SingleInstance();

            builder.RegisterType<SectionLanguageManager>().As<ISectionLanguageService>().SingleInstance();
            builder.RegisterType<EfSectionLanguageDal>().As<ISectionLanguageDal>().SingleInstance();

            builder.RegisterType<MovieLanguageManager>().As<IMovieLanguageService>().SingleInstance();
            builder.RegisterType<EfMovieLanguageDal>().As<IMovieLanguageDal>().SingleInstance();


            builder.RegisterType<FileHelperManager>().As<IFileHelper>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>().SingleInstance();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>().SingleInstance();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().SingleInstance();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().SingleInstance();

          

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                });
        }
    }
}
