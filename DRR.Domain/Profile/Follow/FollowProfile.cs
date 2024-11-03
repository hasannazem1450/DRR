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
        public FollowProfile(int followprofileid, int myprofileid, string followprofilelogo, string followprofilename)
        { 
            //TODO:Create Guard
            FollowProfileId = followprofileid;
            MyProfileId = myprofileid;
            FollowProfileLogo = followprofilelogo;
            FollowProfileName = followprofilename;
        }

        public int Id { get; set; }
        public int FollowProfileId { get; set; }
        public int MyProfileId { get; set; }
        public string FollowProfileLogo { get; set; }
        public string FollowProfileName { get; set; }

    }
}
