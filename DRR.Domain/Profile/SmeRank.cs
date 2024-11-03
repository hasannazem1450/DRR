using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;

namespace DRR.Domain.Profile;

public class SmeRank : Entity<int>
{
    public SmeRank(string title)
    {
        Title = title;
    }

    public int Id { get; set; }
    public string Title { get; set; }

    public ICollection<SmeProfile> SmeProfiles { get; set; }
}