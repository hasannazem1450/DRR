using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;

namespace DRR.Domain.Profile;

public class SmeRater : Entity<int>
{
    public SmeRater(string raterName)
    {
        RaterName = raterName;
    }

    public int Id { get; protected set; }
    public string RaterName { get; protected set; }
    public ICollection<SmeProfile> SmeProfiles { get; set; }
}