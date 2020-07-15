using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Source.Models;

namespace Source.Services
{
    public class ChallengeService : IChallengeService
    {
        private CodenationContext context;
        public ChallengeService(CodenationContext context)
        {
            this.context = context;
        }

        public IList<Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            return context.Users.
                Where(x => x.Id == userId).
                SelectMany(x => x.Candidates).
                Where(x => x.AccelerationId == accelerationId).
                Select(x => x.Acceleration.Challenge).
                Distinct().
                ToList();
        }

        public Challenge Save(Challenge challenge)
        {
            var state = challenge.Id == 0 ? EntityState.Added : EntityState.Modified;
            context.Entry(challenge).State = state;
            context.SaveChanges();
            return challenge;
        }
    }
}