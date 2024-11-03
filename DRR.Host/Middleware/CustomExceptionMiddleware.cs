using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DRR.Application.Contracts.Repository;
using DRR.CommandDB;
using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Common;
using DRR.Framework.Contracts.Common.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DRR.Host.Middleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private ISystemMessageRepository _systemErrorRepository;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, BaseProjectCommandDb commandDbContext, ISystemMessageRepository systemErrorRepository)
        {
            _systemErrorRepository = systemErrorRepository;
            try
            {
                await _next(context);
            }
            catch (BusinessException bex)
            {
                await HandleExceptionAsync(context, bex);
            }
            catch (DbUpdateException ex)
            {
                commandDbContext.ChangeTracker.DetectChanges();

                var changedEntries = commandDbContext.ChangeTracker.Entries()
                    .Where(w => w.State == EntityState.Added || w.State == EntityState.Modified).ToList();

                if(changedEntries!=null && changedEntries.Any())
                    foreach (var changedEntry in changedEntries)
                    {
                        changedEntry.State = EntityState.Detached;
                    }

                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task<Task> HandleExceptionAsync(HttpContext context, BusinessException exception)
        {
            context.Response.ContentType = "application/json";
            string result;
            if (exception is BusinessException)
            {
                ContentLanguage contentLanguage = GetContentLanguage(context);

                result = new ApiResult()
                {
                    HasError = true,
                    Message = await GetMessage(exception, contentLanguage),
                    Code = (int)HttpStatusCode.Conflict
                }.ToString();
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
            }
            else
            {
                result = new ApiResult()
                {
                    HasError = true,
                    Message = new StructureMessage
                    {
                        Message = "Runtime Error"
                    },
                    Code = (int)HttpStatusCode.BadRequest
                }.ToString();
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            return context.Response.WriteAsync(result);
        }

        public static async Task<Task> HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string result;
            context.Response.ContentType = "application/json";
            if (exception.InnerException == null)
            {
                result = new ApiResult
                {
                    HasError = true,
                    Message = new StructureMessage()
                    {
                        Message = exception.Message
                    },
                    Code = (int)HttpStatusCode.InternalServerError
                }.ToString();
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return context.Response.WriteAsync(result);
            }

            if (exception.InnerException.GetType() == typeof(BusinessException))
            {
                return HandleExceptionAsync(context, exception.InnerException);
            }

            result = new ApiResult
            {
                HasError = true,
                Message = new StructureMessage()
                {
                    Message = exception.Message
                },
                Code = (int)HttpStatusCode.InternalServerError
            }.ToString();
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return context.Response.WriteAsync(result);
        }

        private ContentLanguage GetContentLanguage(HttpContext context)
        {
            ContentLanguage result = ContentLanguage.Persian;

            if (context.Request.Headers.ContainsKey("language"))
            {
                var num = Convert.ToInt32(context.Request.Headers["language"].First());

                if (Enum.IsDefined(typeof(ContentLanguage), num))
                {
                    result = (ContentLanguage)num;
                }
            }

            return result;
        }

        private async Task<dynamic> GetMessage(BusinessException exception, ContentLanguage contentLanguage)
        {
            var found =
                await _systemErrorRepository.GetDataMessageByCodeAndType(exception.Code, TypeSystemMessage.Error, contentLanguage);

            StructureMessage structureMessage;

            if (found != null)
            {
                structureMessage = new StructureMessage { MessageLanguage = found.MessageLanguage, Message = found.Message };
            }
            else
            {
                switch (contentLanguage)
                {
                    case ContentLanguage.English:
                        structureMessage = new StructureMessage { MessageLanguage = contentLanguage, Message = exception.EnglishMessage };
                        break;
                    case ContentLanguage.Persian:
                        structureMessage = new StructureMessage { MessageLanguage = contentLanguage, Message = exception.PersianMessage };
                        break;
                    default:
                        structureMessage = new StructureMessage { MessageLanguage = ContentLanguage.Persian, Message = exception.PersianMessage };
                        break;
                }
            }

            return new JsonResult(structureMessage).Value;
        }
    }
}
