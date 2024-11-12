using DRR.Application.Contracts.ACLs.Sms;
using DRR.Application.Contracts.ACLs.Sms.Models;
using DRR.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRR.Application.ACLs.SMS;

public class SmsAcl : ISmsAcl
{
    private readonly SmsSetting _smsSetting;

    public SmsAcl(IOptions<SmsSetting> smsOptions)
    {
        _smsSetting = smsOptions.Value;
    }

    public async Task<SmsAclOutputModel> Send(SmsAclInputModel model)
    {
        var client = new RestClient(_smsSetting.BaseUrl);
        //client.Authenticator =
        //    new HttpBasicAuthenticator(_smsSetting.Username + "/" + _smsSetting.Domain, _smsSetting.Password);

        var request = new RestRequest(_smsSetting.ResourceUrl, Method.Post);

        //request.AddHeader("cache-control", "no-cache");
        //request.AddHeader("accept", "application/json");

        request.AddParameter("sender", _smsSetting.Sender);
        request.AddParameter("message", model.Message);
        request.AddParameter("receptor", model.Receiver);

        //var response = await client.ExecuteAsync(request);
        var response = await client.ExecuteAsync(request);
        var responseModel = JsonConvert.DeserializeObject<SendResponseModel>(response.Content ?? "");

        return new SmsAclOutputModel
            {IsSuccess = response.IsSuccessful && responseModel.status == _smsSetting.SuccessCode};
    }

    internal class SendResponseModel
    {
        public int status { get; set; }
        public List<object> messages { get; set; }
    }
}