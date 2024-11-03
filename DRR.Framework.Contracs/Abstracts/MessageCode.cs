using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Framework.Contracts.Abstracts
{
    public sealed class CodeAndMessage
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }

    public abstract class MessageCode
    {
        protected MessageCode(string prefix, int code)
        {
            Prefix = prefix;
            Code = code;
        }

        protected MessageCode(string prefix, int code, string message)
        {
            Prefix = prefix;
            Code = code;
        }

        public string Prefix { get; protected set; }
        public int Code { get; protected set; }

    }

    public abstract class ExceptionMessageCode : MessageCode
    {
        public ExceptionMessageCode(string prefix, int code) : base(prefix, code)
        {

        }
    }

    public abstract class ResponseMessageCode : MessageCode
    {
        public ResponseMessageCode(string prefix, int code, string message) : base(prefix, code)
        {
            Message = message;
        }

        public string Message { get; protected set; }
    }
}
