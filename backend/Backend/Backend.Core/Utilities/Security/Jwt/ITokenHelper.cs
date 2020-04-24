using Backend.Entities.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user , List<OperationClaim> operationClaims);
    }
}
