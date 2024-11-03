using DRR.Application.Contracts.Commands.Profile.UserProfile;
using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Profile.UserProfile
{
    public class ReadAllUserProfilesFilterQuery : Query
    {
        public int PerPage { get; set; }
        public int Page { get; set; }
        public string? Name { get; set; }
        public string? ManagerName { get; set; }
        public SmeType? Type { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
    }
    public class ReadAllUserProfilesFilterQueryResponse : QueryResponse
    {
        public List<UserProfileDto> List { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
    }
}
