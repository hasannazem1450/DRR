using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;

namespace DRR.CommandDb
{
    public class BaseProjectDbContextSaveChangesInterceptor : SaveChangesInterceptor
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IHttpContextAccessor _hasAccess;

        public BaseProjectDbContextSaveChangesInterceptor(IDateTimeProvider dateTimeProvider,
            IHttpContextAccessor hasAccess)
        {
            _dateTimeProvider = dateTimeProvider;
            _hasAccess = hasAccess;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            BeforeSavingApplyChanges(eventData);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            BeforeSavingApplyChanges(eventData);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {
            var savedChanges = base.SavedChanges(eventData, result);

            eventData.Context.ChangeTracker.Clear();

            return savedChanges;
        }

        public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            var savedChanges = base.SavedChangesAsync(eventData, result, cancellationToken);

            eventData.Context.ChangeTracker.Clear();

            return savedChanges;
        }
        private void BeforeSavingApplyChanges(DbContextEventData eventData)
        {
            var userInfo = GetUserInfo();

            eventData.Context.ChangeTracker.DetectChanges();

            var selectedEntityList = eventData.Context.ChangeTracker.Entries()
                .Where(x => !x.Entity.GetType().IsSubclassOf(typeof(ValueObject)));

            foreach (dynamic entity in selectedEntityList)
            {
                if (!HasProperty(entity.Entity, nameof(entity.Entity.CreatedAt))
                    || !HasProperty(entity.Entity, nameof(entity.Entity.CreatedBy))
                    || !HasProperty(entity.Entity, nameof(entity.Entity.ModifiedAt))
                    || !HasProperty(entity.Entity, nameof(entity.Entity.ModifiedBy)))
                    continue;

                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedAt = _dateTimeProvider.GetNow();
                    entity.Entity.CreatedBy = Guid.Parse(userInfo.First());
                }
                else if (entity.State == EntityState.Modified)
                {
                    entity.Entity.ModifiedAt = _dateTimeProvider.GetNow();
                    entity.Entity.ModifiedBy = Guid.Parse(userInfo.First());
                }
            }

        }
        private bool HasProperty(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName) != null;
        }

        private IEnumerable<string> GetUserInfo()
        {
            string userId;

            if (_hasAccess.HttpContext != null && _hasAccess.HttpContext.User.Claims.Any())
            {
                var claims = _hasAccess.HttpContext.User.Identity.Name;

                userId = claims;
            }
            else
            {
                userId = "230105FC-953E-4C11-8463-8BB37D0150D8";//user.Id.ToString();
            }

            yield return userId;
        }
    }
}
