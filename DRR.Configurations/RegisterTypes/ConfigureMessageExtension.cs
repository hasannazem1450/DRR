using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Repository;
using DRR.Domain.SystemMessages;
using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Common.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace DRR.Configurations.RegisterTypes
{
    public static class ConfigureMessageExtension
    {
        public static void ConfigureSystemMessages(this IApplicationBuilder app, IServiceProvider serviceProvider, Assembly[] assemblies)
        {
            CheckExistDuplicateIdentityInExceptionMessageList(app, serviceProvider, assemblies);

            CheckExistDuplicateIdentityInResponseMessageList(app, serviceProvider, assemblies);
        }

        private static void CheckExistDuplicateIdentityInExceptionMessageList(IApplicationBuilder app, IServiceProvider serviceProvider, Assembly[] assemblies)
        {
            Dictionary<string, BusinessException> errors = new Dictionary<string, BusinessException>();

            var systemErrorRepository = serviceProvider.GetRequiredService<ISystemMessageRepository>();

            foreach (Assembly assembly in assemblies)
            {
                var types = assembly.GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(BusinessException)));

                if (types != null && types.Count() > 0)
                {
                    foreach (Type item in types)
                    {
                        var constructor = item.GetConstructors();

                        if (constructor.Length == 1 && constructor.First().GetParameters().Length == 0)
                        {
                            dynamic ex = Activator.CreateInstance(item);

                            try
                            {
                                errors.Add(ex.Perfix + ex.Code.ToString(), ex);

                                var found = systemErrorRepository.GetMessageByCodeAndType(ex.Code, TypeSystemMessage.Error);

                                if (found == null)
                                {
                                    var systemErrorMessages = new List<SystemDataMessage>();

                                    systemErrorMessages.Add(new SystemDataMessage
                                    (
                                        ContentLanguage.English,
                                        ex.Perfix,
                                        ex.Message
                                    ));

                                    var systemError = new SystemMessage(ex.Code, TypeSystemMessage.Error, systemErrorMessages);

                                    systemErrorRepository.Create(systemError);
                                }
                            }
                            catch (SqlException)
                            {
                                throw;
                            }
                            catch (Exception exp)
                            {
                                var first = errors[ex.Perfix + ex.Code.ToString()];
                                var mess = $"Two type use same Code->\"{ex.Code}\" first type is \"{first.GetType().Name}\" and next type is \"{ex.GetType().Name}\" .\n {exp.Message} ";
                                throw new Exception(mess);
                            }
                        }
                    }
                }
            }
        }

        private static void CheckExistDuplicateIdentityInResponseMessageList(IApplicationBuilder app, IServiceProvider serviceProvider, Assembly[] assemblies)
        {
            Dictionary<string, CommandResponse> errors = new Dictionary<string, CommandResponse>();

            var systemErrorRepository = serviceProvider.GetRequiredService<ISystemMessageRepository>();

            foreach (Assembly assembly in assemblies)
            {
                var types = assembly.GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(CommandResponse)));

                if (types != null && types.Count() > 0)
                {
                    foreach (dynamic item in types)
                    {
                        ConstructorInfo[] constructor = item.GetConstructors();

                        if (constructor.Length == 1)
                        {
                            var par = constructor.First();

                            dynamic ex = Activator.CreateInstance(item);

                            if (ex.Code == 0) continue;

                            try
                            {
                                errors.Add(ex.Perfix + ex.Code.ToString(), ex);

                                var found = systemErrorRepository.GetMessageByCodeAndType(ex.Code, TypeSystemMessage.Response);

                                if (found == null)
                                {
                                    var systemErrorMessages = new List<SystemDataMessage>();

                                    systemErrorMessages.Add(new SystemDataMessage
                                    (
                                        ContentLanguage.English,
                                        ex.Perfix,
                                        ex.Message
                                    ));

                                    var systemError = new SystemMessage(ex.Code, TypeSystemMessage.Response, systemErrorMessages);

                                    systemErrorRepository.Create(systemError);
                                }
                            }
                            catch (Exception exp)
                            {
                                var first = errors[ex.Perfix + ex.Code.ToString()];
                                var mess = $"Tow type use same Code->\"{ex.Code}\" first type is \"{first.GetType().Name}\" and next type is \"{ex.GetType().Name}\" .";
                                throw new Exception(mess);
                            }
                        }
                    }
                }
            }
        }

    }
}
