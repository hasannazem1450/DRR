using DRR.Domain.Profile;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Domain.Finance
{
    public class Wallet : Entity<int>
    {
        public Wallet(int? parentId ,int smeProfileId, decimal amount)
        {
            ParentId = parentId;
            SmeProfileId = smeProfileId;
            Amount = amount;
            
        }

        public void Update(int? parentId, int smeProfileId, decimal amount)
        {
            ParentId = parentId;
            SmeProfileId = smeProfileId;
            Amount = amount;

        }


        public int? ParentId { get; set; }
        public decimal Amount { get; set; }



        public int SmeProfileId { get; set; }
        public SmeProfile SmeProfile { get; protected set; }



    }

}
