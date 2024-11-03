using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.SystemMessages.Exceptions;
using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Common.Enums;
using DRR.Utilities.Extensions;

namespace DRR.Domain.SystemMessages
{
    public class SystemMessage : Entity<int>
    {
        protected SystemMessage()
        {
        }

        public SystemMessage(int code, TypeSystemMessage typeSystemMessage, List<SystemDataMessage> systemErrorMessages)
        {
            GuardForCode(code);
            GuardForCheckSystemErrorMessage(systemErrorMessages);

            Code = code;

            TypeMessage = typeSystemMessage;

            SystemDataMessages = systemErrorMessages;
        }

        public TypeSystemMessage TypeMessage { get; private set; }

        public int Code { get; private set; }

        public List<SystemDataMessage> SystemDataMessages { get; private set; }

        public void UpdateMessage(List<SystemDataMessage>? systemErrorMessages)
        {
            if (systemErrorMessages.IsNullOrEmptyExtension()) return;

            foreach (var item in systemErrorMessages)
            {
                var found = SystemDataMessages.FirstOrDefault(x => x.MessageLanguage == item.MessageLanguage);

                if (found != null)
                {
                    found.Update(item.Prefix, item.Message , item.ModifiedBy.ToString());
                }
                else
                {
                    SystemDataMessages.Add(item);
                }
            }
        }

        public void DeleteMessageByLanguage(List<ContentLanguage> messageLanguages)
        {
            if (messageLanguages.IsNullOrEmptyExtension()) return;

            foreach (var item in messageLanguages)
            {
                var found = SystemDataMessages.FirstOrDefault(x => x.MessageLanguage == item);

                if (found != null)
                {
                    SystemDataMessages.Remove(found);
                }
            }
        }

        private static void GuardForCode(int code)
        {
            if (!code.IsValidId()) throw new SystemErrorCodeIsInvalidException();
        }

        private static void GuardForCheckSystemErrorMessage(List<SystemDataMessage> systemErrorMessages)
        {
            if (systemErrorMessages.IsNullOrEmptyExtension())
            {
                throw new SystemErrorMessageIsEmptyException();
            }
        }
    }
}
