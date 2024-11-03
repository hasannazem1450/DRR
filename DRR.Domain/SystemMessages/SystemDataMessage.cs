using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Common.Enums;

namespace DRR.Domain.SystemMessages
{
    public class SystemDataMessage : Entity<int>
    {
        public int LocalId { get; private set; }
        protected SystemDataMessage(string prefix, string message)
        {
            Prefix = prefix;
            Message = message;
        }

        public SystemDataMessage(ContentLanguage messageLanguage, string prefix, string message)
        {
            MessageLanguage = messageLanguage;
            Prefix = prefix;
            Message = message;
        }

        public ContentLanguage MessageLanguage { get; private set; }
        public string Prefix { get; private set; }
        public string Message { get; private set; }

        public void Update(string prefix, string message , string modifyBy)
        {
            Prefix = prefix;
            Message = message;
            ModifiedAt = DateTime.Now;
            ModifiedBy = Guid.Parse(modifyBy);
        }
    }
}
