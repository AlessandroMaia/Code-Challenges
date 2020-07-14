using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        private CodenationContext _context;
        public CompanyService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Company> FindByAccelerationId(int accelerationId)
        {
            return _context
                .Candidates
                .Where(x => x.AccelerationId.Equals(accelerationId))
                .Select(x => x.Company)
                .Distinct()
                .ToList();
                
        }

        public Company FindById(int id)
        {
            return _context
                .Companies
                .Where(x => x.Id.Equals(id))
                .FirstOrDefault();
        }

        public IList<Company> FindByUserId(int userId)
        {
            return _context
                .Candidates
                .Where(x => x.UserId.Equals(userId))
                .Select(x => x.Company)
                .Distinct()
                .ToList();
        }

        public Company Save(Company company)
        {
            if (company.Id.Equals(0))
            {
                _context
                    .Companies
                    .Add(company);
                _context
                    .SaveChanges();
                return company;
            }
            else
            {
                _context
                    .Entry(company)
                    .State = EntityState.Modified;
                _context.SaveChanges();
                return company;
            }
        }
    }
}