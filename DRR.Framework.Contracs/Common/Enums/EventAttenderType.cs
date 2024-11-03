using System.ComponentModel;

namespace DRR.Framework.Contracts.Common.Enums;

public enum EventAttenderType
{
    /// <summary>
    /// غرفه‌دار
    /// </summary>
    [Description("غرفه‌دار")]
    Exhibitor = 1,

    /// <summary>
    /// بازدید کننده
    /// </summary>
    [Description("بازدید کننده")]
    Visitor = 2,

    /// <summary>
    /// شرکت در DRR
    /// </summary>
    [Description("شرکت در DRR")]
    Participant = 3,

    /// <summary>
    /// غرفه‌دار - شرکت در DRR
    /// </summary>
    [Description("غرفه‌دار - شرکت در DRR")]
    ExhibitorParticipant = 4,

    /// <summary>
    /// بازدید کننده - شرکت در DRR
    /// </summary>
    [Description("بازدید کننده - شرکت در DRR")]
    VisitorParticipant = 5
}