using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class AccelerationService : IAccelerationService
    {
        private CodenationContext _context;

        public AccelerationService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Acceleration> FindByCompanyId(int companyId)
        {
            return _context
                .Candidates
                .Where(x => x.CompanyId.Equals(companyId))
                .Select(x => x.Acceleration)
                .Distinct()
                .ToList();
        }

        public Acceleration FindById(int id)
        {
            return _context
                .Accelerations
                .Where(x => x.Id.Equals(id))
                .FirstOrDefault();
        }

        public Acceleration Save(Acceleration acceleration)
        {
            if (acceleration.Id.Equals(0))
            {
                _context
                    .Accelerations
                    .Add(acceleration);
                _context
                    .SaveChanges();
                return acceleration;
            }
            else
            {
                _context
                    .Entry(acceleration)
                    .State = EntityState.Modified;
                _context.SaveChanges();
                return acceleration;
            }
        }
    }
}
