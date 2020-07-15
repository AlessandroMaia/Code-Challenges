using System.Collections.Generic;
using Source.Models;

namespace Source.Services
{
    public interface IAccelerationService
    {
        Acceleration FindById(int id);
        IList<Acceleration> FindByCompanyId(int companyId);
        Acceleration Save(Acceleration acceleration);
    }
}
