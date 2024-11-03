using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Profile.UserProfile
{
    public class CreateUserProfileCommand : Command
    {
        public Guid UserId { get; set; }
        public int ProfileId { get; set; }
        public int ProfileType { get; set; }
        public string ProfileName { get; set; }
        public string ProfileLogo { get; set; }
        public string UserName { get; set; }
    }
    public class CreateUserProfileCommandResponse : CommandResponse
    {
    }
}
