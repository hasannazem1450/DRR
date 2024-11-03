using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Common.Enums;

namespace DRR.Application.Contracts.Queries.SystemMessages
{
    public class SystemErrorDto
    {
        public SystemErrorDto()
        {
            List = new List<SystemErrorMessageDto>();
        }

        public int Code { get; set; }

        public List<SystemErrorMessageDto> List { get; set; }
    }

    public class SystemErrorMessageDto
    {
        public ContentLanguage MessageLanguage { get; set; }
        public string Prefix { get; set; }
        public string Message { get; set; }
    }
}
