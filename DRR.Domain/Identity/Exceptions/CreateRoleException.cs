using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.MessageCodes;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Domain.Identity.Exceptions
{
    public sealed class CreateRoleException : BusinessException
    {
        public CreateRoleException(string message)
            : base(ExceptionCodes.Roll.CreateRollError)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}
