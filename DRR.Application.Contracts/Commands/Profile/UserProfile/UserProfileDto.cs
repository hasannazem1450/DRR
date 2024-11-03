using DRR.Framework.Contracts.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Profile.UserProfile
{
    public class UserProfileDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? ProfileName { get; set; }
        public string? ProfileLogo { get; set; }
        public int RankId { get; set; }
        public string SmeProfileTypeName { get; set; }
        public string ManagerName { get; set; }
        public Guid UserId { get; set; }
        public int ProfileId { get; set; }
        public string? LastModify { get; set; }
    }
}
