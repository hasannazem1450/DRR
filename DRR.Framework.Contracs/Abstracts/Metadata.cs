using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Framework.Contracts.Abstracts
{
    public sealed class Metadata
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string UserName { get; set; } = "test";
        public int SmeProfileId { get; set; } = 0;

    }
}
