using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Domain.Information
{
    public class SearchHistory : Entity<int>
    {
        public string SearchTerm { get; set; }
        public int SearchCount { get; set; }

    }
}
