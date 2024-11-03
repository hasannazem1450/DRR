using DRR.Domain.Profile;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Domain.Finance
{
    public class Wallet : Entity<int>
    {
        public Wallet(int userId, decimal amount)
        {

            UserId = userId;
            Amount = amount;
            
        }

        public int Id { get; set; }

        public int UserId { get; set; }
        public decimal Amount { get; set; }
        


        public UserProfile UserProfile { get; set; }
        


    }

}
