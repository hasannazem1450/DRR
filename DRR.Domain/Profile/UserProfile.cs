using DRR.Domain.Identity;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Domain.Profile
{
    public class UserProfile : Entity<int>
    {
        public UserProfile(string userId, int smeProfileId)
        {
            //TODO:Create Guard
            UserId = userId;
            SmeProfileId = smeProfileId;
        }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int SmeProfileId { get; set; }
        public SmeProfile SmeProfile { get; set; }

    }

}
