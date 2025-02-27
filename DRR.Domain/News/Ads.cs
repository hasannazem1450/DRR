﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.Profile;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Domain.News
{
    public class Ads : Entity<int>
    {
        public Ads(string title, string headLine, string description, string photo)
        {
            Title = title;
            HeadLine = headLine;
            Description = description;
            Photo = photo;
        }

        public void Update(string title, string headLine, string description, string photo)
        {
            Title = title;
            HeadLine = headLine;
            Description = description;
            Photo = photo;
        }

        public string Title { get; set; }
        public string HeadLine { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }

        public int SmeProfileId { get; set; }
        public SmeProfile SmeProfile { get; set; }
    }
}
