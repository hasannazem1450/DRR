using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.MessageCodes
{
    public sealed class ApplicationExceptionMessageCode : ExceptionMessageCode
    {
        public ApplicationExceptionMessageCode(int code) : base("ApplicationException", code)
        {
        }

        public static implicit operator ApplicationExceptionMessageCode(int first)
        {
            return new ApplicationExceptionMessageCode(first);
        }
    }
}
