using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.Profile.FollowProfile
{
    public class UpdateFollowProfileCommand : Command
    {
        public int FollowProfileId { get; set; }
        public int MyProfileId { get; set; }
        public string FollowProfileLogo { get; set; }
        public string FollowProfileName { get; set; }
    }

    public class UpdateFollowProfileCommandResponse : CommandResponse
    {
    }
}
