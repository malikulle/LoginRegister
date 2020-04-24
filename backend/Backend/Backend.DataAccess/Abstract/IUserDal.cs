using Backend.Core.DataAccess;
using Backend.Entities.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
