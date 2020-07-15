using System.Collections.Generic;
using Source.Models;

namespace Source.Services
{
    public interface ICandidateService
    {
        Candidate FindById(int userId, int accelerationId, int companyId);
        IList<Candidate> FindByCompanyId(int companyId);
        IList<Candidate> FindByAccelerationId(int accelerationId);
        Candidate Save(Candidate user);
    }
}
