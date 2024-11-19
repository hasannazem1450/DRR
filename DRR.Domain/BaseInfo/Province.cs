using DRR.Domain.Event;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;

namespace DRR.Domain.BaseInfo
{

    public class Province : Entity<int>
    {
        public Province(string name, int? code, int countryId)
        {
            Name = name;
            Code = code;
            CountryId = countryId;
        }

        public string Name { get; protected set; }
        public int? Code { get; protected set; }

        public int CountryId { get; protected set; }
        public Country Country { get; protected set; }

        public ICollection<City> Cities { get; protected set; }
        public ICollection<EventInfo> EventsInfos { get; protected set; }

    }
}