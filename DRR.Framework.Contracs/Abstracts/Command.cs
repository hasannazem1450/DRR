using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.MessageCode;
using Newtonsoft.Json;

namespace DRR.Framework.Contracts.Abstracts
{
    public abstract class Command
    {
        [JsonIgnore]
        public Metadata Metadata { get; set; }

        public Command()
        {
            Metadata = new Metadata();
        }
    }

    public abstract class CommandResponse
    {
        [JsonIgnore]
        public string Prefix { get; protected set; }
        [JsonIgnore]
        public int Code { get; protected set; }
        [JsonIgnore]
        public string Message { get; protected set; }

        protected CommandResponse()
        {
        }

        protected CommandResponse(ResponseMessageCode messageCode)
        {
            Prefix = messageCode.Prefix;
            Code = messageCode.Code;
            Message = messageCode.Message;
        }
    }

    public class CommandResponseSuccessful : CommandResponse
    {
        public CommandResponseSuccessful() : base(ResponseCodes.OPERATION_SUCCESSFULL)
        {
        }

        public static CommandResponse CreateSuccessful()
        {
            return new CommandResponseSuccessful();
        }
    }

    public class CommandResponseFailed : CommandResponse
    {
        public CommandResponseFailed() : base(ResponseCodes.OPERATION_FAILED)
        {
        }

        public static CommandResponse CreateFailed()
        {
            return new CommandResponseFailed();
        }
    }

    public class CommandResponseCanceled : CommandResponse
    {
        public CommandResponseCanceled() : base(ResponseCodes.OPERATION_CANCELED)
        {
        }

        public static CommandResponse CreateCanceled()
        {
            return new CommandResponseCanceled();
        }
    }
}
