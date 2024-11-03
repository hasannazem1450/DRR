using DRR.Application.Contracts.Commands.Profile.UserProfile;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Profile.UserProfile
{

    public class ReadUserProfileQuery : Query
    {
    }

    public class ReadUserProfileQueryResponse : QueryResponse
    {
        public ReadUserProfileQueryResponse()
        {
            List = new List<UserProfileDto>();
        }
        public List<UserProfileDto> List { get; set; }
    }

}
