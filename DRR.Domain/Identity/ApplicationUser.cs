﻿using DRR.Domain.Profile;
using DRR.Domain.SiteMessenger;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DRR.Domain.Identity;

public class ApplicationUser : IdentityUser
{
    public string Fullname { get; set; }

    public ICollection<UserProfile> UserProfiles { get; protected set; }
    public ICollection<SiteMessage> SiteMessages { get; protected set; }
}