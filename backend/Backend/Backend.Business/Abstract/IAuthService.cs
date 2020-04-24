using System;
using System.Collections.Generic;
using System.Text;
using Backend.Core.Utilities.Results;
using Backend.Core.Utilities.Security.Jwt;
using Backend.Entities.Entities.Concrete;
using Backend.Entities.Entities.Dto;

namespace Backend.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
