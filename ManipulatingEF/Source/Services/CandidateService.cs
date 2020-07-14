using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class CandidateService : ICandidateService
    {
        private CodenationContext _context;
        public CandidateService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Candidate> FindByAccelerationId(int accelerationId)
        {
            return _context
                .Candidates
                .Where(x => x.AccelerationId.Equals(accelerationId))
                .Distinct()
                .ToList();
        }

        public IList<Candidate> FindByCompanyId(int companyId)
        {
            return _context
                .Candidates
                .Where(x => x.CompanyId.Equals(companyId))
                .Distinct()
                .ToList();
        }

        public Candidate FindById(int userId, int accelerationId, int companyId)
        {
            return _context
                .Candidates
                .Where(x => x.UserId.Equals(userId) && x.AccelerationId.Equals(accelerationId) && x.CompanyId.Equals(companyId))
                .FirstOrDefault();
        }

        public Candidate Save(Candidate candidate)
        {
            var existsCandidate = _context
                .Candidates
                .Any(x => x.UserId.Equals(candidate.UserId) && x.AccelerationId.Equals(candidate.AccelerationId) && x.CompanyId.Equals(candidate.CompanyId));

            if (!existsCandidate)
            {
                _context
                    .Candidates
                    .Add(candidate);
                _context
                    .SaveChanges();
                return candidate;
            }
            else
            {
                _context.SaveChanges();
                return candidate;
            }
        }
    }
}
