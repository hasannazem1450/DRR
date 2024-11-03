using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.MessageCodes;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Domain.Identity.Exceptions
{
    public sealed class IdentitySignOutException : BusinessException
    {
        public IdentitySignOutException()
            : base(ExceptionCodes.Identity.ClientHaveNoToken)
        {
        }

        public override string PersianMessage => "You Are Not Sign In !";
        public override string EnglishMessage => "شما به سایت وارد نشده اید !";
    }
}
