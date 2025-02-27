﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.News
{
    public class CreateAdsCommand : Command
    {
        public string Title { get; set; }
        public string HeadLine { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public int SmeProfileId { get; set; }
    }

    public class CreateAdsCommandResponse : CommandResponse
    {
    }
}
