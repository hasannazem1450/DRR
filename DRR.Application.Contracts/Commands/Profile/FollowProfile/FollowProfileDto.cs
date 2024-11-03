using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Profile.FollowProfile
{
    public class FollowProfileDto
    {
        public int Id { get; set; }
        public int FollowProfileId { get; set; }
        public int MyProfileId { get; set; }
        public string FollowProfileLogo { get; set; }
        public string FollowProfileName { get; set; }

    }
}
