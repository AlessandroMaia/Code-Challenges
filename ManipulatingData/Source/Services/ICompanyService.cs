using System.Collections.Generic;
using Source.Models;

namespace Source.Services
{
    public interface ICompanyService
    {
        Company FindById(int id);
        IList<Company> FindByAccelerationId(int accelerationId);
        IList<Company> FindByUserId(int userId);
        Company Save(Company company);
    }
}
