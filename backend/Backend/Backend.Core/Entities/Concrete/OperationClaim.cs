using Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Entities.Entities.Concrete
{
    public class OperationClaim : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
