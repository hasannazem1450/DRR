using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;

namespace DRR.Domain.BaseInfo
{

    public class Country : Entity<int>
    {
        public Country(string name, int? code)
        {
            Name = name;
            Code = code;
        }

        public string Name { get; protected set; }
        public int? Code { get; protected set; }

        public ICollection<Province> Provinces { get; set; }
    }
}