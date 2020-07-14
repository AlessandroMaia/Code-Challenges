using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        private CodenationContext _context;
        public SubmissionService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
            return _context
                .Submissions
                .Where(x => x.User.Candidates.Any(y => y.AccelerationId.Equals(accelerationId)) && x.ChallengeId.Equals(challengeId))
                .Select(x => x)
                .ToList();
                
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            return _context
                .Submissions
                .Where(x => x.ChallengeId.Equals(challengeId))
                .Select(x => x.Score)
                .OrderByDescending(x => x)
                .FirstOrDefault();
        }

        public Submission Save(Submission submission)
        {
            var existsSubmission = _context
                .Submissions
                .Any(x => x.Equals(submission));

            if (!existsSubmission)
            {
                _context
                    .Submissions
                    .Add(submission);
                _context
                    .SaveChanges();
                return submission;
            }
            else
            {
                _context.SaveChanges();
                return submission;
            }
        }
    }
}
