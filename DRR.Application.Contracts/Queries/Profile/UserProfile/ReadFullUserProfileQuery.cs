using DRR.Application.Contracts.Commands.Profile.UserProfile;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Profile.UserProfile
{

    public class ReadAllUserProfileQuery : Query
    {
        public int Id { get; set; }
    }

    public class ReadAllUserProfileQueryResponse : QueryResponse
    {
        public ReadAllUserProfileQueryResponse()
        {
            List = new List<UserProfileDto>();
        }
        public List<UserProfileDto> List { get; set; }
    }

}
