using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class ClaimQueueRepository
    {
        public ClaimQueueRepository() { }

        private Queue<Claim> _claimRepo = new Queue<Claim>();

        public void AddClaimToQueue(Claim claim)
        {
            _claimRepo.Enqueue(claim);
        }

        public void RemoveClaimFromQueue(Claim claim)
        {
            _claimRepo.Dequeue();
        }

        public Queue<Claim> GetClaims()
        {
            return _claimRepo;
        }
    }
}
