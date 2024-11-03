using DRR.Framework.Contracts.Common.Enums;
using System;

namespace DRR.Application.Contracts.Commands.Event;

public class EventInfoDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Periority { get; set; }
    public int ProvinceId { get; set; }
    public string ProvinceName { get; set; }
    public EventInfoState State { get; set; }
}