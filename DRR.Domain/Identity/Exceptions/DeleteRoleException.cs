using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.MessageCodes;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Domain.Identity.Exceptions
{
    public sealed class DeleteRoleException : BusinessException
    {
        public DeleteRoleException(string message)
            : base(ExceptionCodes.Roll.DeleteRollError)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}
