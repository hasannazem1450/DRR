using DRR.Domain.BaseInfo;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;

namespace DRR.Domain.Event;

public class EventInfo : Entity<int>
{
    public EventInfo()
    {
    }

    public EventInfo(string name, string photo, DateTime startDate, DateTime endDate, int periority, int provinceId)
    {
        Name = name;
        Photo = photo;
        StartDate = startDate;
        EndDate = endDate;
        Periority = periority;
        ProvinceId = provinceId;
    }

    public string Name { get; protected set; }
    public string Photo { get; protected set; }
    public DateTime StartDate { get; protected set; }
    public DateTime EndDate { get; protected set; }
    public int Periority { get; protected set; }

    public int ProvinceId { get; protected set; }
    public Province Province { get; protected set; }

    public ICollection<EventAttender> EventAttenders { get; protected set; }

    public void Update(string name, string photo, DateTime startDate, DateTime endDate, int periority,
        int provinceId)
    {
        Name = name;
        Photo = photo;
        StartDate = startDate;
        EndDate = endDate;
        Periority = periority;
        ProvinceId = provinceId;
    }
}