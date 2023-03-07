using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Requests.Auth;
using Business.Requests.Users;
using Business.Responses.Auths;
using Business.Responses.Users;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IMapper _mapper;
        private AuthBusinessRules _authBusinessRules;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IMapper mapper, AuthBusinessRules authBusinessRules)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
            _authBusinessRules = authBusinessRules;
        }

        public AccessResponse Register(RegisterUserRequest register)
        {
            byte[] passwordHash, passwordSalt;
            CreateUserRequest createUserRequest = _mapper.Map<CreateUserRequest>(register);

            HashingHelper.CreatePasswordHash(register.Password, out passwordHash, out passwordSalt);
            createUserRequest.PasswordHash = passwordHash;
            createUserRequest.PasswordSalt = passwordSalt;
            createUserRequest.Status = true;

            _userService.Add(createUserRequest);

            GetUserResponse getUserResponse = _userService.GetByMail(register.Email);
            User user = _mapper.Map<User>(getUserResponse);
            AccessToken accessToken = CreateAccessToken(user);

            AccessResponse response = new() { AccessToken = accessToken };
            return response;
        }

        public AccessResponse Login(LoginUserRequest login)
        {

            User user = _userService.GetUserByMail(login.Email);
            _authBusinessRules.CheckIfPasswordMatch(login.Password, user.PasswordHash, user.PasswordSalt);

            AccessResponse response = new() { AccessToken = CreateAccessToken(user) };
            return response;
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public AccessToken CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return accessToken;
        }
    }
}
