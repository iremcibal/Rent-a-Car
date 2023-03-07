using Business.Requests.Auth;
using Business.Requests.Users;
using Business.Responses.Auths;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        AccessResponse Register(RegisterUserRequest register);
        AccessResponse Login(LoginUserRequest login);
        IResult UserExists(string email);
        AccessToken CreateAccessToken(User user);

    }
}
