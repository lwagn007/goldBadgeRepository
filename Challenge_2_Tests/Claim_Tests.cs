using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challenge_2;

namespace Challenge_2_Tests
{
    [TestClass]
    public class Claim_Tests
    {
        private ClaimQueueRepository _claimRepo;

        [TestInitialize]
        public void Arrange()
        {
            _claimRepo = new ClaimQueueRepository();
        }

        [TestMethod]
        public void ClaimQueue_AddClaimToQueue_ShouldIncreaseByOne()
        {
            //-- Arrange
             Claim claim = new Claim(32978, "house", "fire", 3879, DateTime.Now, DateTime.Now);
            _claimRepo.AddClaimToQueue(claim);

            //-- Act
            var actual = _claimRepo.GetClaims().Count;
            var expected = 1;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimQueue_RemoveClaimFromQueue_ShouldBeOne()
        {
            //-- Arrange
            Claim claim = new Claim(32978, "house", "fire", 3879, DateTime.Now, DateTime.Now);
            Claim claimOne = new Claim(3298, "house", "sunk", 3289, DateTime.Now, DateTime.Now);
            _claimRepo.AddClaimToQueue(claim);
            _claimRepo.AddClaimToQueue(claimOne);
            _claimRepo.RemoveClaimFromQueue(claim);

            //-- Act
            var actual = _claimRepo.GetClaims().Count;
            var expected = 1;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimQueue_PeekAtQueue_ShouldPullOneItem()
        {
            //-- Arrange
            Claim claim = new Claim(32978, "house", "fire", 3879, DateTime.Now, DateTime.Now);
            Claim claimOne = new Claim(3298, "house", "sunk", 3289, DateTime.Now, DateTime.Now);
            _claimRepo.AddClaimToQueue(claim);
            _claimRepo.AddClaimToQueue(claimOne);

            //-- Act
            var actual = _claimRepo.GetClaims().Peek();
            var expected = claim;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
