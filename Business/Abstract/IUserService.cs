using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void AddClaim(User user);
        User GetByEmail(string email);
    }
}
