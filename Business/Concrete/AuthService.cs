using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Hashing;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;

namespace Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthService(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccesToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accesToken = _tokenHelper.CreateToken(user, claims);
            return new SuccesDataResult<AccesToken>(accesToken, Messages.Succes);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email);
            if (userToCheck == null)
                return new ErrorDataResult<User>(Messages.UserNotFound);

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                return new ErrorDataResult<User>(Messages.PasswordError);

            return new SuccesDataResult<User>(userToCheck, Messages.Succes);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.AddClaim(user);
            return new SuccesDataResult<User>(user, Messages.Succes);
        }

        public IResult UserExist(string email)
        {
            if (_userService.GetByEmail(email) != null)
                return new ErrorResult(Messages.UserAlreadyExists);

            return new SuccesResult(Messages.Succes);
        }
    }
}
