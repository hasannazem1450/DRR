using DRR.Application.Contracts.Commands.Event;
using DRR.Domain.Event;
using DRR.Framework.Contracts.Common.Enums;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Services.Event;

public interface IEventInfoService : IService
{
    Task<List<EventInfoDto>> ConvertToDto(List<EventInfo> eventInfos);
    Task<EventInfoDto> ConvertToDto(EventInfo eventInfo);


    Task<EventInfoState> GetState(EventInfo eventInfo);

    Task<List<EventInfoDto>> FilterByName(List<EventInfoDto> eventInfos, string name);
    Task<List<EventInfoDto>> FilterByProvince(List<EventInfoDto> eventInfos, int provinceId);
    Task<List<EventInfoDto>> FilterByState(List<EventInfoDto> eventInfos, EventInfoState eventInfoState);
    Task<List<EventInfoDto>> FilterByState(List<EventInfoDto> eventInfos, List<EventInfoState> eventInfoStates);
    Task<List<EventInfoDto>> FilterByDate(List<EventInfoDto> eventInfos, DateTime fromDate, DateTime toDate);
}