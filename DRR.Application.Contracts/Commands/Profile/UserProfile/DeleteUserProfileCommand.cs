using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Profile.UserProfile
{
    public class DeleteUserProfileCommand : Command
    {
        public int Id { get; set; }
    }

    public class DeleteUserProfileCommandResponse : CommandResponse
    {
    }
}
