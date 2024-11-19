using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Domain.Profile.Follow
{
    public class FollowProfile : Entity<int>
    {

        public FollowProfile()
        {
            //TODO:Create Guard
            //UserId = userid;
        }
        public FollowProfile(int followSmeprofileid, int myprofileid, string followprofilelogo, string followprofilename)
        { 
            //TODO:Create Guard
            FollowSmeProfileId = followSmeprofileid;
            MySmeProfileId = myprofileid;
            FollowProfileLogo = followprofilelogo;
            FollowProfileName = followprofilename;
        }

        public int FollowSmeProfileId { get; set; }
        public int MySmeProfileId { get; set; }
        public string FollowProfileLogo { get; set; }
        public string FollowProfileName { get; set; }
        public SmeProfile SmeProfile { get; set; }

    }
}
