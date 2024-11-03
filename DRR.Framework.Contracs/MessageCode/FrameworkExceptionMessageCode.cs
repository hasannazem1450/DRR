using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Framework.Contracts.MessageCode
{
    public sealed class FrameworkExceptionMessageCode : ExceptionMessageCode
    {
        public FrameworkExceptionMessageCode(int code) : base("FrameworkException", code)
        {
        }

        public static implicit operator FrameworkExceptionMessageCode(int first)
        {
            return new FrameworkExceptionMessageCode(first);
        }
    }
}
