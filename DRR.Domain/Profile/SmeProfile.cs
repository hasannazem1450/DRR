using DRR.Domain.Articles;
using DRR.Domain.BaseInfo;
using DRR.Domain.Comments;
using DRR.Domain.Customer;
using DRR.Domain.Event;
using DRR.Domain.SiteMessenger;
using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Common.Enums;
using System.Collections.Generic;

namespace DRR.Domain.Profile;

public class SmeProfile : Entity<int>
{
    public SmeProfile(string smeName, string nationalCode, string? businessCode, string? managerName,
        string? registerNumber, string? economyCode, string? permitNo, string managerPhoneNumber, string managerEmail,
        string aboutUs, string tellNumber, string activitySubject, string smeEmail, string smeWebsite, string address,
        int cityId, int? smeRankId, bool status, string logo, string headerpic, string postalcode,
        SmeType smeType)
    {
        CheckGuard();

        SmeName = smeName;
        NationalCode = nationalCode;
        BusinessCode = businessCode;
        ManagerName = managerName;
        RegisterNumber = registerNumber;
        EconomyCode = economyCode;
        PermitNo = permitNo;
        ManagerPhoneNumber = managerPhoneNumber;
        ManagerEmail = managerEmail;
        AboutUs = aboutUs;
        TellNumber = tellNumber;
        ActivitySubject = activitySubject;
        SmeEmail = smeEmail;
        SmeWebsite = smeWebsite;
        Address = address;
        CityId = cityId;
        SmeRankId = (int)smeRankId;
        Status = status;
        Logo = logo;
        Headerpic = headerpic;
        Postalcode = postalcode;
        SmeType = smeType;
        
    }

    public string SmeName { get; protected set; }
    public string NationalCode { get; protected set; }
    public string? BusinessCode { get; protected set; }
    public string ManagerName { get; protected set; }
    public string? RegisterNumber { get; protected set; }
    public string? EconomyCode { get; protected set; }
    public string? PermitNo { get; protected set; }
    public string ManagerPhoneNumber { get; protected set; }
    public string ManagerEmail { get; protected set; }
    public string AboutUs { get; protected set; }
    public string TellNumber { get; protected set; }
    public string ActivitySubject { get; protected set; }
    public string SmeEmail { get; protected set; }
    public string SmeWebsite { get; protected set; }
    public string? Address { get; protected set; }
    public bool Status { get; protected set; }
    public string Logo { get; protected set; }
    public string Headerpic { get; protected set; }
    public string Postalcode { get; protected set; }
    public SmeType SmeType { get; protected set; }

    public int CityId { get; protected set; }
    public City City { get; protected set; }

    public int? SmeRankId { get; protected set; }
    public SmeRank SmeRank { get; protected set; }


    public ICollection<SmeMember> SmeMembers { get; protected set; }

    public ICollection<News.Ads> Ads { get; protected set; }
    public ICollection<EventAttender> AttendedEvents { get; protected set; }

    public ICollection<UserProfile> UserProfiles { get; protected set; }
    public ICollection<MessagingGroupSmeProfile> MessagingGroupSmeProfiles { get; protected set; }
    public ICollection<SiteMessageReciver> SiteMessageRecivers { get; protected set; }
    public ICollection<Doctor> Doctors { get; protected set; }
    public ICollection<Article> Articles { get; protected set; }
    public ICollection<ArticleComment> ArticleComments { get; protected set; }
    public ICollection<Comment> Comments { get; protected set; }


    public void SetIsDeleted(bool isDeleted)
    {
        IsDeleted = isDeleted;
    }

    public void Update(string smeName, string nationalCode, string? businessCode, string? managerName,
        string? registerNumber, string? economyCode, string? permitNo, string managerPhoneNumber, string managerEmail,
        string aboutUs, string tellNumber, string activitySubject, string smeEmail, string smeWebsite, string address,
        int cityId, int? smeRankId, bool status, string logo, string headerpic, string postalcode,
        SmeType smeType)
    {
        SmeName = smeName;
        NationalCode = nationalCode;
        BusinessCode = businessCode;
        ManagerName = managerName;
        RegisterNumber = registerNumber;
        EconomyCode = economyCode;
        PermitNo = permitNo;
        ManagerPhoneNumber = managerPhoneNumber;
        ManagerEmail = managerEmail;
        AboutUs = aboutUs;
        TellNumber = tellNumber;
        ActivitySubject = activitySubject;
        SmeEmail = smeEmail;
        SmeWebsite = smeWebsite;
        Address = address;
        CityId = cityId;
        SmeRankId = smeRankId;
        Status = status;
        Logo = logo;
        Headerpic = headerpic;
        Postalcode = postalcode;
        SmeType = smeType;
    }

    private void CheckGuard()
    {
    }
}