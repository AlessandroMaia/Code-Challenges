using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        private CodenationContext _context;
        public ChallengeService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            return _context
                .Candidates
                .Where(x => x.AccelerationId.Equals(accelerationId) && x.UserId.Equals(userId))
                .Select(x => x.Acceleration.Challenge)
                .Distinct()
                .ToList();
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            if (challenge.Id.Equals(0))
            {
                _context
                    .Challenges
                    .Add(challenge);
                _context
                    .SaveChanges();
                return challenge;
            }
            else
            {
                _context
                    .Entry(challenge)
                    .State = EntityState.Modified;
                _context.SaveChanges();
                return challenge;
            }
        }
    }
}