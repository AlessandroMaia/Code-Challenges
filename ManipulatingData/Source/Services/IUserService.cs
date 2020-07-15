using System.Collections.Generic;
using Source.Models;

namespace Source.Services
{
    public interface IUserService
    {
        User FindById(int id);
        IList<User> FindByAccelerationName(string name);
        IList<User> FindByCompanyId(int companyId);
        User Save(User user);
    }
}
