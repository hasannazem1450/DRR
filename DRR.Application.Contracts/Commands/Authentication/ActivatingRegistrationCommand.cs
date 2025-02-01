﻿using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.Authentication;

public class ActivatingRegistrationCommand : Command
{
    public string Mobile { get; set; }
    public string ActivationCode { get; set; }
}

public class ActivatingRegistrationCommandResponse : CommandResponse
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public string ExpiredAt { get; set; }
    public string UserFullname { get; set; }
    public int SmeprofileId { get; set; }
}