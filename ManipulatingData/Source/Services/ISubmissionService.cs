using System.Collections.Generic;
using Source.Models;

namespace Source.Services
{
    public interface ISubmissionService
    {
        decimal FindHigherScoreByChallengeId(int challengeId);
        IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId);
        Submission Save(Submission submission);
    }
}
