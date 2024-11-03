using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.MessageCodes;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.Exceptions
{
    public sealed class IdentityException : BusinessException
    {
        public IdentityException(string? persianMessage, string englishMessage)
            : base(ExceptionCodes.Identity.IdentityError)
        {
            if (persianMessage is null)
            {
                PersianMessage = englishMessage.Split("@")[0];
                EnglishMessage = englishMessage.Split("@")[1];
            }
            else
            {
                PersianMessage = persianMessage;
                EnglishMessage = englishMessage;
            }
        }

        public override string? PersianMessage { get; }
        public override string EnglishMessage { get; }
    }
}
