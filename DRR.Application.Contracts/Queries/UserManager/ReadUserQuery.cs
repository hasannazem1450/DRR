using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.UserManager;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.UserManager
{
    public class ReadUserQuery : Query
    {
        public string? UserName { get; set; }
        public string? NormalizedUserName { get; set; }
        public string? Email { get; set; }
        public string? NormalizedEmail { get; set; }
        //public bool EmailConfirmed { get; set; }
        public string? PhoneNumber { get; set; }
        //public bool PhoneNumberConfirmed { get; set; }
        //public bool TwoFactorEnabled { get; set; }
    }


    public class ReadUserQueryResponse : QueryResponse
    {
        public ReadUserQueryResponse()
        {
            List = new List<AspUserNetDto>();
        }
        public List<AspUserNetDto> List { get; set; }
    }
}
