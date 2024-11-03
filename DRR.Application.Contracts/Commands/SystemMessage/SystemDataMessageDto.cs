using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Common.Enums;

namespace DRR.Application.Contracts.Commands.SystemMessage
{
    public class SystemDataMessageDto
    {
        public ContentLanguage MessageLanguage { get; set; }
        public string Prefix { get; set; }
        public string Message { get; set; }
    }
}
