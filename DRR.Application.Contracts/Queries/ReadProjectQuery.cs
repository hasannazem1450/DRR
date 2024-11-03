using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries
{
    public class ReadProjectQuery : Query
    {
        public string ProjectName { get; set; }
        public int Price { get; set; }
    }

    public class ReadProjectResponse : Query
    {
        public int ProjectName { get; set; }
        public int Price { get; set; }
    }
}
