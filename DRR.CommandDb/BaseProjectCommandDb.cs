using System;
using System.Linq.Expressions;
using DRR.Domain.Articles;
using DRR.Domain.BaseInfo;
using DRR.Domain.Comments;
using DRR.Domain.Customer;
using DRR.Domain.Event;
using DRR.Domain.FileManagement;
using DRR.Domain.Finance;
using DRR.Domain.Identity;
using DRR.Domain.Insurances;
using DRR.Domain.News;
using DRR.Domain.Profile;
using DRR.Domain.Profile.Follow;
using DRR.Domain.Profile.Member;
using DRR.Domain.Project;
using DRR.Domain.Reserv;
using DRR.Domain.SiteMessenger;
using DRR.Domain.Sms;
using DRR.Domain.Specialists;
using DRR.Domain.SystemMessages;
using DRR.Domain.TreatmentCenters;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DRR.CommandDB;

public sealed class BaseProjectCommandDb : IdentityDbContext<ApplicationUser>
{
    public BaseProjectCommandDb(DbContextOptions<BaseProjectCommandDb> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public DbSet<Article> Articles { get; set; }
    public DbSet<ArticleType> ArticleTypes { get; set; }
    public DbSet<PatientTransaction> PatientTransactions { get; set; }
    public DbSet<PatientInsurance> PatientInsurances { get; set; }
    public DbSet<DoctorInsurance> DoctorInsurances { get; set; }
    public DbSet<DoctorFinanceAccount> DoctorFinanceAccounts { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<VisitCost> VisitCosts { get; set; }
    public DbSet<DoctorTreatmentCenter> DoctorTreatmentCenters { get; set; }
    public DbSet<OfficeType> OfficeTypes { get; set; }
    public DbSet<Specialist> Specialists { get; set; }
    public DbSet<ArticleComment> ArticleComments { get; set; }
    public DbSet<CommentReply> CommentReplys { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<DiscountCode> DiscountCodes { get; set; }
    public DbSet<Insurance> Insurances { get; set; }
    public DbSet<InsuranceType> InsuranceTypes { get; set; }
    public DbSet<PatientReservation> PatientReservations { get; set; }
    public DbSet<PatientFavorite> PatientFavorites { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<VisitType> VisitTypes { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<ClinicType> ClinicTypes { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<SystemMessage> SystemMessages { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<SmeProfile> SmeProfiles { get; set; }
    public DbSet<SmeRank> SmeRanks { get; set; }
    public DbSet<SmeRater> SmeRaters { get; set; }
    public DbSet<SmeMember> SmeMembers { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Ads> Ads { get; set; }
    public DbSet<EventInfo> EventInfos { get; set; }
    public DbSet<EventAttender> EventAttenders { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<FollowProfile> FollowProfiles { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<SmsInfo> SmsInfos { get; set; }
    public DbSet<SiteMessage> SiteMessages { get; set; }
    public DbSet<MessagingGroup> MessagingGroups { get; set; }
    public DbSet<MessagingGroupSmeProfile> MessagingGroupSmeProfiles { get; set; }
    public DbSet<SiteMessageReciver> SiteMessageRecivers { get; set; }
    public DbSet<DRRFile> DRRFiles { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<SiteMessageImage> SiteMessageImages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var isDeletedProperty = entityType.FindProperty("IsDeleted");
            if (isDeletedProperty != null && isDeletedProperty.ClrType == typeof(bool))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "p");
                var filter = Expression.Lambda(
                    Expression.Equal(
                        Expression.Property(parameter, isDeletedProperty.PropertyInfo),
                        Expression.Constant(false, typeof(bool))
                    )
                    , parameter);
                entityType.SetQueryFilter(filter);
            }
        }

        base.OnModelCreating(modelBuilder);
    }
}

public class BaseProjectContextFactory : IDesignTimeDbContextFactory<BaseProjectCommandDb>
{
    public BaseProjectCommandDb CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BaseProjectCommandDb>();
        
        optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=DRR;User Id=sa;Password=123;TrustServerCertificate=True;");

        return new BaseProjectCommandDb(optionsBuilder.Options);
    }
}