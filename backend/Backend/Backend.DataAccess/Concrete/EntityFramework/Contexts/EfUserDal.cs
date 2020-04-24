using Backend.Core.DataAccess.EntityFramework;
using Backend.DataAccess.Abstract;
using Backend.Entities.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.DataAccess.Concrete.EntityFramework.Contexts
{
    public class EfUserDal : EfEntityRepositoryBase<User, BackendContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using(var context = new BackendContext())
            {
                return context.UserOperationClaims.Include(x => x.User).Include(x => x.OperationClaim)
                    .Where(x=>x.UserId == user.Id)
                    .Select(x=>x.OperationClaim).ToList();
            }
        }
    }
}
