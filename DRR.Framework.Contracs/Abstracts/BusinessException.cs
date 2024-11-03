using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Framework.Contracts.Abstracts
{
    public abstract class BusinessException : Exception
    {
        public int Code { get; private set; }
        public string Prefix { get; private set; }
        public BusinessException(MessageCode exceptionCode)
        {
            Code = exceptionCode.Code;
            Prefix = exceptionCode.Prefix;
        }

        public virtual string EnglishMessage { get; }
        public virtual string PersianMessage { get; }

    }
}
