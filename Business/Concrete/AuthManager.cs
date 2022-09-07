using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
  
        public class AuthManager : IAuthService
        {
       public IUserService _userService;
       public ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, "Giriş başarılı" /*Messages.AccessTokenCreated)*/);
        }

        public IDataResult<User> Login(UserForLoginDto? userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, String password)
        {
            HashingHelper.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            User user = new()
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, "Kayıt başarıyla tamamlandı");
        }

        public IResult UserExists(String emailAdress)
        {
            return BusinessRules.Run(CheckUserIfEmailAdress(emailAdress)) is null ?
                new SuccessResult("Kullanıcı mevcut"/*Messages.UserAlreadyExists*/) :
                new ErrorResult();
        }


        private IDataResult<User> CheckUserIfEmailAdress(String emailAdress)
        {
            //mail adresi yoksa null oluyor
            var userToCheck = _userService.GetByMail(emailAdress).Data;
            return userToCheck is not null ?
                new SuccessDataResult<User>(userToCheck) :
                new ErrorDataResult<User>("Kullanıcı bulunamadı"/*Messages.UserNotFound)*/);
        }
        //pass doğrulama çalışmazsa sorun burasıdır static kaldırılır
        private static IResult VerifyPasswordHash(String password, byte[] passwordHash, byte[] passwordSalt)
        {
            return HashingHelper.VerifyPasswordHash(password,
                passwordHash, passwordSalt) ?
                new SuccessResult() :
                new ErrorResult("Parolanız yanlış"/*Messages.PasswordError*/);
        }

    }
}
