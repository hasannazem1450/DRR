using DRR.Application.CommandHandlers.Event.Exceptions;
using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Services.Event;
using DRR.Domain.Event;
using DRR.Framework.Contracts.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRR.Application.Services.Event;

public class EventInfoService : IEventInfoService
{
    public async Task<List<EventInfoDto>> ConvertToDto(List<EventInfo> eventInfos)
    {
        var result = eventInfos.Select(s => new EventInfoDto
        {
            Id = s.Id,
            ProvinceId = s.ProvinceId,
            ProvinceName = s.Province?.Name ?? "",
            EndDate = s.EndDate,
            Name = s.Name,
            Periority = s.Periority,
            Photo = s.Photo,
            StartDate = s.StartDate,
            State = GetState(s).Result
        }).ToList();

        return result;
    }

    public async Task<EventInfoDto> ConvertToDto(EventInfo eventInfo)
    {
        var result = new EventInfoDto
        {
            Id = eventInfo.Id,
            ProvinceId = eventInfo.ProvinceId,
            ProvinceName = eventInfo.Province?.Name ?? "",
            EndDate = eventInfo.EndDate,
            Name = eventInfo.Name,
            Periority = eventInfo.Periority,
            Photo = eventInfo.Photo,
            StartDate = eventInfo.StartDate,
            State = await GetState(eventInfo)
        };

        return result;
    }

    public async Task<EventInfoState> GetState(EventInfo eventInfo)
    {
        var result =
            eventInfo.EndDate < DateTime.Today ? EventInfoState.Finished :
            eventInfo.StartDate <= DateTime.Today && DateTime.Today <= eventInfo.EndDate ? EventInfoState.InProgress :
            DateTime.Today < eventInfo.StartDate ? EventInfoState.Feature :
            EventInfoState.Finished;

        return result;
    }

    public async Task<List<EventInfoDto>> FilterByName(List<EventInfoDto> eventInfos, string name)
    {
        var result = eventInfos.Where(w => w.Name.Contains(name)).ToList();

        return result;
    }

    public async Task<List<EventInfoDto>> FilterByProvince(List<EventInfoDto> eventInfos, int provinceId)
    {
        var result = eventInfos.Where(w => w.ProvinceId == provinceId).ToList();

        return result;
    }

    public async Task<List<EventInfoDto>> FilterByState(List<EventInfoDto> eventInfos, EventInfoState eventInfoState)
    {
        var result = eventInfos.Where(w => w.State == eventInfoState).ToList();

        return result;
    }

    public async Task<List<EventInfoDto>> FilterByState(List<EventInfoDto> eventInfos, List<EventInfoState> eventInfoStates)
    {
        var result = eventInfos.Where(w => eventInfoStates.Contains(w.State)).ToList();

        return result;
    }

    public async Task<List<EventInfoDto>> FilterByDate(List<EventInfoDto> eventInfos, DateTime fromDate, DateTime toDate)
    {
        if (toDate < fromDate)
            throw new DateRangeIsInvalidException();

        var result = eventInfos.Where(w =>
            fromDate <= w.StartDate && w.StartDate <= toDate ||
            fromDate <= w.EndDate && w.EndDate <= toDate ||
            w.StartDate < fromDate && toDate < w.EndDate
        ).ToList();

        return result;
    }
}